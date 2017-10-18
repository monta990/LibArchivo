using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;

namespace LibArchivo
{
    /// <summary>
    /// Clase de manejo de imagenes
    /// </summary>
    public class Imagen
    {
        MySQL BD = new MySQL();
        public bool Guardar(string nombre, string valores, byte[] ImageData)
        {
            bool status = false;
            //if (BD.InsertarImagen("imagen", "name, image", valores, ImageData))
            //{
            //    status = true;
            //}
            return status;
        }
        public bool Consultar(string name)
        {
            bool status = false;
            return status;
        }
        public bool Eliminar(string name)
        {
            bool status = false;
            return status;
        }
    }
}