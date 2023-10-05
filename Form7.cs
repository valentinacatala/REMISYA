using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISYA
{
    public partial class Form7 : Form
    {
        Viajes oViajes;
        DataTable tabla;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            oViajes = new Viajes();
            tabla = oViajes.GetData();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int viaje = int.Parse(textBox1.Text);
                DataRow fila= tabla.Rows.Find(viaje);

                if (fila!= null)
                {
                    DateTime fecha = Convert.ToDateTime(fila["fecha"].ToString());
                    dateTimePicker1.Value= fecha;
                    textBox2.Text = fila["km"].ToString();
                    textBox3.Text= fila["importe"].ToString();

                }
                else
                {
                    MessageBox.Show("EL VIAJE NO EXSITE", "ERROR");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("INGRESE UN NUMERO ENTERO", "ERROR");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int viaje = int.Parse(textBox1.Text);
            oViajes.eliminarViaje(viaje);
        }
    }
}
