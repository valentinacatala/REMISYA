using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMISYA
{
    internal class Viajes
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        public Viajes()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Viajes";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["viaje"];
            tabla.PrimaryKey = vec;
        }
        public DataTable GetData() 
        {
            return tabla;
        }

        Barrio oBarrio;
        public void cantViajes(DataGridView grilla, string opcion)
        {
            oBarrio = new Barrio();

            //crear variables y vectores para guardar datos
            int i = 0, cant = 0, f = 0;
            DataRow fila = tabla.Rows[0];
            string nombre = "";

            grilla.Rows.Clear();

            while (i<11)
            {
                int[] Barrios = oBarrio.devolverBarrio(); //devolverBarrio en la clase Barrios
                int auxBarrio = Barrios[i];

                foreach (DataRow dr in tabla.Rows) 
                {
                    if (auxBarrio == int.Parse(dr[$"{opcion}"].ToString()))
                    {
                        nombre = oBarrio.nombreBarrio(auxBarrio);
                        cant++;
                    }
                }

                grilla.Rows.Add(nombre,cant);
                i++;
                cant = 0;
            }
        }

        public void eliminarViaje(int viaje) //form 7 btnEliminar
        {
            DataRow fila = tabla.Rows.Find(viaje);

            int i = tabla.Rows.IndexOf(fila);
            tabla.Rows.RemoveAt(i);

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);
        }
    }
}
