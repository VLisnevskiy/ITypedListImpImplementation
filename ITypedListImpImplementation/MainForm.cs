using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using ITypedListImpImplementation.SimpleWCF;
using ITypedListImpImplementation.Entity;

namespace ITypedListImpImplementation
{
    public partial class MainForm : Form
    {
        private XmlTable table;
        private BindingSource bindingSource;

        public MainForm()
        {
            InitializeComponent();
            //PropertyBuilderCollection.Register("xml", new XmlItemPropertyBuilder());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<XmlColumn> columns = new List<XmlColumn>();
            columns.Add(new XmlColumn {FieldName = "Field1", Caption = "Field1 Cap", Type = typeof (string)});
            columns.Add(new XmlColumn {FieldName = "Field2", Caption = "Field2 Cap", Type = typeof (string)});
            columns.Add(new XmlColumn {FieldName = "Field3", Caption = "Field3 Cap", Type = typeof (int)});

            table = new XmlTable(columns, "xml");
            XmlRow row = table.AddNew();
            row[0] = "Some1";
            row["Field2"] = "Some2";
            row["Field3"] = 152;
            row.SetError("Field3", "Less then 5");

            XmlRow row1 = table.AddNew();
            row1["Field1"] = "SomeNew1";
            row1["Field2"] = "SomeNew2";
            row1["Field3"] = 562;
            row1.SetError("Full Row");
            table.RaiseListChangedEvents = true;

            dataGridView1.DataSource = table;
            gridControl1.DataSource = table;

            bindingSource = new BindingSource();
            bindingSource.DataSource = row;
            //bindingSource.CurrencyManager.Position = 0;

            OneRow oneRow = new OneRow(bindingSource);
            oneRow.Show();

            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            label1.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", bindingSource, "Field1", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource, "Field2", false, DataSourceUpdateMode.OnPropertyChanged);
            label1.DataBindings.Add("Text", bindingSource, "Field3");

            stopWatch.Stop();
            label1.Text = string.Format("Tieme: {0}", stopWatch.Elapsed);

            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            table = XmlTable.Load("XmlTable.xml");

            dataGridView1.DataSource = table;

            bindingSource = new BindingSource();
            bindingSource.DataSource = table[0];

            OneRow oneRow = new OneRow(bindingSource);
            oneRow.Show();

            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            label1.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", bindingSource, "Field1", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource, "Field2", false, DataSourceUpdateMode.OnPropertyChanged);
            label1.DataBindings.Add("Text", bindingSource, "Field3");

            stopWatch.Stop();
            label1.Text = string.Format("Tieme: {0}", stopWatch.Elapsed);

            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            label1.Text = "Tieme:";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            DBRepository dbRepository = new DBRepository();
            foreach (CustomFieldSetup customFieldSetup in dbRepository.CustomFieldSetups)
            {
                
            }

            foreach (ProjectItem projectItem in dbRepository.ProjectItems)
            {
                
            }

            using (Service1Client client = new Service1Client())
            {
                Stream res = client.GetXml();

                XmlSerializer serializer = new XmlSerializer(typeof (SerializableContainer<ProjectItem>));
                object ob = serializer.Deserialize(res);

                res = new MemoryStream();
                serializer.Serialize(res, ob);
                res.Position = 0;

                using (res)
                {
                    table = XmlTable.Load(res);
                }

                XDocument doc = new XDocument();
                doc.AddFirst(new XElement("Value"));
                using (Stream st = new MemoryStream())
                {
                    doc.Save(st);
                    st.Position = 0;
                    client.UpdateProjectItems(st);
                }
            }

            dataGridView1.DataSource = table;
            gridControl1.DataSource = table;

            bindingSource = new BindingSource();
            bindingSource.DataSource = table[0];

            /*OneRow oneRow = new OneRow(bindingSource);
            oneRow.Show();

            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            label1.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", bindingSource, "Field1", false, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", bindingSource, "Field2", false, DataSourceUpdateMode.OnPropertyChanged);
            label1.DataBindings.Add("Text", bindingSource, "Field3");*/

            stopWatch.Stop();
            label1.Text = string.Format("Tieme: {0}", stopWatch.Elapsed);

            Cursor.Current = Cursors.Default;
        }
    }
}

