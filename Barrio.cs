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

        public int[] devolverBarrio() //form6 
        {
            //guardar los barrios q se lean en un vector int
            int[] barrios = new int[11];
            int i = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                barrios[i] = int.Parse(fila["barrio"].ToString());
                i++;
            }
            return barrios;
        }

        public void grabar (int barrio,string nombre) 
        {
            //bool ok;

            //try
            //{
            //    DataRow filaBuscada = tabla.Rows.Find(barrio);

            //    if (filaBuscada==null)
            //    {
            //        foreach (DataRow fbar in tabla.Rows)
            //        {
            //            if (fbar["nombre"].ToString()==nombre)
            //            {
            //                ok = false;
            //            }
            //        }

            //        if (ok=true)
            //        {
            //            DataRow fila = tabla.NewRow();
            //            fila["barrio"] = barrio;
            //            fila["nombre"] = nombre;
            //            tabla.Rows.Add(fila);

            //            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            //            adaptador.Update(tabla);
            //        }

            //    }
            //    else
            //    {
            //        ok=false;
            //    }

            //    return ok;
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("ERROR");
            //}

            try
            {
                foreach (DataRow datos in tabla.Rows)
                {
                    try
                    {
                        if (barrio != int.Parse(datos["barrio"].ToString()) && nombre != datos["nombre"].ToString())
                        {
                            tabla.Rows.Add(barrio, nombre);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Numero de barrio existente");
                        break;
                        
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nombre exitente");
                
            }

            OleDbCommandBuilder cb = new OleDbCommandBuilder(adaptador);
            adaptador.Update(tabla);
        }
    }
}
