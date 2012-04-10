using System.Windows.Forms;

namespace UAR.UI.Contracts
{
    public interface IDialogFactory
    {
        T CreateScoped<T>() where T : Form;
    }
}