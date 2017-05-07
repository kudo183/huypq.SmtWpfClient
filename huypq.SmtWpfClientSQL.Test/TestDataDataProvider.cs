using huypq.SmtSharedTest;

namespace huypq.SmtWpfClientSQL.Test
{
    public class TestDataDataProvider : BaseDataProvider<Test, TestData, TestDataDto>
    {
        protected override TestDataDto ConvertToDto(TestData entity)
        {
            return new TestDataDto()
            {
                CreateTime = entity.CreateTime,
                Data = entity.Data,
                ID = entity.ID,
                LastUpdateTime = entity.LastUpdateTime,
                TenantID = entity.TenantID
            };
        }

        protected override TestData ConvertToEntity(TestDataDto dto)
        {
            return new TestData()
            {
                CreateTime = dto.CreateTime,
                Data = dto.Data,
                ID = dto.ID,
                LastUpdateTime = dto.LastUpdateTime,
                TenantID = dto.TenantID
            };
        }
    }
}
