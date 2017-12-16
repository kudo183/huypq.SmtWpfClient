using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rKhachHangController : BaseDataController<SqlDbContext, rKhachHang, rKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref rKhachHangDto dto, rKhachHang entity);
        partial void ConvertToEntityPartial(ref rKhachHang entity, rKhachHangDto dto);

        public override rKhachHangDto ConvertToDto(rKhachHang entity)
        {
            var dto = new rKhachHangDto()
            {
                ID = entity.ID,
                MaDiaDiem = entity.MaDiaDiem,
                TenKhachHang = entity.TenKhachHang,
                KhachRieng = entity.KhachRieng,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rKhachHang ConvertToEntity(rKhachHangDto dto)
        {
            var entity = new rKhachHang()
            {
                ID = dto.ID,
                MaDiaDiem = dto.MaDiaDiem,
                TenKhachHang = dto.TenKhachHang,
                KhachRieng = dto.KhachRieng,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
