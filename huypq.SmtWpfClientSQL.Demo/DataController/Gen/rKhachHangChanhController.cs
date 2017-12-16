using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rKhachHangChanhController : BaseDataController<SqlDbContext, rKhachHangChanh, rKhachHangChanhDto>
    {
        partial void ConvertToDtoPartial(ref rKhachHangChanhDto dto, rKhachHangChanh entity);
        partial void ConvertToEntityPartial(ref rKhachHangChanh entity, rKhachHangChanhDto dto);

        public override rKhachHangChanhDto ConvertToDto(rKhachHangChanh entity)
        {
            var dto = new rKhachHangChanhDto()
            {
                ID = entity.ID,
                MaChanh = entity.MaChanh,
                MaKhachHang = entity.MaKhachHang,
                LaMacDinh = entity.LaMacDinh,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rKhachHangChanh ConvertToEntity(rKhachHangChanhDto dto)
        {
            var entity = new rKhachHangChanh()
            {
                ID = dto.ID,
                MaChanh = dto.MaChanh,
                MaKhachHang = dto.MaKhachHang,
                LaMacDinh = dto.LaMacDinh,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
