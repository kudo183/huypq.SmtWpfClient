using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiTietDonHangController : BaseDataController<SqlDbContext, tChiTietDonHang, tChiTietDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietDonHangDto dto, tChiTietDonHang entity);
        partial void ConvertToEntityPartial(ref tChiTietDonHang entity, tChiTietDonHangDto dto);

        public override tChiTietDonHangDto ConvertToDto(tChiTietDonHang entity)
        {
            var dto = new tChiTietDonHangDto()
            {
                ID = entity.ID,
                MaDonHang = entity.MaDonHang,
                MaMatHang = entity.MaMatHang,
                SoLuong = entity.SoLuong,
                Xong = entity.Xong,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietDonHang ConvertToEntity(tChiTietDonHangDto dto)
        {
            var entity = new tChiTietDonHang()
            {
                ID = dto.ID,
                MaDonHang = dto.MaDonHang,
                MaMatHang = dto.MaMatHang,
                SoLuong = dto.SoLuong,
                //Xong = dto.Xong,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        protected override void UpdateEntity(SqlDbContext context, tChiTietDonHang entity)
        {
            var entry = context.Entry(entity);
            entry.Property(p => p.Xong).IsModified = false;
        }
    }
}
