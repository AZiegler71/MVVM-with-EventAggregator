using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using UAR.Persistence.Contracts.Scope;
using UAR.UI.Contracts;
using System.Collections;

namespace UAR.UI.WinForms
{
    /// <summary>
    ///   Keeps and injects scoped references of several types. Currently: IUnitOfWork and IHostingWindow.
    /// </summary>
    internal class ScopeSupporterFactory : IScopeSupporterFactory
    {
        private readonly IWindsorContainer _container;
        private readonly IDictionary _scopeRelatedInstances;

        public ScopeSupporterFactory(IWindsorContainer container, IScopeRelatedInstanceFactory scopeRelatedInstanceFactory)
        {
            _container = container;
            _scopeRelatedInstances = scopeRelatedInstanceFactory.CreateScopeRelatedInstances()
                .ToDictionary(x => x.GeneralParameterName, x => x);
        }

        public T Create<T>()
        {
            return _container.Resolve<T>(_scopeRelatedInstances);
        }
    }
}