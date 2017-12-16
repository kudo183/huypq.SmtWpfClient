using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tChuyenKhoController : BaseDataController<SqlDbContext, tChuyenKho, tChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref tChuyenKhoDto dto, tChuyenKho entity);
        partial void ConvertToEntityPartial(ref tChuyenKho entity, tChuyenKhoDto dto);

        public override tChuyenKhoDto ConvertToDto(tChuyenKho entity)
        {
            var dto = new tChuyenKhoDto()
            {
                ID = entity.ID,
                MaNhanVien = entity.MaNhanVien,
                MaKhoHangXuat = entity.MaKhoHangXuat,
                MaKhoHangNhap = entity.MaKhoHangNhap,
                Ngay = entity.Ngay,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChuyenKho ConvertToEntity(tChuyenKhoDto dto)
        {
            var entity = new tChuyenKho()
            {
                ID = dto.ID,
                MaNhanVien = dto.MaNhanVien,
                MaKhoHangXuat = dto.MaKhoHangXuat,
                MaKhoHangNhap = dto.MaKhoHangNhap,
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
