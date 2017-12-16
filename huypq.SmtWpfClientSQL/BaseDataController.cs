using huypq.SmtShared;
using huypq.SmtShared.Constant;
using huypq.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClientSQL
{
    public abstract class BaseDataController<ContextType, EntityType, DtoType> : IDataProvider
        where ContextType : DbContext, IDbContext
        where DtoType : class, IDto, new()
        where EntityType : class, IEntity
    {
        ContextType _context = ServiceLocator.Get<IDbContext>() as ContextType;

        protected virtual OrderByExpression.OrderOption GetDefaultOrderOption()
        {
            return Settings.DefaultOrderOption;
        }

        public object ActionInvoker(string actionName, object parameters)
        {
            object result = null;

            switch (actionName)
            {
                case ControllerAction.SmtEntityBase.Get:
                    result = Get(parameters as QueryExpression, GetQuery());
                    break;
                case ControllerAction.SmtEntityBase.GetByID:
                    result = GetByID((int)parameters, GetQuery());
                    break;
                case ControllerAction.SmtEntityBase.GetAll:
                    result = GetAll(parameters as QueryExpression, GetQuery());
                    break;
                case ControllerAction.SmtEntityBase.GetUpdate:
                    result = GetUpdate(parameters as QueryExpression, GetQuery());
                    break;
                case ControllerAction.SmtEntityBase.Save:
                    result = Save(parameters as List<DtoType>);
                    break;
                case ControllerAction.SmtEntityBase.Add:
                    result = Add(parameters as DtoType);
                    break;
                case ControllerAction.SmtEntityBase.Update:
                    result = Update(parameters as DtoType);
                    break;
                case ControllerAction.SmtEntityBase.Delete:
                    result = Delete(parameters as DtoType);
                    break;
                default:
                    break;
            }

            return result;
        }

        protected object Get(QueryExpression filter, IQueryable<EntityType> includedQuery)
        {
            int pageCount = 1;
            var query = includedQuery;
            var result = new PagingResultDto<DtoType>
            {
                Items = new List<DtoType>()
            };

            if (filter != null)
            {
                var maxItemAllowed = GetMaxItemAllowed();
                if (filter.PageSize > 0 && filter.PageSize <= maxItemAllowed)
                {
                    if (filter.PageIndex <= 0)//forced to use paging
                    {
                        filter.PageIndex = 1;
                    }

                    if (filter.OrderOptions.Count == 0)
                    {
                        filter.OrderOptions.Add(GetDefaultOrderOption());
                    }
                    query = QueryExpression.AddQueryExpression(
                    query, ref filter, out pageCount);

                    result.PageIndex = filter.PageIndex;
                    result.PageCount = pageCount;
                }
                else
                {
                    var msg = string.Format("PageSize must greater than zero and lower than {0}", maxItemAllowed + 1);
                    throw new Exception(msg);
                }
            }

            result.LastUpdateTime = DateTime.UtcNow.Ticks;
            foreach (var entity in query)
            {
                if (entity.LastUpdateTime <= result.LastUpdateTime)
                {
                    result.Items.Add(ConvertToDto(entity));
                }
            }

            return result;
        }

        protected object GetByID(int id, IQueryable<EntityType> includedQuery)
        {
            var entity = includedQuery.FirstOrDefault(p => p.ID == id);
            return ConvertToDto(entity);
        }

        protected object GetAll(QueryExpression filter, IQueryable<EntityType> includedQuery)
        {
            var query = includedQuery;
            var result = new PagingResultDto<DtoType>
            {
                Items = new List<DtoType>()
            };

            if (filter != null)
            {
                query = WhereExpression.AddWhereExpression(query, filter.WhereOptions);
                //query = OrderByExpression.AddOrderByExpression(query, filter.OrderOptions); //must order in client for perfomance
            }

            result.LastUpdateTime = DateTime.UtcNow.Ticks;
            foreach (var entity in query)
            {
                if (entity.LastUpdateTime <= result.LastUpdateTime)
                {
                    result.Items.Add(ConvertToDto(entity));
                }
            }

            return result;
        }

        protected object GetUpdate(QueryExpression filter, IQueryable<EntityType> includedQuery)
        {
            if (filter == null)
            {
                var msg = string.Format(string.Format("Need specify {0} where options", nameof(IDto.LastUpdateTime)));
                throw new Exception(msg);
            }

            var lastUpdateWhereOption = filter.WhereOptions.Find(p => p.PropertyPath == nameof(IDto.LastUpdateTime));
            if (lastUpdateWhereOption == null)
            {
                var msg = string.Format(string.Format("Need specify {0} where options", nameof(IDto.LastUpdateTime)));
                throw new Exception(msg);
            }

            var query = includedQuery;
            var tableName = GetTableName();
            var result = new PagingResultDto<DtoType>
            {
                Items = new List<DtoType>()
            };
            var tableID = _context.SmtTable.FirstOrDefault(p => p.TableName == tableName).ID;

            query = WhereExpression.AddWhereExpression(query, filter.WhereOptions);
            //query = OrderByExpression.AddOrderByExpression(query, filter.OrderOptions); //must order in client for perfomance

            var lastUpdate = (long)lastUpdateWhereOption.GetValue();
            var deletedItemsQuery = _context.SmtDeletedItem.Where(p => p.TableID == tableID && p.CreateTime > lastUpdate);

            var itemCount = query.Count() + deletedItemsQuery.Count();
            var maxItem = GetMaxItemAllowed();

            if (itemCount > maxItem)
            {
                var msg = string.Format("Entity set too large, max item allowed is {0}", maxItem);
                throw new Exception(msg);
            }

            result.LastUpdateTime = DateTime.UtcNow.Ticks;
            foreach (var entity in query)
            {
                if (entity.LastUpdateTime <= result.LastUpdateTime)
                {
                    var dto = ConvertToDto(entity);
                    dto.State = (dto.CreateTime > lastUpdate) ? DtoState.Add : DtoState.Update;
                    result.Items.Add(dto);
                }
            }
            foreach (var item in deletedItemsQuery)
            {
                if (item.CreateTime <= result.LastUpdateTime)
                {
                    result.Items.Add(new DtoType() { ID = item.DeletedID, State = DtoState.Delete, CreateTime = item.CreateTime });
                }
            }
            return result;
        }

        protected object Save(List<DtoType> items)
        {
            List<EntityType> changedEntities = new List<EntityType>();
            var tableName = GetTableName();
            var tableID = _context.SmtTable.FirstOrDefault(p => p.TableName == tableName).ID;
            var now = DateTime.UtcNow.Ticks;

            foreach (var dto in items)
            {
                var entity = ConvertToEntity(dto);

                switch (dto.State)
                {
                    case DtoState.Add:
                        entity.CreateTime = now;
                        entity.LastUpdateTime = now;
                        _context.Set<EntityType>().Add(entity);
                        changedEntities.Add(entity);
                        break;
                    case DtoState.Update:
                        entity.LastUpdateTime = now;
                        UpdateEntity(_context, entity);
                        changedEntities.Add(entity);
                        break;
                    case DtoState.Delete:
                        _context.Set<EntityType>().Attach(entity);
                        _context.Set<EntityType>().Remove(entity);
                        _context.SmtDeletedItem.Add(new SmtDeletedItem()
                        {
                            DeletedID = entity.ID,
                            TableID = tableID,
                            CreateTime = now
                        });
                        changedEntities.Add(entity);
                        break;
                    default:
                        throw new Exception("invalid dto State");
                }
            }

            return SaveChanges(items, changedEntities);
        }

        protected object Add(DtoType dto)
        {
            dto.State = DtoState.Add;
            var entity = ConvertToEntity(dto);
            entity.LastUpdateTime = DateTime.UtcNow.Ticks;
            _context.Set<EntityType>().Add(entity);

            return SaveChanges(new List<DtoType>() { dto }, new List<EntityType>() { entity });
        }

        protected object Update(DtoType dto)
        {
            dto.State = DtoState.Update;
            var entity = ConvertToEntity(dto);
            entity.LastUpdateTime = DateTime.UtcNow.Ticks;

            UpdateEntity(_context, entity);

            return SaveChanges(new List<DtoType>() { dto }, new List<EntityType>() { entity });
        }

        protected object Delete(DtoType dto)
        {
            dto.State = DtoState.Delete;
            var entity = ConvertToEntity(dto);

            var tableName = GetTableName();
            _context.Set<EntityType>().Attach(entity);
            _context.Set<EntityType>().Remove(entity);
            _context.SmtDeletedItem.Add(new SmtDeletedItem()
            {
                DeletedID = entity.ID,
                TableID = _context.SmtTable.FirstOrDefault(p => p.TableName == tableName).ID,
                CreateTime = DateTime.UtcNow.Ticks
            });
            return SaveChanges(new List<DtoType>() { dto }, new List<EntityType>() { entity });
        }

        protected string SaveChanges(List<DtoType> items, List<EntityType> changedEntities)
        {
            try
            {
                var changeCount = _context.SaveChanges();
                AfterSave(items, changedEntities);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            //need return an json object, if just return status code, jquery will treat as fail.
            return "OK";
        }

        protected virtual void UpdateEntity(ContextType context, EntityType entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        protected virtual void AfterSave(List<DtoType> items, List<EntityType> changedEntities)
        {

        }

        protected virtual int GetMaxItemAllowed()
        {
            return 100;
        }

        protected virtual IQueryable<EntityType> GetQuery()
        {
            return _context.Set<EntityType>();
        }

        public abstract DtoType ConvertToDto(EntityType entity);

        public abstract EntityType ConvertToEntity(DtoType dto);

        protected string GetTableName()
        {
            return typeof(EntityType).Name;
        }
    }
}
