using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rBaiXeController : BaseDataController<SqlDbContext, rBaiXe, rBaiXeDto>
    {
        partial void ConvertToDtoPartial(ref rBaiXeDto dto, rBaiXe entity);
        partial void ConvertToEntityPartial(ref rBaiXe entity, rBaiXeDto dto);

        public override rBaiXeDto ConvertToDto(rBaiXe entity)
        {
            var dto = new rBaiXeDto()
            {
                ID = entity.ID,
                DiaDiemBaiXe = entity.DiaDiemBaiXe,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rBaiXe ConvertToEntity(rBaiXeDto dto)
        {
            var entity = new rBaiXe()
            {
                ID = dto.ID,
                DiaDiemBaiXe = dto.DiaDiemBaiXe,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
