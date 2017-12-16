using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChuyenHangDonHangController : BaseDataController<SqlDbContext, tChuyenHangDonHang, tChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChuyenHangDonHangDto dto, tChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref tChuyenHangDonHang entity, tChuyenHangDonHangDto dto);

        public override tChuyenHangDonHangDto ConvertToDto(tChuyenHangDonHang entity)
        {
            var dto = new tChuyenHangDonHangDto()
            {
                ID = entity.ID,
                MaChuyenHang = entity.MaChuyenHang,
                MaDonHang = entity.MaDonHang,
                TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang,
                TongSoLuongThucTe = entity.TongSoLuongThucTe,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChuyenHangDonHang ConvertToEntity(tChuyenHangDonHangDto dto)
        {
            var entity = new tChuyenHangDonHang()
            {
                ID = dto.ID,
                MaChuyenHang = dto.MaChuyenHang,
                MaDonHang = dto.MaDonHang,
                //TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang,
                //TongSoLuongThucTe = dto.TongSoLuongThucTe,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        protected override void UpdateEntity(SqlDbContext context, tChuyenHangDonHang entity)
        {
            var entry = context.Entry(entity);
            entry.Property(p => p.TongSoLuongTheoDonHang).IsModified = false;
            entry.Property(p => p.TongSoLuongThucTe).IsModified = false;
        }
    }
}
