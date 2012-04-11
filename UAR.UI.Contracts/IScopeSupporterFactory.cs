using System.Windows.Forms;

namespace UAR.UI.Contracts
{
    public interface IScopeSupporterFactory
    {
        T Create<T>();
    }
}