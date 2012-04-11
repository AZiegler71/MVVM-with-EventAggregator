using Castle.Windsor;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WinForms
{
    /// <summary>
    ///   Keeps and injects scoped references of several types. Currently: IUnitOfWork and IHostingWindow.
    /// </summary>
    internal class ScopeSupporterFactory : IScopeSupporterFactory
    {
        private readonly IWindsorContainer _container;
        private readonly IUnitOfWork _unitOfWork;

        public ScopeSupporterFactory(IWindsorContainer container, IUnitOfWork unitOfWork)
        {
            _container = container;
            _unitOfWork = unitOfWork;
        }

        public T Create<T>()
        {
            return _container.Resolve<T>(new
            {
                unitOfWork = _unitOfWork
            });
        }
    }
}
