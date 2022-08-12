using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Dal_acceso;
using ClassEntidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ClassLogicaNegocios
{
    public class LN
    {
        private ClassAccSQL acceso;
        public LN() //Constructor
        {
            acceso = new ClassAccSQL(ConfigurationManager.ConnectionStrings["conlocal"].ToString());
        }

        //Metodo Ver Usuario 
        public DataTable VerConexion()
        {
            string msj = "";
            string query = @"SELECT
            CONCAT(Cliente.Nombre + ' ', Cliente.App + ' ', Cliente.ApM ) as 'Nombre del cliente',
            Automovil.Modelo,
            Automovil.año,
            Marcas.Marca,
            Mecanico.Nombre as 'Nombre Mecanico',
            Fecha_Entra,
            DescripcionFalla
            FROM
            Conexion
            INNER JOIN Mecanico on (Conexion.Mecanic = Mecanico.id_Tecnico)
            INNER JOIN Marcas on (Conexion.Marc = Marcas.id_marca)
            INNER JOIN Automovil on (Conexion.Aut = Automovil.id_Auto)
            INNER JOIN Cliente on (Conexion.Client = Cliente.id_cliente)
;";
            List<SqlParameter> listaP = new List<SqlParameter>();
            return acceso.Consultas(query, listaP, ref msj);
        }

        public bool CrearConexion(Conexion nuevo)
        {
            string msj = "";
            string query = "insert into Conexion values(@Client,@Aut,@Marc,@Mecanic,@Fecha_Entra,@DescripcionFalla)";
            List<SqlParameter> listaP = new List<SqlParameter>();
            listaP.Add(new SqlParameter("@Client", nuevo.Client));
            listaP.Add(new SqlParameter("@Aut", nuevo.Aut));
            listaP.Add(new SqlParameter("@Marc", nuevo.Marc));
            listaP.Add(new SqlParameter("@Mecanic", nuevo.Mecanic));
            listaP.Add(new SqlParameter("@Fecha_Entra", nuevo.Fecha_Entra));
            listaP.Add(new SqlParameter("@DescripcionFalla", nuevo.DescripcionFalla));
            return acceso.Modificar(query, listaP, ref msj);
        }


        public DataTable VerAutomovil()
        {
            string msj = "";
            string query = "SELECT * FROM Automovil;";
            List<SqlParameter> listaP = new List<SqlParameter>();
            return acceso.Consultas(query, listaP, ref msj);
        }

        public DataTable VerCliente()
        {
            string msj = "";
            string query = "SELECT * FROM Cliente;";
            List<SqlParameter> listaP = new List<SqlParameter>();
            return acceso.Consultas(query, listaP, ref msj);
        }

        public DataTable VerMarcas()
        {
            string msj = "";
            string query = "SELECT * FROM Marcas;";
            List<SqlParameter> listaP = new List<SqlParameter>();
            return acceso.Consultas(query, listaP, ref msj);
        }

        public DataTable VerMecanico()
        {
            string msj = "";
            string query = "SELECT * FROM Mecanico;";
            List<SqlParameter> listaP = new List<SqlParameter>();
            return acceso.Consultas(query, listaP, ref msj);
        }

    }
}
