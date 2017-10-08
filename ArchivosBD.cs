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
        #region Ejemplo de como implementar en form de edición
        //private string filename = "mysql.ini";
        //ArchivosBD File = new ArchivosBD();
        ///// <summary>
        ///// Carga configuración de BD
        ///// </summary>
        //private void CargaConf()
        //{
        //    if (File.MySqlConnectionRead(filename))
        //    {
        //        tbMysql.Text = File.mysqlcon;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error al leer el archivo de configuración de MySQL: " + filename, "Error al leer el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        ///// <summary>
        ///// Guarda configuración de BD
        ///// </summary>
        //private void GuardarConf()
        //{
        //    if (tBhost.Text.Trim() == "" && tBusuario.Text.Trim() == "" && tBpass.Text.Trim() == "" && tBbd.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Algun campo esta vacio", "Algun campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        if (File.MySqlConnectionWriter(filename, tBhost.Text, tBbd.Text, tBusuario.Text, tBpass.Text))
        //        {
        //            MessageBox.Show("Datos guardados correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}
        #endregion
        #region Manejadores de Bases de Datos
        #region Configurar MySQL
        /// <summary>
        /// Variable con los datos de salida para conexión MySQL
        /// </summary>
        public string mysqlcon;
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
        public string mssqlserver;
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
        public string PostgreSQL;
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
    }
}