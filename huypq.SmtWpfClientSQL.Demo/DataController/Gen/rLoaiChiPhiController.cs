using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rLoaiChiPhiController : BaseDataController<SqlDbContext, rLoaiChiPhi, rLoaiChiPhiDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiChiPhiDto dto, rLoaiChiPhi entity);
        partial void ConvertToEntityPartial(ref rLoaiChiPhi entity, rLoaiChiPhiDto dto);

        public override rLoaiChiPhiDto ConvertToDto(rLoaiChiPhi entity)
        {
            var dto = new rLoaiChiPhiDto()
            {
                ID = entity.ID,
                TenLoaiChiPhi = entity.TenLoaiChiPhi,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiChiPhi ConvertToEntity(rLoaiChiPhiDto dto)
        {
            var entity = new rLoaiChiPhi()
            {
                ID = dto.ID,
                TenLoaiChiPhi = dto.TenLoaiChiPhi,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
