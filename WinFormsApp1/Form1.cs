using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        conexion cn = new conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            //EL BOTÓN VERIFICA CON LA DATABASE SI EL USUARIO INGRESADO ES CORRECTO.
            //SI LA VARIABLE RESULT ES IGUAL A LOGIN.
            int result = cn.Login(txt_usuario.Text, txt_pass.Text);
            if(result == 1)
            {
                MessageBox.Show("¡Acceso existoso!" + "Bienvenid@" + txt_usuario.Text, "AUTENTIFICACIÓN", MessageBoxButtons.OK,MessageBoxIcon.Information);            
                Form2 menu = new Form2();
                this.Hide();
                menu.ShowDialog();
            }
            else if (result == 0) 
            //SI RESULT ES IGUAL A 0 (FALSE) QUIERE DECIR QUE LA AUTENTIFICACIÓN FALLÓ.
            {
                MessageBox.Show("Usuario o contraseña incorrecta, intente nuevamente.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_usuario.Clear();
                txt_pass.Clear();
                txt_usuario.Focus();
            }
        }
        
    }
}