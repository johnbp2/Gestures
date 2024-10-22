using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows.Media.TextFormatting;
using JohnBPearson.KeyBindingButler.Model;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Foundation.Collections;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public partial class ListView : BaseForm
    {
        private MainPresenter    _mainPresenter;
        private IContainerList _sourceList;
        public ListView(IContainerList sourceList, MainPresenter presenter)
        {
            InitializeComponent();

            this._mainPresenter = presenter;
            this._sourceList = sourceList;
        }

        private void ListView_Load(object sender, EventArgs e)
        {

            //Gateway gt = new Gateway();

            //IList<IOperator> list = gt.GetOperators();

            //IList<Operator> ds = new List<Operator>();

            //foreach (IOperator op in list)
            //    ds.add((Operator)op);

            //dgv.DataSource = ds;

            IList<IContainer> list = _sourceList.GetItems();

            IList<Container> containers  = new List<Container>();
            foreach (IContainer conntainer in list)
            {
                containers.Add((Container)conntainer);

            }
            dataGridView1.DataSource = containers; //typeof(IContaine

            dataGridView1.Columns.Remove("Data");
            dataGridView1.Columns.Remove("Description");
        var col =    dataGridView1.Columns["Key"];
            col.ReadOnly     = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._mainPresenter.executeAutoSave(true, "", false);
            this.notify("Saved", "Saved list contents", false, ToastOptions.Save);
        }
    }
}