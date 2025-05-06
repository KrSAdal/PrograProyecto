using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoProgra
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            // Configuración de MaterialSkin con tema oscuro
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500, Primary.Indigo700,
                Primary.Indigo100, Accent.Indigo200,
                TextShade.WHITE
            );

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            if (usuario == "admin" && contrasena == "123")
            {
                Form1 menuPrincipal = new Form1("admin");
                menuPrincipal.Show();
                this.Hide();
            }
            else if (usuario == "usuario" && contrasena == "123")
            {
                Form1 menuPrincipal = new Form1("ventas");
                menuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }
    }
}
