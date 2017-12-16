using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rNguyenLieuController : BaseDataController<SqlDbContext, rNguyenLieu, rNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rNguyenLieuDto dto, rNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rNguyenLieu entity, rNguyenLieuDto dto);

        public override rNguyenLieuDto ConvertToDto(rNguyenLieu entity)
        {
            var dto = new rNguyenLieuDto()
            {
                ID = entity.ID,
                MaLoaiNguyenLieu = entity.MaLoaiNguyenLieu,
                DuongKinh = entity.DuongKinh,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNguyenLieu ConvertToEntity(rNguyenLieuDto dto)
        {
            var entity = new rNguyenLieu()
            {
                ID = dto.ID,
                MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu,
                DuongKinh = dto.DuongKinh,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
