using System;

namespace UAR.UI.Contracts
{
    public interface IScopeSupporterFactory : IDisposable
    {
        T Create<T>();

        void Release(object instance);
    }
}