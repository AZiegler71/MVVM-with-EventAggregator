using Castle.Windsor;
using UAR.UI.Contracts;

namespace UAR.UI.WPF
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IWindsorContainer _container;

        public ViewModelFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public T Create<T>() where T : class
        {
            return Create<T>(new object());
        }

        public T Create<T>(object args) where T : class
        {
            return _container.Resolve<T>(args);
        }
    }
}