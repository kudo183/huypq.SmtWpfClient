using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tNhanTienKhachHangController : BaseDataController<SqlDbContext, tNhanTienKhachHang, tNhanTienKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tNhanTienKhachHangDto dto, tNhanTienKhachHang entity);
        partial void ConvertToEntityPartial(ref tNhanTienKhachHang entity, tNhanTienKhachHangDto dto);

        public override tNhanTienKhachHangDto ConvertToDto(tNhanTienKhachHang entity)
        {
            var dto = new tNhanTienKhachHangDto()
            {
                ID = entity.ID,
                MaKhachHang = entity.MaKhachHang,
                Ngay = entity.Ngay,
                SoTien = entity.SoTien,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tNhanTienKhachHang ConvertToEntity(tNhanTienKhachHangDto dto)
        {
            var entity = new tNhanTienKhachHang()
            {
                ID = dto.ID,
                MaKhachHang = dto.MaKhachHang,
                Ngay = dto.Ngay,
                SoTien = dto.SoTien,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
