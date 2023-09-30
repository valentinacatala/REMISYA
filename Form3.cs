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
        DataTable tabla;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            foreach (DataRow dr in tabla.Rows)
            {
                string chofer = dr["nombre"].ToString();
                decimal precio = Convert.ToDecimal(dr["precio"]);
                DataRow[] ch = tabla.Select("nombre = '" + chofer + "'");
                if (ch.Length>0)
                {
                    ch[0]["TotalRecaudado"] = Convert.ToDecimal(ch[0]["TotalRecaudado"]) + precio;

                }
                else
                {
                    DataRow drn = tabla.NewRow();
                    drn["NOMBRE"] = ch;
                    drn["TOTAL RECAUDADO"] = precio;
                    tabla.Rows.Add(drn);
                }
            }
            dataGridView1.DataSource= tabla;
        }
    }
}
