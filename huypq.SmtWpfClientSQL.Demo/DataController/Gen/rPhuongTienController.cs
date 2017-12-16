using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rPhuongTienController : BaseDataController<SqlDbContext, rPhuongTien, rPhuongTienDto>
    {
        partial void ConvertToDtoPartial(ref rPhuongTienDto dto, rPhuongTien entity);
        partial void ConvertToEntityPartial(ref rPhuongTien entity, rPhuongTienDto dto);

        public override rPhuongTienDto ConvertToDto(rPhuongTien entity)
        {
            var dto = new rPhuongTienDto()
            {
                ID = entity.ID,
                TenPhuongTien = entity.TenPhuongTien,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rPhuongTien ConvertToEntity(rPhuongTienDto dto)
        {
            var entity = new rPhuongTien()
            {
                ID = dto.ID,
                TenPhuongTien = dto.TenPhuongTien,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
