using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tToaHangController : BaseDataController<SqlDbContext, tToaHang, tToaHangDto>
    {
        partial void ConvertToDtoPartial(ref tToaHangDto dto, tToaHang entity);
        partial void ConvertToEntityPartial(ref tToaHang entity, tToaHangDto dto);

        public override tToaHangDto ConvertToDto(tToaHang entity)
        {
            var dto = new tToaHangDto()
            {
                ID = entity.ID,
                Ngay = entity.Ngay,
                MaKhachHang = entity.MaKhachHang,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tToaHang ConvertToEntity(tToaHangDto dto)
        {
            var entity = new tToaHang()
            {
                ID = dto.ID,
                Ngay = dto.Ngay,
                MaKhachHang = dto.MaKhachHang,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
