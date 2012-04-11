using System;

namespace UAR.UI.Contracts
{
    public interface IViewModelFactory
    {
        T Create<T>() where T : class;
        T Create<T>(object args) where T : class;
    }
}