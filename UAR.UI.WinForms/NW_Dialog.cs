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
        private readonly IScopeSupporterFactory _dialogFactory;
        private readonly IScopeSupporterFactory _factory;

        public NW_Dialog(IUnitOfWork unitOfWork, IScopeSupporterFactory dialogFactory, IScopeSupporterFactory factory)
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
            Test1 t1 = _factory.Create<Test1>();
        }
    }

    public class Test1
    {
        public Test1(IUnitOfWork unitOfWork)
        {
        }
    }
}