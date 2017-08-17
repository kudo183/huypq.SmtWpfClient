using huypq.SmtShared;
using huypq.SmtShared.Constant;
using huypq.SmtWpfClient;
using huypq.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using huypq.wpf.Utils;

namespace huypq.SmtWpfClientSQL
{
    public abstract class BaseDataProvider<ContextType, EntityType, DtoType>
        where ContextType : DbContext, IDbContext
        where DtoType : IDto, new()
        where EntityType : class, IEntity
    {
        ContextType _context = ServiceLocator.Get<ContextType>();

        OrderByExpression.OrderOption DefaultOrderOption = new OrderByExpression.OrderOption()
        {
            PropertyPath = nameof(IDto.ID),
            IsAscending = false
        };

        public PagingResultDto<DtoType> Get(QueryExpression qe)
        {
            int pageCount = 1;
            var query = GetQuery();
            var result = new PagingResultDto<DtoType>
            {
                Items = new List<DtoType>()
            };

            if (qe != null)
            {
                if (qe.PageIndex > 0)
                {
                    if (qe.OrderOptions.Count == 0)
                    {
                        qe.OrderOptions.Add(DefaultOrderOption);
                    }
                    query = QueryExpression.AddQueryExpression(
                    query, ref qe, out pageCount);

                    result.PageIndex = qe.PageIndex;
                    result.PageCount = pageCount;
                }
                else
                {
                    query = WhereExpression.AddWhereExpression(query, qe.WhereOptions);
                    query = OrderByExpression.AddOrderByExpression(query, qe.OrderOptions);
                }
            }

            var itemCount = query.Count();
            var maxItem = GetMaxItemAllowed();

            if (itemCount > maxItem)
            {
                throw new Exception(string.Format("Entity set too large, max item allowed is {0}", maxItem));
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

        public PagingResultDto<DtoType> GetAll(QueryExpression filter)
        {
            var query = GetQuery();
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

        public PagingResultDto<DtoType> GetUpdate(QueryExpression filter)
        {
            if (filter == null)
            {
                throw new Exception(string.Format(string.Format("Need specify {0} where options", nameof(IDto.LastUpdateTime))));
            }

            var lastUpdateWhereOption = filter.WhereOptions.Find(p => p.PropertyPath == nameof(IDto.LastUpdateTime));
            if (lastUpdateWhereOption == null)
            {
                throw new Exception(string.Format(string.Format("Need specify {0} where options", nameof(IDto.LastUpdateTime))));
            }

            var query = GetQuery();
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
                throw new Exception(string.Format("Entity set too large, max item allowed is {0}", maxItem));
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
        public string Save(List<DtoType> items)
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
                        _context.Entry(entity).State = EntityState.Modified;
                        changedEntities.Add(entity);
                        break;
                    case DtoState.Delete:
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
                        break;
                }
            }

            return SaveChanges(items, changedEntities);
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

        protected abstract DtoType ConvertToDto(EntityType entity);

        protected abstract EntityType ConvertToEntity(DtoType dto);

        protected string GetTableName()
        {
            return typeof(EntityType).Name;
        }
    }
}
