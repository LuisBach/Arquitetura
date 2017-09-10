﻿namespace TudoFilmes.Authorization.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
