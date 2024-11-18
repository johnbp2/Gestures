using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using JohnBPearson.Application.Model;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.Foundation.Collections;
using System.Text.Json;

namespace JohnBPearson.Windows.Forms.KeyBindingButler
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

            IList<IContainer> list = _sourceList.GetItems();

            IList<Container> containers = new List<Container>();
            foreach(IContainer conntainer in list)
            {
                containers.Add((Container)conntainer);

            }
            dataGridView1.DataSource = containers; //typeof(IContaine

            dataGridView1.Columns.Remove("Data");
            dataGridView1.Columns.Remove("Description");
            var col = dataGridView1.Columns["Alpha"];
            col.ReadOnly = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this._mainPresenter.executeAutoSave(true, "", false);
            this.notify("Saved", "Saved list contents", false, ToastOptions.Save);
            var export = System.Text.Json.JsonSerializer.Serialize<IContainerList>(this._sourceList);
            System.Windows.Clipboard.SetText(export);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var export = System.Text.Json.JsonSerializer.Serialize<IEnumerable<IContainer>>(this._sourceList.Items);
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
                        var containers = doc.Deserialize<List<Container>>();
                       this._sourceList.ImportForSave(containers);
                        this._mainPresenter.executeAutoSave(true, "", false);
                    }
                    //  System.Text.Json.JsonSerializer.Deserialize<Containers[]>()
                }
            }
        }
    }
}