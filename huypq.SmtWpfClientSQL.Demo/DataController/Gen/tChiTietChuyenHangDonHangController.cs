using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiTietChuyenHangDonHangController : BaseDataController<SqlDbContext, tChiTietChuyenHangDonHang, tChiTietChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietChuyenHangDonHangDto dto, tChiTietChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref tChiTietChuyenHangDonHang entity, tChiTietChuyenHangDonHangDto dto);

        public override tChiTietChuyenHangDonHangDto ConvertToDto(tChiTietChuyenHangDonHang entity)
        {
            var dto = new tChiTietChuyenHangDonHangDto()
            {
                ID = entity.ID,
                MaChuyenHangDonHang = entity.MaChuyenHangDonHang,
                MaChiTietDonHang = entity.MaChiTietDonHang,
                SoLuong = entity.SoLuong,
                SoLuongTheoDonHang = entity.SoLuongTheoDonHang,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietChuyenHangDonHang ConvertToEntity(tChiTietChuyenHangDonHangDto dto)
        {
            var entity = new tChiTietChuyenHangDonHang()
            {
                ID = dto.ID,
                MaChuyenHangDonHang = dto.MaChuyenHangDonHang,
                MaChiTietDonHang = dto.MaChiTietDonHang,
                SoLuong = dto.SoLuong,
                //SoLuongTheoDonHang = dto.SoLuongTheoDonHang,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        protected override void UpdateEntity(SqlDbContext context, tChiTietChuyenHangDonHang entity)
        {
            var entry = context.Entry(entity);
            entry.Property(p => p.SoLuongTheoDonHang).IsModified = false;
        }
    }
}
