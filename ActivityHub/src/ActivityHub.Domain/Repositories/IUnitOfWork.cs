﻿namespace ActivityHub.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
