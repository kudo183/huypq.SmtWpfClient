using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tCongNoKhachHangController : BaseDataController<SqlDbContext, tCongNoKhachHang, tCongNoKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tCongNoKhachHangDto dto, tCongNoKhachHang entity);
        partial void ConvertToEntityPartial(ref tCongNoKhachHang entity, tCongNoKhachHangDto dto);

        public override tCongNoKhachHangDto ConvertToDto(tCongNoKhachHang entity)
        {
            var dto = new tCongNoKhachHangDto()
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

        public override tCongNoKhachHang ConvertToEntity(tCongNoKhachHangDto dto)
        {
            var entity = new tCongNoKhachHang()
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
