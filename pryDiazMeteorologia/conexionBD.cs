using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace pryDiazMeteorologia
{
    public class conexionBD
    {
        private OleDbConnection conexion;

        public conexionBD()
        {
            string cadena = "Provider=Microsoft.ACE.OLEDB.12.0 ;Data Source= ../../../BD/Meteorologia.accdb";
            conexion = new OleDbConnection(cadena);
        }

        private DataTable EjecutarConsulta(string consulta, params OleDbParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexion.Open();
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                if (parametros != null)
                    comando.Parameters.AddRange(parametros);

                OleDbDataAdapter adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(tabla);
            }
            catch (Exception ex) 
            {
                System.Windows.Forms.MessageBox.Show("Error en la consulta" + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return tabla;
        }

        //Provincias
        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> lista = new List<Provincia>();
            string sql = "SELECT Id, nombreProvincia FROM Provincias ORDER BY nombreProvincia";
            DataTable tabla = EjecutarConsulta(sql);

            foreach (DataRow fila in tabla.Rows)
            {
                Provincia p = new Provincia
                {
                    IdProvincia = Convert.ToInt32(fila["Id"]),
                    NombreProvincia = fila["nombreProvincia"].ToString()
                };
                lista.Add(p);
            }
            return lista;
        }

        //Localidades
        public List<Localidad> ObtenerLocalidades(int idProvincia)
        {
            List<Localidad> lista = new List<Localidad>();
            string sql = "SELECT Id, nombreLocalidad FROM Localidad WHERE idProvincia = @idProvincia";
            DataTable tabla = EjecutarConsulta(sql, new OleDbParameter("@idProvincia", idProvincia));

            foreach (DataRow fila in tabla.Rows)
            {
                Localidad l = new Localidad
                {
                    IdLocalidad = Convert.ToInt32(fila["Id"]),
                    NombreLocalidad = fila["nombreLocalidad"].ToString(),
                    IdProvincia = idProvincia
                };
                lista.Add(l);
            }
            return lista;
        }

        //Temperaturas por localidad y fecha
        public Temperatura ObtenerTemperaturaLocalidad(int idLocalidad, DateTime fecha)
        {
            string sql = "SELECT TempMin, TempMax FROM Temperaturas WHERE idLocalidad = ? AND Fecha = ?";
            DataTable tabla = EjecutarConsulta(sql,
                new OleDbParameter("@idLocalidad", idLocalidad),
                new OleDbParameter("@Fecha", fecha));

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                return new Temperatura
                {
                    IdLocalidad = idLocalidad,
                    Fecha = fecha,
                    TempMin = Convert.ToDouble(fila["TempMin"]),
                    TempMax = Convert.ToDouble(fila["TempMax"])
                };
            }
            else
                return null;
        }

        //Temperaturas de todas las localidades de una provincia en una fecha
        public List<Temperatura> ObtenerTemperaturasProvincia(int idProvincia, DateTime fecha)
        {
            List<Temperatura> lista = new List<Temperatura>();
            string sql = @"SELECT T.idLocalidad, T.TempMin, T.TempMax 
                           FROM Temperaturas T
                           INNER JOIN Localidad L ON L.Id = T.idLocalidad
                           WHERE L.idProvincia = ? AND T.Fecha = ?";

            DataTable tabla = EjecutarConsulta(sql,
                new OleDbParameter("@idProvincia", idProvincia),
                new OleDbParameter("@Fecha", fecha));

            foreach (DataRow fila in tabla.Rows)
            {
                Temperatura t = new Temperatura
                {
                    IdLocalidad = Convert.ToInt32(fila["idLocalidad"]),
                    Fecha = fecha,
                    TempMin = Convert.ToDouble(fila["TempMin"]),
                    TempMax = Convert.ToDouble(fila["TempMax"])
                };
                lista.Add(t);
            }
            return lista;
        }
    }
}

