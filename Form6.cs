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
    public partial class Form6 : Form
    {
        Viajes oViaje;
        Barrio oBarrio;
        DataTable tabla;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            oBarrio = new Barrio();
            tabla = oViaje.GetData();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //"cantViajes" se encuentra en la clase viajes
            if (radioButton1.Checked)
            {
                string opcion = "desdebarrio";
                oViaje.cantViajes(dataGridView1, opcion);

            }
            else
            {
                string opcion = "hastabarrio";
                oViaje.cantViajes(dataGridView1, opcion);
            }
        }
    }
}
