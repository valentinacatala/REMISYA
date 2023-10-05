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
    public partial class Form3 : Form
    {
        Choferes oChoferes;
        Viajes oViajes;
        DataTable tabla;
        public Form3()
        {
            InitializeComponent();
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            oViajes = new Viajes();
            oChoferes = new Choferes();
            tabla = oViajes.GetData();

            int i = 0;
            decimal total = 0;
            string nombre = "";


            while (i<8)
            {
                //public int en la clase Choferes
                int[] choferes = oChoferes.Chofer();
                int auxChofer = choferes[i];
                foreach (DataRow datos in tabla.Rows)
                {
                    if (auxChofer == int.Parse(datos["chofer"].ToString()))
                    {
                        //"imprimimos" el nombre y el total buscados y guardados en la variable
                        nombre= oChoferes.getNombre(auxChofer);
                        total += Convert.ToDecimal(datos["importe"].ToString());                        
                    }
                    else
                    {
                        //si no hay un totalRecaudado igual imprime el nombre
                        nombre = oChoferes.getNombre(auxChofer);
                    }
                }
                //reiniciamos la tabla, vectores y total
                dataGridView1.Rows.Add(nombre, total);
                i++;
                total = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
