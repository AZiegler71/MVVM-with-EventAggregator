using System;
using System.Linq;
using System.Windows.Forms;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WinForms
{
    public partial class NW_Dialog : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDialogFactory _dialogFactory;
        private readonly ITest1Factory _factory;

        public NW_Dialog(IUnitOfWork unitOfWork, IDialogFactory dialogFactory, ITest1Factory factory)
        {
            _unitOfWork = unitOfWork;
            _dialogFactory = dialogFactory;
            _factory = factory;
            InitializeComponent();
        }

        private void NW_Dialog_Load(object sender, EventArgs e)
        {
            label1.Text = "kjhjhk"; // _unitOfWork.Entities<Employee>().First().FirstName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test1 t1 = _factory.Create();
        }
    }

    public class Test1
    {
        public Test1(IUnitOfWork unitOfWork)
        {
        }
    }

    public interface ITest1Factory
    {
        Test1 Create();
    }
}