using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tNhapHangController : BaseDataController<SqlDbContext, tNhapHang, tNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref tNhapHangDto dto, tNhapHang entity);
        partial void ConvertToEntityPartial(ref tNhapHang entity, tNhapHangDto dto);

        public override tNhapHangDto ConvertToDto(tNhapHang entity)
        {
            var dto = new tNhapHangDto()
            {
                ID = entity.ID,
                MaNhanVien = entity.MaNhanVien,
                MaKhoHang = entity.MaKhoHang,
                MaNhaCungCap = entity.MaNhaCungCap,
                Ngay = entity.Ngay,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tNhapHang ConvertToEntity(tNhapHangDto dto)
        {
            var entity = new tNhapHang()
            {
                ID = dto.ID,
                MaNhanVien = dto.MaNhanVien,
                MaKhoHang = dto.MaKhoHang,
                MaNhaCungCap = dto.MaNhaCungCap,
                Ngay = dto.Ngay,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
