using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiTietToaHangController : BaseDataController<SqlDbContext, tChiTietToaHang, tChiTietToaHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietToaHangDto dto, tChiTietToaHang entity);
        partial void ConvertToEntityPartial(ref tChiTietToaHang entity, tChiTietToaHangDto dto);

        public override tChiTietToaHangDto ConvertToDto(tChiTietToaHang entity)
        {
            var dto = new tChiTietToaHangDto()
            {
                ID = entity.ID,
                MaToaHang = entity.MaToaHang,
                MaChiTietDonHang = entity.MaChiTietDonHang,
                GiaTien = entity.GiaTien,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietToaHang ConvertToEntity(tChiTietToaHangDto dto)
        {
            var entity = new tChiTietToaHang()
            {
                ID = dto.ID,
                MaToaHang = dto.MaToaHang,
                MaChiTietDonHang = dto.MaChiTietDonHang,
                GiaTien = dto.GiaTien,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
