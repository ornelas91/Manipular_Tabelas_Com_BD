using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipularTabelas
{
    public partial class ManipulandoTabelas : Form
    {
        public ManipulandoTabelas()
        {
            InitializeComponent();
        }

        private void eventosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Eventos Emp;
            Emp = new Eventos();
            Emp.MdiParent = this;
            Emp.Show();
        }

        private void instituiçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instituicoes Emp;
            Emp = new Instituicoes();
            Emp.MdiParent = this;
            Emp.Show();
        }
    }
}
