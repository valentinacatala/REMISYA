using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace REMISYA
{
    public partial class Form4 : Form
    {
        Viajes oViajes;
        DataTable tabla;
        Choferes oChoferes;
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            oViajes = new Viajes();
            oChoferes = new Choferes();
            tabla = oViajes.GetData();

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            //creamos las variables de las fechas
            DateTime fechaInicio = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime fechaFin = Convert.ToDateTime(dateTimePicker2.Text);

            dataGridView1.Rows.Clear();

            foreach (DataRow datos in tabla.Rows)
            {
                if ((Convert.ToDateTime(datos["fecha"]) >= fechaInicio && Convert.ToDateTime(datos["fecha"]) <= fechaFin))
                {
                    //variable para guardar el nombre q buscamos en la clase choferes
                    string chofer = oChoferes.getNombre(int.Parse(datos["chofer"].ToString()));

                    //variable para encontrar la fecha
                    DateTime fecha = Convert.ToDateTime(datos["fecha"]);

                    //agregar los datos a las columnas de la dgv
                    dataGridView1.Rows.Add(datos["viaje"], fecha.ToString("dd/MM/yyyy"), chofer, datos["importe"]);
                }
            }


        }
    }
}
