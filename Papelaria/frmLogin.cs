using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Papelaria.Properties;
using Npgsql;

namespace Papelaria
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" +
            "User Id={2};Password={3};Database={4};",
            "localhost", "5432", "postgres",
            "123", "paperclip");
        //private DataTable dt;
        private NpgsqlCommand cmd;
        //private string sql = null;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (validaLogin())
                {
                    this.Hide();
                    frmPrincipal blabla = new frmPrincipal(txtUsuario.Text);
                    blabla.ShowDialog();
                    //new frmPrincipal(txtUsuario.Text).Show();
                }//Só funciona sem as chaves caso seja o "if" e só 1 linha depois disso... mesma coisa pro Else
                else
                {
                    MessageBox.Show("Verifique login e senha", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                #region Teu Código Antigo 
                //sql = @"select login, senha from usuario";
                //cmd = new NpgsqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("login", txtUsuario.Text);
                //cmd.Parameters.AddWithValue("senha", txtSenha.Text);
                //int resultado = (int)cmd.ExecuteScalar(); 
                //conn.Close();

                //if (resultado == 1)
                //{
                //    this.Hide();
                //    new frmPrincipal(txtUsuario.Text).Show();
                //}
                //else
                //{
                //    MessageBox.Show("Verifique login e senha", "Dados incorretos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Usuario ou senha incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                conn.Close();
            }
        }

        private bool validaLogin()
        {
            DataTable b = new DataTable();
            using (var connection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=paperclip;"))
            {

                connection.Open();
                string query = "Select * from usuario";
                var command = new NpgsqlCommand(query, connection);
                NpgsqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                    //dataReader[2] é a segunda coluna lida, no caso o login, logo o 3 é a senha, hehe
                    if (txtUsuario.Text == dataReader[2].ToString() && txtSenha.Text == dataReader[3].ToString())
                    {
                        
                        return true;
                    }


            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }
    }
}
