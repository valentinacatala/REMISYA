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
    public partial class SimulacroParcial : Form
    {
        Choferes oChoferes;
        DataTable dtChoferes;
        Viajes oViajes;
        Barrio oBarrio;
        DataTable dtBarrio;
        DataTable dtViaje;
        public SimulacroParcial()
        {
            InitializeComponent();
        }

        private void SimulacroParcial_Load(object sender, EventArgs e)
        {
            oChoferes = new Choferes();
            dtChoferes = oChoferes.getChoferes();
            oBarrio = new Barrio();
            dtBarrio = oBarrio.GetData();
            oViajes = new Viajes();
            dtViaje = oViajes.GetData();

            //para q por defecto en el txt se encuentre 2023
            textBox1.Text = "2023";

            // Busca y selecciona el mes actual por su nombre en el ComboBox
            int mesActual = DateTime.Now.Month;
            comboBox1.SelectedIndex = mesActual - 1;

            //combobox con los nombres de los choferes
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "chofer";
            comboBox2.DataSource = dtChoferes;

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            

            int AA = 0;
            int MM = 0;

            DateTime fecha;
            Decimal total = 0;

            DataRow fbar;

            string barrio1 = "";
            string barrio2 = "";

            dataGridView1.Rows.Clear();
            foreach (DataRow FVIA in dtViaje.Rows)
            {
                fecha = Convert.ToDateTime(FVIA["fecha"]);
                AA = fecha.Year;
                MM = fecha.Month;

                if (AA.ToString() == textBox1.Text && MM == comboBox1.SelectedIndex + 1 && FVIA["chofer"].ToString() == comboBox2.SelectedValue.ToString())
                {
                    fbar = dtBarrio.Rows.Find(FVIA["desdebarrio"]);
                    barrio1 = fbar["nombre"].ToString();

                    fbar = dtBarrio.Rows.Find(FVIA["hastabarrio"]);
                    barrio2 = fbar["nombre"].ToString();

                    dataGridView1.Rows.Add(FVIA["fecha"], barrio1, barrio2, FVIA["km"], FVIA["importe"]);
                    total = total + Convert.ToDecimal(FVIA["importe"]);
                }

            }
            label4.Text = total.ToString("###,###,##0.00");

        }
    }
}
