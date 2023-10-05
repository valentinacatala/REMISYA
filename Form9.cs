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
    public partial class Form9 : Form
    {
        Viajes oViaje;
        Choferes oChoferes;
        DataTable tabla;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            oViaje = new Viajes();
            oChoferes = new Choferes();
            tabla = oViaje.GetData();

            int cantViajes = 0;

            foreach (DataRow fila in tabla.Rows)
            {
                cantViajes++;
            }

            DateTime auxFecha = Convert.ToDateTime(tabla.Rows[0]["fecha"].ToString());
            int indice;
            string[] fecha = new string[42];

            for (int i = 0; i < cantViajes; i++)
            {
                foreach (DataRow datos in tabla.Rows)
                {
                    fecha[i] = null;
                    if (auxFecha== Convert.ToDateTime(datos["fecha"]))
                    {
                        fecha[i] = datos["fecha"].ToString();
                    }
                    else
                    {
                        fecha[i] = null;
                    }
                }
            }
            for (int i = 0; i < fecha.Length; i++)
            {
                if (fecha[i]!=null)
                {
                    comboBox1.Items.Add(fecha[i]);
                }
            }
        }
    }
}
