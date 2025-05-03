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
            this._mainPresenter.executeSave(true, "", false);
            this.notify(this, "Saved", "Saved list contents", false, ToastOptions.Save);
            var export = System.Text.Json.JsonSerializer.Serialize<IContainerList>(this._sourceList);
          //  System.Windows.Clipboard.SetText(export);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var export = System.Text.Json.JsonSerializer.Serialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.Container>>(this._sourceList.MapToEnities());
          //  System.Windows.Clipboard.SetText(export);

            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "json text|*.json";
            saveFileDialog1.Title = "Save all your key bindings to json File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if(saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                using(System.IO.FileStream fs =
                      (System.IO.FileStream)saveFileDialog1.OpenFile())
                {

                    // Saves the Image in the appropriate ImageFormat based upon the
                    // File type selected in the dialog box.
                    // NOTE that the FilterIndex property is one-based.
                    switch(saveFileDialog1.FilterIndex)
                    {

                        case 1:
                            byte[] exportBytes = new UTF8Encoding(true).GetBytes(export);
                            fs.Write(exportBytes, 0, exportBytes.Length);
                            break;
                    }

                    fs.Close();
                }
            }
        }

        private void aLittleBetter_Import_Click(object sender, EventArgs e)
        {
            using(this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog())
            {
                if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using(System.IO.FileStream fs = (FileStream)openFileDialog1.OpenFile())
                    {


                        var doc = System.Text.Json.JsonDocument.Parse(fs);
                        var root = doc.Deserialize<List<JohnBPearson.Application.Gestures.Model.Domain.Entities.Container>>();
                       this._sourceList.MapFromEntities( root);
                        this._mainPresenter.executeSave(true, "", false);
                        this.rebindsource(this._sourceList);
                    }
                    //  System.Text.Json.JsonSerializer.Deserialize<Containers[]>()
                }
            }
        }


        public  void rebindsource(IContainerList newsourceList)
        {
            IList<IContainer> list = newsourceList.GetItems();

            IList<Container> containers = new List<Container>();
            foreach(IContainer conntainer in list)
            {
                containers.Add((Container)conntainer);

            }
            dataGridView1.DataSource = containers;
            safeRemoveDataColumn("Data");
            safeRemoveDataColumn("Description");
            safeRemoveDataColumn("KeyAsChar");

            safeRemoveDataColumn("IsProtected");
            safeRemoveDataColumn("IsDataSecured");
            safeRemoveDataColumn("ObjectState");
        }
            
            
            }
}