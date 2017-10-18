using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibArchivo
{
    /// <summary>
    /// Manejo de archivos de configuración para BD
    /// </summary>
    public class ArchivosBD
    {
        public string status;
        public string user;
        public string pass;
        /// <summary>
        /// Datos de conexión para MySQL
        /// </summary>
        public string mysqlcon;
        /// <summary>
        /// Datos de conexión para MS SQL Server
        /// </summary>
        public string mssqlserver;
        /// <summary>
        /// Datos de conexión para PostgreSQL
        /// </summary>
        public string PostgreSQL;
        #region Manejadores de Bases de Datos
        #region Configurar MySQL
        /// <summary>
        /// Datos a guardar en el archivo de configuración de MySQL
        /// </summary>
        /// <param name="fileName">Archivo en donde guardar</param>
        /// <param name="Host">Servidor</param>
        /// <param name="database">Base de datos</param>
        /// <param name="UserName">Usuario</param>
        /// <param name="pasword">Contraseña</param>
        /// <returns>True o False</returns>
        public bool MySqlConnectionWriter(string fileName, string Host, string database, string UserName, string pasword)
        {
            bool status = false;
            using (FileStream Archivo = File.Create(fileName))
            {
                using (StreamWriter MySQL = new StreamWriter(Archivo))
                {
                    MySQL.WriteLine("Server = "+Host+";Database="+database+";Uid="+UserName+";Pwd="+pasword);
                }
                status = true;
            }
            return status;
        }
        /// <summary>
        /// Regresa datos de conexión
        /// </summary>
        /// <param name="fileName">Archivo de configuración a leer</param>
        /// <returns>True o false y cadena de conexión</returns>
        public bool MySqlConnectionRead(string fileName)
        {
            bool status = false;
            if (File.Exists(fileName))
            {
                using (StreamReader Archivo = new StreamReader(File.OpenRead(fileName)))
                {
                    string cad = "";
                    while ((cad = Archivo.ReadLine()) != null) //se lee linea por linea
                    {
                        status = true;
                        mysqlcon = cad;
                    }
                }
            }
            return status;
        }
        #endregion
        #region Configurar MSSQL Server
        /// <summary>
        /// Datos a guardar en el archivo de configuración de MSSQL Server
        /// </summary>
        /// <param name="fileName">Archivo en donde guardar</param>
        /// <param name="Host">Servidor</param>
        /// <param name="database">Base de datos</param>
        /// <param name="UserName">Usuario</param>
        /// <param name="pasword">Contraseña</param>
        /// <returns>True o False</returns>
        public bool MSSQLConnectionWrite(string fileName, string Host, string database, string UserName, string pasword)
        {
            bool status = false;
            using (FileStream Archivo = File.Create(fileName))
            {
                using (StreamWriter MSSQLServer = new StreamWriter(Archivo))
                {
                    MSSQLServer.WriteLine("Data Source = " + Host + "; Initial Catalog =" + database + ";User Id =" + UserName + ";Password =" + pasword);
                }
                status = true;
            }
            return status;
        }
        /// <summary>
        /// Regresa datos de conexión
        /// </summary>
        /// <param name="fileName">Archivo a leer</param>
        /// <returns>True o False</returns>
        public bool MSSQLConnectionRead(string fileName)
        {
            bool status = false;
            if (File.Exists(fileName))
            {
                using (StreamReader Archivo = new StreamReader(File.OpenRead(fileName)))
                {
                    string cad = "";
                    while ((cad = Archivo.ReadLine()) != null) //se lee linea por linea
                    {
                        status = true;
                        mssqlserver = cad;
                    }
                }
            }
            return status;
        }
        #endregion
        #region Configurar PostgreSQL
        /// <summary>
        /// Datos a guardar en el archicvo de configuración de PostgreSQL
        /// </summary>
        /// <param name="fileName">Archivo en donde guardar</param>
        /// <param name="Host">Servidor</param>
        /// <param name="database">Base de datos</param>
        /// <param name="UserName">Usuario</param>
        /// <param name="pasword">Contraseña</param>
        /// <returns>True o False</returns>
        public bool PostgreSQLConnectionWriter(string fileName, string Host, string database, string UserName, string pasword)
        {
            bool status = false;
            using (FileStream Archivo = File.Create(fileName))
            {
                using (StreamWriter PostgreSQL = new StreamWriter(Archivo))
                {
                    PostgreSQL.WriteLine("Server = " + Host + "; Database =" + database + ";User Id =" + UserName + ";Password =" + pasword);
                }
                status = true;
            }
            return status;
        }
        /// <summary>
        /// Regresa datos de conexión
        /// </summary>
        /// <param name="fileName">Archivo de configuracion a leer</param>
        /// <returns>True o False</returns>
        public bool PostgreSQLConnectionRead(string fileName)
        {
            bool status = false;
            if (File.Exists(fileName))
            {
                using (StreamReader Archivo = new StreamReader(File.OpenRead(fileName)))
                {
                    string cad = "";
                    while ((cad = Archivo.ReadLine()) != null) //se lee linea por linea
                    {
                        status = true;
                        PostgreSQL = cad;
                    }
                }
            }
            return status;
        }
        #endregion
        #endregion Fin Manejadores de Bases de Datos
        /// <summary>
        /// Escritura del archivo recordar
        /// </summary>
        /// <param name="fileName">Archivo a usar</param>
        /// <param name="user">Usuario</param>
        /// <param name="pass">Contraseña</param>
        /// <param name="status">Estado de recordar para crearlo o borrarlo</param>
        public void Recordar(string fileName, string user, string pass, string status)
        {
            if (status == "True")
            {
                using (FileStream Fs = File.Create(fileName))
                {
                    using (StreamWriter Archivo = new StreamWriter(Fs))
                    {
                        Archivo.WriteLine(user.ToString());
                        Archivo.WriteLine(pass.ToString());
                        Archivo.WriteLine(status.ToString());
                    }
                }
            }
            else if (status == "False")
            {
                File.Delete(fileName);
            }
        }
        /// <summary>
        /// Leer el archivo recordar
        /// </summary>
        /// <param name="fileName">Archivo a usar</param>
        public void LeerRecordar(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream Fs = File.Open(fileName, FileMode.Open))
                {
                    using (StreamReader Archivo = new StreamReader(Fs))
                    {
                        user = Archivo.ReadLine();
                        pass = Archivo.ReadLine();
                        status = Archivo.ReadLine();
                    }
                }
            }
        }
    }
}