﻿namespace huypq.SmtWpfClientSQL
{
    public interface IEntity
    {
        int ID { get; set; }
        int TenantID { get; set; }
        long CreateTime { get; set; }
        long LastUpdateTime { get; set; }
    }
}
