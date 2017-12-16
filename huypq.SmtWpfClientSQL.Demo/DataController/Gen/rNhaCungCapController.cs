using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rNhaCungCapController : BaseDataController<SqlDbContext, rNhaCungCap, rNhaCungCapDto>
    {
        partial void ConvertToDtoPartial(ref rNhaCungCapDto dto, rNhaCungCap entity);
        partial void ConvertToEntityPartial(ref rNhaCungCap entity, rNhaCungCapDto dto);

        public override rNhaCungCapDto ConvertToDto(rNhaCungCap entity)
        {
            var dto = new rNhaCungCapDto()
            {
                ID = entity.ID,
                TenNhaCungCap = entity.TenNhaCungCap,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNhaCungCap ConvertToEntity(rNhaCungCapDto dto)
        {
            var entity = new rNhaCungCap()
            {
                ID = dto.ID,
                TenNhaCungCap = dto.TenNhaCungCap,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
