using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiPhiController : BaseDataController<SqlDbContext, tChiPhi, tChiPhiDto>
    {
        partial void ConvertToDtoPartial(ref tChiPhiDto dto, tChiPhi entity);
        partial void ConvertToEntityPartial(ref tChiPhi entity, tChiPhiDto dto);

        public override tChiPhiDto ConvertToDto(tChiPhi entity)
        {
            var dto = new tChiPhiDto()
            {
                ID = entity.ID,
                MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang,
                MaLoaiChiPhi = entity.MaLoaiChiPhi,
                SoTien = entity.SoTien,
                Ngay = entity.Ngay,
                GhiChu = entity.GhiChu,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiPhi ConvertToEntity(tChiPhiDto dto)
        {
            var entity = new tChiPhi()
            {
                ID = dto.ID,
                MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang,
                MaLoaiChiPhi = dto.MaLoaiChiPhi,
                SoTien = dto.SoTien,
                Ngay = dto.Ngay,
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
