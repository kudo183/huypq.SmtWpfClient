using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tDonHangController : BaseDataController<SqlDbContext, tDonHang, tDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tDonHangDto dto, tDonHang entity);
        partial void ConvertToEntityPartial(ref tDonHang entity, tDonHangDto dto);

        public override tDonHangDto ConvertToDto(tDonHang entity)
        {
            var dto = new tDonHangDto()
            {
                ID = entity.ID,
                MaKhachHang = entity.MaKhachHang,
                MaChanh = entity.MaChanh,
                Ngay = entity.Ngay,
                Xong = entity.Xong,
                MaKhoHang = entity.MaKhoHang,
                TongSoLuong = entity.TongSoLuong,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tDonHang ConvertToEntity(tDonHangDto dto)
        {
            var entity = new tDonHang()
            {
                ID = dto.ID,
                MaKhachHang = dto.MaKhachHang,
                MaChanh = dto.MaChanh,
                Ngay = dto.Ngay,
                //Xong = dto.Xong,
                MaKhoHang = dto.MaKhoHang,
                //TongSoLuong = dto.TongSoLuong,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        protected override void UpdateEntity(SqlDbContext context, tDonHang entity)
        {
            var entry = context.Entry(entity);
            entry.Property(p => p.Xong).IsModified = false;
            entry.Property(p => p.TongSoLuong).IsModified = false;
        }
    }
}
