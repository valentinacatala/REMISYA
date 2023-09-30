using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISYA
{
    public partial class Form2 : Form
    {
        DataTable tabla;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Choferes ch = new Choferes();
            tabla = ch.getChoferes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                string d1 = fila["nombre"].ToString().ToUpper();
                string d2 = textBox1.Text.ToUpper();

                int pos = d1.IndexOf(d2);
                if (pos != -1)
                {
                    dataGridView1.Rows.Add(fila["chofer"], fila["nombre"]);
                }

            }
        }
    }
}
