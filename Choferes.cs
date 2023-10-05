using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace REMISYA
{
    internal class Choferes
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        public Choferes()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Choferes";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["chofer"];
            tabla.PrimaryKey = vec;
        }

        public DataTable getChoferes()
        {
            return tabla;
        } 

        public int[] Chofer()
        {
            //creamos un vector para guardar los datos de la tabla choferes
            int[] choferes = new int[8];
            int i = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                //el Parse convierte una cadena (string)
                //en un tipo de datos especifico como num entero
                choferes[i] = int.Parse(fila["chofer"].ToString());
                i++;
            }
            return choferes;
        }
        public string getNombre(int choferes) //buscar el nombre en la tabla choferes
        {
            DataRow fila = tabla.Rows.Find(choferes);
            return fila["nombre"].ToString();
        }
    }
}
