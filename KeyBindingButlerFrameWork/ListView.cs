using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using JohnBPearson.KeyBindingButler.Model;
using Windows.Foundation.Collections;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
{
    public partial class ListView : BaseForm
    {

        private IContainerList _sourceList;
        public ListView(IContainerList sourceList)
        {
            InitializeComponent();
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
            dataGridView1.DataSource = containers; //typeof(IContainer)
               
            

        }
    }
}
