using huypq.SmtShared.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huypq.SmtWpfClientSQL.Test
{
    public class TestChildDataDataProvider : BaseDataProvider<Test, TestChildData, TestChildDataDto>
    {
        protected override TestChildDataDto ConvertToDto(TestChildData entity)
        {
            return new TestChildDataDto()
            {
                CreateTime = entity.CreateTime,
                Data = entity.Data,
                ID = entity.ID,
                LastUpdateTime = entity.LastUpdateTime,
                TenantID = entity.TenantID,
                TestDataID = entity.TestDataID
            };
        }

        protected override TestChildData ConvertToEntity(TestChildDataDto dto)
        {
            return new TestChildData()
            {
                CreateTime = dto.CreateTime,
                Data = dto.Data,
                ID = dto.ID,
                LastUpdateTime = dto.LastUpdateTime,
                TenantID = dto.TenantID,
                TestDataID = dto.TestDataID
            };
        }
    }
}
