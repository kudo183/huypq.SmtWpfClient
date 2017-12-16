using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tPhuThuKhachHangController : BaseDataController<SqlDbContext, tPhuThuKhachHang, tPhuThuKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tPhuThuKhachHangDto dto, tPhuThuKhachHang entity);
        partial void ConvertToEntityPartial(ref tPhuThuKhachHang entity, tPhuThuKhachHangDto dto);

        public override tPhuThuKhachHangDto ConvertToDto(tPhuThuKhachHang entity)
        {
            var dto = new tPhuThuKhachHangDto()
            {
                ID = entity.ID,
                MaKhachHang = entity.MaKhachHang,
                Ngay = entity.Ngay,
                SoTien = entity.SoTien,
                GhiChu = entity.GhiChu,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tPhuThuKhachHang ConvertToEntity(tPhuThuKhachHangDto dto)
        {
            var entity = new tPhuThuKhachHang()
            {
                ID = dto.ID,
                MaKhachHang = dto.MaKhachHang,
                Ngay = dto.Ngay,
                SoTien = dto.SoTien,
                GhiChu = dto.GhiChu,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
