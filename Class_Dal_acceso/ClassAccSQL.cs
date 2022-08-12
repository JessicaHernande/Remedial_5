using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Dal_acceso
{
    public class ClassAccSQL
    {
        private string cadConexion;
        private SqlConnection conexGlobal = null;

        public ClassAccSQL(string cadena)
        {
            cadConexion = cadena;
            conexGlobal = new SqlConnection();
        }
        private string AbrirConexion()
        {

            string msj = "";
            conexGlobal.ConnectionString = cadConexion;
            try
            {
                conexGlobal.Open();
                msj = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception f)
            {
                conexGlobal = null;
                msj = "Error: " + f.Message;
            }
            return msj;
        }
        private void CerrarConexion()
        {
            if (conexGlobal != null)
            {
                if (conexGlobal.State == ConnectionState.Open)
                {
                    conexGlobal.Close();
                    conexGlobal.Dispose();
                }
            }
        }

        public bool Modificar(string senteniciaSql, List<SqlParameter> parametros, ref string mensaje)
        {
            bool salida = false;
            SqlCommand carrito = null;
            mensaje = AbrirConexion();

            if (conexGlobal != null)
            {
                carrito = new SqlCommand();
                carrito.CommandText = senteniciaSql;
                carrito.Connection = conexGlobal;
                try
                {
                    foreach (SqlParameter p in parametros)
                        carrito.Parameters.Add(p);

                    carrito.ExecuteNonQuery();
                    salida = true;
                    mensaje = "Se realizo la opereción";
                }
                catch (Exception f)
                {
                    salida = false;
                    mensaje = "ERROR " + f.Message;
                }
            }
            else
            {
                salida = false;
                mensaje = "No hay conexion";
            }
            CerrarConexion();
            return salida;
        }

        public DataTable Consultas(string querySql, List<SqlParameter> listaParametros, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;
            DataTable dataTable = null;

            mensaje = AbrirConexion();

            if (conexGlobal == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conexGlobal;
                try
                {
                    foreach (SqlParameter p in listaParametros)
                        carrito.Parameters.Add(p);

                    contenedor = carrito.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(contenedor);
                    mensaje = "No hay conexion";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    dataTable = null;
                    mensaje = "ERROR" + a.Message;
                }
            }
            CerrarConexion();
            return dataTable;
        }
    }
}
