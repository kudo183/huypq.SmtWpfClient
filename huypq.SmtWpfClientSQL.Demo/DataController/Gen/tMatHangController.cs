using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.Entities;

namespace huypq.SmtWpfClientSQL.Demo.DataController
{
    public partial class tMatHangController : BaseDataController<SqlDbContext, tMatHang, tMatHangDto>
    {
        partial void ConvertToDtoPartial(ref tMatHangDto dto, tMatHang entity);
        partial void ConvertToEntityPartial(ref tMatHang entity, tMatHangDto dto);

        public override tMatHangDto ConvertToDto(tMatHang entity)
        {
            var dto = new tMatHangDto()
            {
                ID = entity.ID,
                MaLoai = entity.MaLoai,
                TenMatHang = entity.TenMatHang,
                SoKy = entity.SoKy,
                SoMet = entity.SoMet,
                TenMatHangDayDu = entity.TenMatHangDayDu,
                TenMatHangIn = entity.TenMatHangIn,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime,
                MaHinhAnh = entity.MaHinhAnh
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tMatHang ConvertToEntity(tMatHangDto dto)
        {
            var entity = new tMatHang()
            {
                ID = dto.ID,
                MaLoai = dto.MaLoai,
                TenMatHang = dto.TenMatHang,
                SoKy = dto.SoKy,
                SoMet = dto.SoMet,
                TenMatHangDayDu = dto.TenMatHangDayDu,
                TenMatHangIn = dto.TenMatHangIn,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime,
                MaHinhAnh = dto.MaHinhAnh
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

    }
}
