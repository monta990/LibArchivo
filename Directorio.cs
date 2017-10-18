using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace LibArchivo
{
    /// <summary>
    /// Clase manejadora de directorios
    /// </summary>
    public class Directorio
    {
        /// <summary>
        /// Crea directorio
        /// </summary>
        /// <param name="Path">nombre del directorio</param>
        /// <returns></returns>
        public bool Crear(string Path)
        {
            bool status = false;
            if (Directory.Exists(Directory.GetCurrentDirectory() + @"\" + Path))
            {
                status = false;
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + Path);
                status = true;
            }
            return status;
        }
    }
}
