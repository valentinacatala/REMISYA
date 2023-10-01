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
    public partial class Form1 : Form
    {
        DataTable tabla;
        DataRow datos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choferes oChoferes= new Choferes();
            tabla= oChoferes.getChoferes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            datos=tabla.Rows.Find(Convert.ToInt32(textBox1.Text));
            textBox2.Text = datos["nombre"].ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            datos["chofer"]=Convert.ToInt32(textBox1.Text);
            datos["nombre"]=textBox2.Text;
        }
    }
}
