using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rNhanVienController : BaseDataController<SqlDbContext, rNhanVien, rNhanVienDto>
    {
        partial void ConvertToDtoPartial(ref rNhanVienDto dto, rNhanVien entity);
        partial void ConvertToEntityPartial(ref rNhanVien entity, rNhanVienDto dto);

        public override rNhanVienDto ConvertToDto(rNhanVien entity)
        {
            var dto = new rNhanVienDto()
            {
                ID = entity.ID,
                MaPhuongTien = entity.MaPhuongTien,
                TenNhanVien = entity.TenNhanVien,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNhanVien ConvertToEntity(rNhanVienDto dto)
        {
            var entity = new rNhanVien()
            {
                ID = dto.ID,
                MaPhuongTien = dto.MaPhuongTien,
                TenNhanVien = dto.TenNhanVien,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
