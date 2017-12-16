using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tNhapNguyenLieuController : BaseDataController<SqlDbContext, tNhapNguyenLieu, tNhapNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref tNhapNguyenLieuDto dto, tNhapNguyenLieu entity);
        partial void ConvertToEntityPartial(ref tNhapNguyenLieu entity, tNhapNguyenLieuDto dto);

        public override tNhapNguyenLieuDto ConvertToDto(tNhapNguyenLieu entity)
        {
            var dto = new tNhapNguyenLieuDto()
            {
                ID = entity.ID,
                Ngay = entity.Ngay,
                MaNguyenLieu = entity.MaNguyenLieu,
                MaNhaCungCap = entity.MaNhaCungCap,
                SoLuong = entity.SoLuong,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tNhapNguyenLieu ConvertToEntity(tNhapNguyenLieuDto dto)
        {
            var entity = new tNhapNguyenLieu()
            {
                ID = dto.ID,
                Ngay = dto.Ngay,
                MaNguyenLieu = dto.MaNguyenLieu,
                MaNhaCungCap = dto.MaNhaCungCap,
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
