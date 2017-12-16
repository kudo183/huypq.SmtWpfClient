using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rLoaiNguyenLieuController : BaseDataController<SqlDbContext, rLoaiNguyenLieu, rLoaiNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiNguyenLieuDto dto, rLoaiNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rLoaiNguyenLieu entity, rLoaiNguyenLieuDto dto);

        public override rLoaiNguyenLieuDto ConvertToDto(rLoaiNguyenLieu entity)
        {
            var dto = new rLoaiNguyenLieuDto()
            {
                ID = entity.ID,
                TenLoai = entity.TenLoai,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiNguyenLieu ConvertToEntity(rLoaiNguyenLieuDto dto)
        {
            var entity = new rLoaiNguyenLieu()
            {
                ID = dto.ID,
                TenLoai = dto.TenLoai,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
