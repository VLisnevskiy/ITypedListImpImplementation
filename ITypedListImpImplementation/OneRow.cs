using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITypedListImpImplementation
{
    public partial class OneRow : Form
    {
        public BindingSource BindingSource { get; set; }
        public OneRow()
        {
            InitializeComponent();
        }

        public OneRow(BindingSource source) : this()
        {
            BindingSource = source;
            textBox1.DataBindings.Add("Text", BindingSource, "Field1", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
