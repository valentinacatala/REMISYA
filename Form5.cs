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
    public partial class Form5 : Form
    {
        Choferes oChoferes;
        DataTable dtChoferes;
        Viajes oViajes;
        Barrio oBarrio;
        DataTable dtViaje;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            oChoferes = new Choferes();
            dtChoferes=oChoferes.getChoferes();
            oBarrio = new Barrio();
            oViajes = new Viajes();
            dtViaje=oViajes.GetData();

            listBox1.DisplayMember = "nombre";
            listBox1.ValueMember = "chofer";
            listBox1.DataSource= dtChoferes;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow fila in dtViaje.Rows)
            {
                //si el chofer seleccionado en el listbox es igual al de la tabla..
                if (fila["chofer"].ToString() == listBox1.SelectedValue.ToString())
                {
                    //variable para guardar el nombre del barrio encontrado y la fecha
                    string desdeBarrio = oBarrio.nombreBarrio(int.Parse(fila["desdebarrio"].ToString()));
                    string hastaBarrio = oBarrio.nombreBarrio(int.Parse(fila["hastabarrio"].ToString()));
                    DateTime fecha = Convert.ToDateTime(fila["fecha"].ToString());

                    dataGridView1.Rows.Add(fecha.ToString("dd/MM/yyyy"), desdeBarrio, hastaBarrio, fila["km"], fila["importe"]);
                }
            }
            
        }
    }
}
