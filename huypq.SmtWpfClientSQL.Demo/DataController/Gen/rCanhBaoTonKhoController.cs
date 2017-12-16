using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class rCanhBaoTonKhoController : BaseDataController<SqlDbContext, rCanhBaoTonKho, rCanhBaoTonKhoDto>
    {
        partial void ConvertToDtoPartial(ref rCanhBaoTonKhoDto dto, rCanhBaoTonKho entity);
        partial void ConvertToEntityPartial(ref rCanhBaoTonKho entity, rCanhBaoTonKhoDto dto);

        public override rCanhBaoTonKhoDto ConvertToDto(rCanhBaoTonKho entity)
        {
            var dto = new rCanhBaoTonKhoDto()
            {
                ID = entity.ID,
                MaMatHang = entity.MaMatHang,
                MaKhoHang = entity.MaKhoHang,
                TonCaoNhat = entity.TonCaoNhat,
                TonThapNhat = entity.TonThapNhat,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rCanhBaoTonKho ConvertToEntity(rCanhBaoTonKhoDto dto)
        {
            var entity = new rCanhBaoTonKho()
            {
                ID = dto.ID,
                MaMatHang = dto.MaMatHang,
                MaKhoHang = dto.MaKhoHang,
                TonCaoNhat = dto.TonCaoNhat,
                TonThapNhat = dto.TonThapNhat,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
