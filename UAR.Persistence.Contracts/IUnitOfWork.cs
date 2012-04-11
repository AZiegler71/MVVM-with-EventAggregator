using System;
using System.Linq;
using UAR.Persistence.Contracts.Scope;

namespace UAR.Persistence.Contracts
{
    public interface IUnitOfWork : IDisposable, IScopeRelatedInstance
    {

        void Commit();
        TResult ExecuteQuery<TResult, T>(IQuery<TResult, T> query) where T : class;
        void Add<T>(T entity) where T:class;
        void Remove<T>(T entity) where T:class;
        IQueryable<T> Entities<T>() where T:class;
        string GetConnectionString();
    }
}