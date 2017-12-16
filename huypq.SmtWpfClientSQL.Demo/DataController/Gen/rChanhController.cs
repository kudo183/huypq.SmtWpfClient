using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rChanhController : BaseDataController<SqlDbContext, rChanh, rChanhDto>
    {
        partial void ConvertToDtoPartial(ref rChanhDto dto, rChanh entity);
        partial void ConvertToEntityPartial(ref rChanh entity, rChanhDto dto);

        public override rChanhDto ConvertToDto(rChanh entity)
        {
            var dto = new rChanhDto()
            {
                ID = entity.ID,
                MaBaiXe = entity.MaBaiXe,
                TenChanh = entity.TenChanh,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rChanh ConvertToEntity(rChanhDto dto)
        {
            var entity = new rChanh()
            {
                ID = dto.ID,
                MaBaiXe = dto.MaBaiXe,
                TenChanh = dto.TenChanh,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
