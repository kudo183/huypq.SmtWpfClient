using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiTietNhapHangController : BaseDataController<SqlDbContext, tChiTietNhapHang, tChiTietNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietNhapHangDto dto, tChiTietNhapHang entity);
        partial void ConvertToEntityPartial(ref tChiTietNhapHang entity, tChiTietNhapHangDto dto);

        public override tChiTietNhapHangDto ConvertToDto(tChiTietNhapHang entity)
        {
            var dto = new tChiTietNhapHangDto()
            {
                ID = entity.ID,
                MaNhapHang = entity.MaNhapHang,
                MaMatHang = entity.MaMatHang,
                SoLuong = entity.SoLuong,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietNhapHang ConvertToEntity(tChiTietNhapHangDto dto)
        {
            var entity = new tChiTietNhapHang()
            {
                ID = dto.ID,
                MaNhapHang = dto.MaNhapHang,
                MaMatHang = dto.MaMatHang,
                SoLuong = dto.SoLuong,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
