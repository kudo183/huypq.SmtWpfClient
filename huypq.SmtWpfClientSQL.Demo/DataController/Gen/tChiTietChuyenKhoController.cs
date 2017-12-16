using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChiTietChuyenKhoController : BaseDataController<SqlDbContext, tChiTietChuyenKho, tChiTietChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietChuyenKhoDto dto, tChiTietChuyenKho entity);
        partial void ConvertToEntityPartial(ref tChiTietChuyenKho entity, tChiTietChuyenKhoDto dto);

        public override tChiTietChuyenKhoDto ConvertToDto(tChiTietChuyenKho entity)
        {
            var dto = new tChiTietChuyenKhoDto()
            {
                ID = entity.ID,
                MaChuyenKho = entity.MaChuyenKho,
                MaMatHang = entity.MaMatHang,
                SoLuong = entity.SoLuong,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietChuyenKho ConvertToEntity(tChiTietChuyenKhoDto dto)
        {
            var entity = new tChiTietChuyenKho()
            {
                ID = dto.ID,
                MaChuyenKho = dto.MaChuyenKho,
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
