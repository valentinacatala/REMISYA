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
    public partial class Form10 : Form
    {
        Viajes oViajes;
        Choferes oChoferes;
        DataTable tabla;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            oViajes = new Viajes();
            oChoferes = new Choferes();
            tabla = oViajes.GetData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(dateTimePicker1.Text);
            int[] choferes = oChoferes.Chofer();
            int[] chofer = new int[choferes.Length];
            string mensaje;

            int numChofer = 0;
            int i = 0;

            while (i<choferes.Length)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    if (fecha == Convert.ToDateTime(fila["fecha"]))
                    {
                        if (choferes[i]== int.Parse(fila["chofer"].ToString()))
                        {
                            numChofer = -1;
                            break;
                        }
                        else
                        {
                            numChofer = choferes[i];
                        }
                    }
                    else
                    {
                        numChofer = choferes[i];
                    }
                }
                chofer[i] = numChofer;
                i++;
            }

            listBox1.Items.Clear();

            for (int f = 0; f < chofer.Length; f++)
            {
                if (chofer[f] != -1 && chofer[f] != 0)
                {
                    string nombre = oChoferes.getNombre(chofer[f]);
                    listBox1.Items.Add(nombre);
                }
            }
        }
    }
}
