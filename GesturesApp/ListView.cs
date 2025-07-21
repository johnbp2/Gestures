using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using JohnBPearson.Application.Gestures.Model;

namespace JohnBPearson.Windows.Forms.Gestures
{
    public partial class ListView : BaseForm
    {
        private MainPresenter _mainPresenter;
        private IGestureFactory _sourceList;
        public ListView(IGestureFactory sourceList, MainPresenter presenter)
        {
            InitializeComponent();

            this._mainPresenter = presenter;
            this._sourceList = sourceList;
        }

        private void ListView_Load(object sender, EventArgs e)
        {
            this._mainPresenter.SaveDialog = saveFileDialog1;
            //Gateway gt = new Gateway();

            //IList<IOperator> list = gt.GetOperators();

            //IList<Operator> ds = new List<Operator>();

            //foreach (IOperator op in list)
            //    ds.add((Operator)op);

            //dgv.DataSource = ds;

            //typeof(IContaine
            this.rebindsource(this._sourceList);                            //  if(dataGridView1.Columns[])
           
            //var col = dataGridView1.Columns["Alpha"];
            //col.ReadOnly = true;

        }


        private void safeRemoveDataColumn(string columnName)
        {
          
          var column =  dataGridView1.Columns.GetFirstColumn(new DataGridViewElementStates());
            if(column != null && column.Name == columnName)
            {
          
            }
            for(int i = dataGridView1.Columns.Count - 1; i >= 0; i--)
            {
                DataGridViewColumn col = dataGridView1.Columns[i];
                if(col.Name == columnName)
                {
                    dataGridView1.Columns.Remove(col);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this._mainPresenter.executeSaveAsUserSettings(true);
            this.notify(this, "Saved", "Saved list contents", false, ToastOptions.Save);
            var export = System.Text.Json.JsonSerializer.Serialize<IGestureFactory>(this._sourceList);
          //  System.Windows.Clipboard.SetText(export);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this._mainPresenter.SaveDialog = this.saveFileDialog1;
            this._mainPresenter.executeJsonSave();
        }

        private void aLittleBetter_Import_Click(object sender, EventArgs e)
        {
          //  using(this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog())
            //{
                //if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                  //  System.IO.FileStream fs = (FileStream)openFileDialog1.OpenFile();
                    //        using()
                    //        {


                    //            var doc = System.Text.Json.JsonDocument.Parse(fs);
                    //            var root = doc.Deserialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.GestureDTO>>();
                    //           this._sourceList.MapFromEntities( root);
                    JsonService.Import(_sourceList: this._mainPresenter.ContainerList);
                    this._mainPresenter.executeSaveAsUserSettings(true);
                    this.rebindsource(this._sourceList);
             //   }
                //  System.Text.Json.JsonSerializer.Deserialize<Containers[]>()
         //   }
        }


        public  void rebindsource(IGestureFactory newsourceList)
        {
            IList<IGestureObject> list = newsourceList.GetItems();

            IList<GestureObject> containers = new List<GestureObject>();
            foreach(IGestureObject conntainer in list)
            {
                containers.Add((GestureObject)conntainer);

            }
            dataGridView1.DataSource = containers;
            
            safeRemoveDataColumn("Data");
            safeRemoveDataColumn("Description");
            safeRemoveDataColumn("KeyAsChar");

            safeRemoveDataColumn("Secured");
            safeRemoveDataColumn("IsDataSecured");
            safeRemoveDataColumn("ObjectState");
            int parentWidth = this.transparentFlowPanel1.Width;
            var percentWdth = 100 / dataGridView1.Columns.Count;
               //var columnwidth = parentWidth * percentWdth;
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.FillWeight = percentWdth;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
            
            
            }
}