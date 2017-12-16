using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rMatHangNguyenLieuController : BaseDataController<SqlDbContext, rMatHangNguyenLieu, rMatHangNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rMatHangNguyenLieuDto dto, rMatHangNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rMatHangNguyenLieu entity, rMatHangNguyenLieuDto dto);

        public override rMatHangNguyenLieuDto ConvertToDto(rMatHangNguyenLieu entity)
        {
            var dto = new rMatHangNguyenLieuDto()
            {
                ID = entity.ID,
                MaMatHang = entity.MaMatHang,
                MaNguyenLieu = entity.MaNguyenLieu,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rMatHangNguyenLieu ConvertToEntity(rMatHangNguyenLieuDto dto)
        {
            var entity = new rMatHangNguyenLieu()
            {
                ID = dto.ID,
                MaMatHang = dto.MaMatHang,
                MaNguyenLieu = dto.MaNguyenLieu,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
