using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rLoaiHangController : BaseDataController<SqlDbContext, rLoaiHang, rLoaiHangDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiHangDto dto, rLoaiHang entity);
        partial void ConvertToEntityPartial(ref rLoaiHang entity, rLoaiHangDto dto);

        public override rLoaiHangDto ConvertToDto(rLoaiHang entity)
        {
            var dto = new rLoaiHangDto()
            {
                ID = entity.ID,
                TenLoai = entity.TenLoai,
                HangNhaLam = entity.HangNhaLam,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiHang ConvertToEntity(rLoaiHangDto dto)
        {
            var entity = new rLoaiHang()
            {
                ID = dto.ID,
                TenLoai = dto.TenLoai,
                HangNhaLam = dto.HangNhaLam,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
