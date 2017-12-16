using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rDiaDiemController : BaseDataController<SqlDbContext, rDiaDiem, rDiaDiemDto>
    {
        partial void ConvertToDtoPartial(ref rDiaDiemDto dto, rDiaDiem entity);
        partial void ConvertToEntityPartial(ref rDiaDiem entity, rDiaDiemDto dto);

        public override rDiaDiemDto ConvertToDto(rDiaDiem entity)
        {
            var dto = new rDiaDiemDto()
            {
                ID = entity.ID,
                MaNuoc = entity.MaNuoc,
                Tinh = entity.Tinh,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rDiaDiem ConvertToEntity(rDiaDiemDto dto)
        {
            var entity = new rDiaDiem()
            {
                ID = dto.ID,
                MaNuoc = dto.MaNuoc,
                Tinh = dto.Tinh,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
