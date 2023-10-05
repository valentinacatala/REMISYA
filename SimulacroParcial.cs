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
            oViajes = new Viajes();
            dtViaje = oViajes.GetData();

            //para q por defecto en el txt se encuentre 2023
            textBox1.Text = "2023"; 

            // Busca y selecciona el mes actual por su nombre en el ComboBox
            string nombreMesActual = DateTime.Now.ToString("MMMM");
            int indice = comboBox1.FindStringExact(nombreMesActual);
            if (indice != -1)
            {
                comboBox1.SelectedIndex = indice;
            }

            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "chofer";
            comboBox2.DataSource = dtChoferes;

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            
        }
    }
}
