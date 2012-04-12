using System.Collections;
using System.Linq;
using Castle.Windsor;
using UAR.Persistence.Contracts.Scope;
using UAR.UI.Contracts;

namespace UAR.UI.WinForms
{
    /// <summary>
    ///   Keeps and injects scoped references of several types. Currently: IUnitOfWork and IHostingWindow.
    /// </summary>
    internal class ScopeSupporterFactory : IScopeSupporterFactory
    {
        private readonly IWindsorContainer _container;
        private readonly IDictionary _scopeRelatedInstances;

        public ScopeSupporterFactory(IWindsorContainer container)
        {
            _container = container;
            _scopeRelatedInstances = _container.ResolveAll<IScopeRelatedInstance>()
                .ToDictionary(x => x.GeneralParameterName, x => x);
        }

        public T Create<T>()
        {
            return _container.Resolve<T>(_scopeRelatedInstances);
        }
    }
}