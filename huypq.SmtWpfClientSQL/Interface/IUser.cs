﻿namespace huypq.SmtWpfClientSQL
{
    public interface IUser: IEntity, ILogin
    {
        System.DateTime CreateDate { get; set; }
        string UserName { get; set; }
    }
}
