﻿namespace huypq.SmtWpfClientSQL
{
    public interface IFileEntity : IEntity
    {
        string FileName { get; set; }
        string MimeType { get; set; }
        long FileSize { get; set; }
    }
}
