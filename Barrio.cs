using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMISYA
{
    internal class Barrio
    {
        OleDbCommand comando;
        OleDbConnection conector;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        public Barrio()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=REMISYA.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Barrios";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["barrio"];
            tabla.PrimaryKey = vec;
        }
        public DataTable GetData()
        {
            return tabla;
        }

        //variable para obtener el nombre del barrio 
        public string nombreBarrio(int numeroBarrio)
        {
            DataRow fila = tabla.Rows.Find(numeroBarrio);
            return fila["nombre"].ToString();

        }
    }
}
