using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LogIn_Registros
{
    internal class Mantenimiento
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private string cadena = "Data Source=ServerName;Initial Catalog=NombreDataBase;Integrated Security= True";
        private void Conectar()
        {
            conexion = new SqlConnection(cadena);
        }
        public void AltaUsuario(Usuario user)
        {
            Conectar();
            comando = new SqlCommand("insert into usuarios (nombre,clave) values (@nombre,@clave)", conexion);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@clave", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = user.nombre;
            comando.Parameters["@clave"].Value = user.clave;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public Usuario LeerUsuario(string nombre)
        {
            Conectar();
            comando = new SqlCommand("select nombre,clave from usuarios where nombre=@nombre", conexion);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = nombre;
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Usuario user = new Usuario();
            if (registro.Read())
            {
                user.nombre = registro["nombre"].ToString();
                user.clave = registro["clave"].ToString();
            }
            conexion.Close();
            return user;
        }
        public void AltaRegistro(string usuario, Persona per)
        {
            Conectar();
            comando = new SqlCommand("insert into nomina (dni,nombre,domicilio,fechanac,fechaing,puesto,salario,usuario) values (@dni,@nombre,@domicilio,@fechanac,@fechaing,@puesto,@salario,@usuario)", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@domicilio", SqlDbType.VarChar);
            comando.Parameters.Add("@fechanac", SqlDbType.Date);
            comando.Parameters.Add("@fechaing", SqlDbType.Date);
            comando.Parameters.Add("@puesto", SqlDbType.VarChar);
            comando.Parameters.Add("@salario", SqlDbType.Int);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = per.dni;
            comando.Parameters["@nombre"].Value = per.nombre;
            comando.Parameters["@domicilio"].Value = per.domicilio;
            comando.Parameters["@fechanac"].Value = per.fechanac;
            comando.Parameters["@fechaing"].Value = per.fechaing;
            comando.Parameters["@puesto"].Value = per.puesto;
            comando.Parameters["@salario"].Value = per.salario;
            comando.Parameters["@usuario"].Value = usuario;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public Persona LeerRegistro(string dni, string usuario)
        {
            Conectar();
            comando = new SqlCommand("select nombre,domicilio,fechanac,fechaing,puesto,salario from nomina where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            conexion.Open();
            SqlDataReader registro = comando.ExecuteReader();
            Persona pers = new Persona();
            if (registro.Read())
            {
                pers.nombre = registro["nombre"].ToString();
                pers.domicilio = registro["domicilio"].ToString();
                pers.fechanac = DateTime.Parse(registro["fechanac"].ToString());
                pers.fechaing = DateTime.Parse(registro["fechaing"].ToString());
                pers.puesto = registro["puesto"].ToString();
                pers.salario = int.Parse(registro["salario"].ToString());
                pers.dni = dni;
            }
            conexion.Close();
            return pers;
        }
        public List<Persona> LeerTodo(string usuario)
        {
            Conectar();
            List<Persona> lista = new List<Persona>();
            comando = new SqlCommand("select nombre,domicilio,fechanac,fechaing,puesto,salario,dni from nomina where usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            conexion.Open();
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Persona pers = new Persona
                {
                    dni = registros["dni"].ToString(),
                    nombre = registros["nombre"].ToString(),
                    domicilio = registros["domicilio"].ToString(),
                    fechanac = DateTime.Parse(registros["fechanac"].ToString()),
                    fechaing = DateTime.Parse(registros["fechaing"].ToString()),
                    puesto = registros["puesto"].ToString(),
                    salario = int.Parse(registros["salario"].ToString())
                };
                lista.Add(pers);
            }
            conexion.Close();
            return lista;
        }
        public void ModificarNombre(string dni, string usuario, string nombre)
        {
            Conectar();
            comando = new SqlCommand("update nomina set nombre=@nombre where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@nombre"].Value = nombre;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarDomicilio(string dni, string usuario, string domicilio)
        {
            Conectar();
            comando = new SqlCommand("update nomina set domicilio=@domicilio where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@domicilio", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@domicilio"].Value = domicilio;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarFechaNac(string dni, string usuario, DateTime fechanac)
        {
            Conectar();
            comando = new SqlCommand("update nomina set fechanac=@fechanac where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@fechanac", SqlDbType.Date);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@fechanac"].Value = fechanac;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarFechaIng(string dni, string usuario, DateTime fechaing)
        {
            Conectar();
            comando = new SqlCommand("update nomina set fechaing=@fechaing where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@fechaing", SqlDbType.Date);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@fechaing"].Value = fechaing;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarPuesto(string dni,  string usuario, string puesto)
        {
            Conectar();
            comando = new SqlCommand("update nomina set puesto=@puesto where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@puesto", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@puesto"].Value = puesto;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void ModificarSalario(string dni, string usuario,  int salario)
        {
            Conectar();
            comando = new SqlCommand("update nomina set salario=@salario where dni=@dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters.Add("@salario", SqlDbType.Int);
            comando.Parameters["@dni"].Value = dni;
            comando.Parameters["@salario"].Value = salario;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void Borrar(string dni, string usuario)
        {
            Conectar();
            comando = new SqlCommand("delete from nomina where dni = @dni and usuario=@usuario", conexion);
            comando.Parameters.Add("@usuario", SqlDbType.VarChar);
            comando.Parameters["@usuario"].Value = usuario;
            comando.Parameters.Add("@dni", SqlDbType.VarChar);
            comando.Parameters["@dni"].Value = dni;
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
