using System;
using System.Linq;
using System.Windows.Forms;
using UAR.Persistence.Contracts;
using UAR.UI.Contracts;

namespace UAR.UI.WinForms
{
    public partial class NW_Dialog : Form
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IScopeSupporterFactory _factory;
        private Test1 _t1;

        public NW_Dialog(IScopeSupporterFactory factory)//(IUnitOfWork unitOfWork, IScopeSupporterFactory factory)
        {
            //_unitOfWork = unitOfWork;
            _factory = factory;
            InitializeComponent();

            Closed += (s, a) =>
            {
                if (_t1 != null)
                    _t1.Dispose();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_t1 != null)
                _factory.Release(_t1);
            _t1 = _factory.Create<Test1>();
        }
    }

    public class Test1 : IDisposable
    {
        public Test1(IUnitOfWork unitOfWork)
        {
        }

        public void Dispose()
        {
        }
    }
}