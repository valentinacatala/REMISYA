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
    public partial class Form8 : Form
    {
        Barrio oBarrio;
        DataTable tabla;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            oBarrio = new Barrio();
            tabla = oBarrio.GetData();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int barrio = int.Parse(textBox1.Text);
            string nombre = textBox2.Text;

            oBarrio.grabar(barrio, nombre);
        }
    }
}
