﻿using System;
using System.Linq;
using System.Windows.Forms;

using UAR.Domain.Northwind;
using UAR.Persistence.Contracts;

namespace UAR.UI.WinForms
{
    public partial class NW_Dialog : Form
    {
        readonly IDisposable _scope;
        readonly IUnitOfWork _unitOfWork;

        public NW_Dialog(IUnitOfWork unitOfWork, IDisposable scope)
        {
            _unitOfWork = unitOfWork;
            _scope = scope;
            InitializeComponent();
        }

        void NW_Dialog_Load(object sender, EventArgs e)
        {
            label1.Text = _unitOfWork.Entities<Employees>().First().FirstName;
        }

        protected override void OnClosed(EventArgs e)
        {
            _scope.Dispose();
            base.OnClosed(e);
        }
    }
}