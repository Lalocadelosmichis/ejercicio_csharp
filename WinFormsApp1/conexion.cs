using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    internal class conexion
    {
        SqlConnection cn;

        public conexion()
        {
            try 
            { 
            //MUESTRA SI ESTAMOS CONECTADOS A LA DATABASE O NO.
                cn = new SqlConnection("Data Source = DESKTOP-V0LI9UJ\\SQLEXPRESS;Initial Catalog=prueba;Integrated Security=True");
                MessageBox.Show("Conexión exitosa a la Data Base.","CONEXIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch(Exception ex)
            { 
            MessageBox.Show("La conexión a la Data Base ha fallado."+ ex.ToString());
            }
        }
        public int Login(string usuario, string pass) 
        {
            //PROCEDIMIENTO ALMACENADO PARA AUTENTIFICAR EL LLAMADO DESDE SQL Y PROBAR QUE LOS DATOS ALMACENADOS SON CORRECTOS.
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);

                //ESTE COMANDO ES PARA QUE SE EJECUTE.
                SqlDataReader dr=cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }
                        
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            //CIERRA LA CONEXIÓN.
            {
                cn.Close();
            }
            return -1;


        }

    }
}
