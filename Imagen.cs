using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;
using System.Data.SqlClient;
using System.Data;

namespace LibArchivo
{
    ///EN CONSTRUCCIÖN
    /// 
    /// <summary>
    /// Clase de manejo de imagenes
    /// </summary>
    public class Imagen
    {
        SqlConnection cn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        DataRow dr;
        SqlDataReader sqldr;
        public string abrirConexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=SQL7001.SmarterASP.NET;Initial Catalog=DB_A2BC3D_perloan;User ID=DB_A2BC3D_perloan_admin;Password=Elias986");
                cn.Open();
                return "Conectado";
            }
            catch (Exception ex)
            {
                return "No conectado: " + ex.ToString();
            }
        }

        public string insertarImagen(string descripcion)
        {
            string mensaje = "Se insertó la imagen";
            try
            {
                cmd = new SqlCommand("INSERT INTO imagen(name,image) values(@Descripcion,@Imagen)", cn);
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);
                cmd.Parameters.Add("@Imagen", SqlDbType.Image);

                cmd.Parameters["@Descripcion"].Value = descripcion;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                //FrmImagen.paspic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@Imagen"].Value = ms.GetBuffer();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mensaje = "No se inserto la imagen por que el nombre esta repetido";
            }
            return mensaje;
        }

        public string verImagen(string descripcion)
        {
            string mensaje = "Imagen encontrada";
            try
            {
                da = new SqlDataAdapter("SELECT image FROM imagen WHERE name = '" + descripcion + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "imagen");
                byte[] datos = new byte[0];
                dr = ds.Tables["imagen"].Rows[0];
                datos = (byte[])dr["image"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
                FrmImagen.paspic.Image = System.Drawing.Bitmap.FromStream(ms);
            }
            catch (Exception ex)
            {
                mensaje = "Imagen no encontrada";//ex.ToString();
            }
            return mensaje;
        }

        public void cargarImagenes()
        {
            try
            {
                cmd = new SqlCommand("SELECT name FROM imagen", cn);
                sqldr = cmd.ExecuteReader();
                while (sqldr.Read())
                {
                    FrmImagen.cbListaFotosBD.Items.Add(sqldr["name"]);
                }
                sqldr.Close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}