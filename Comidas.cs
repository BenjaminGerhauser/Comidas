using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace Comidas
{
    class Comidas
    {
        OleDbConnection conector;
        OleDbCommand comando;
        OleDbDataAdapter adaptador;
        DataTable tabla;
        public Comidas()
        {
            conector = new OleDbConnection("provider=microsoft.jet.oledb.4.0;data source=DEMO.mdb");
            comando = new OleDbCommand();
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Comidas";

            adaptador.Fill(tabla);

            DataColumn[] vec = new DataColumn[1];
            vec[0] = tabla.Columns["comida"];
            tabla.PrimaryKey = vec;
            
        }
        public DataTable getData()
        {
            return tabla;
        }
    }
}
