using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipularTabelas
{
    public partial class Eventos : Form
    {
        SqlConnection conexao = new(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Source\Repos\ManipularTabelas\ManipularTabelas\eventos.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Eventos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
            }
            catch(Exception ex){
                MessageBox.Show("Erro: " + ex.Message.ToString(), "Conexão Banco");
            }
            
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "INSERT INTO EVENTOS (EVENTO, DATA_INICIO, DATA_TERMINO, LOCAL, VALOR) VALUES ('" + txtEvento.Text + "','" + 
                txtInicio.Text + "','" + txtTermino.Text+ "','" + 
                txtLocal.Text + "','" + txtValor.Text + "')";
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if (retorno > 0)
            {
                MessageBox.Show("Evento Inserido !", "Inserir Evento");
                Limpar();
            } else
            {
                MessageBox.Show("Evento não Inserido !", "Inserir Evento");
            }

            cmd.Dispose();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String cmd_sql;
            cmd_sql = "SELECT EVENTO, DATA_INICIO, DATA_TERMINO, LOCAL, VALOR FROM EVENTOS WHERE  ID_EVENTO = " + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                txtEvento.Text = dr["EVENTO"].ToString();
                txtInicio.Text = dr["DATA_INICIO"].ToString();
                txtTermino.Text = dr["DATA_TERMINO"].ToString();
                txtLocal.Text = dr["LOCAL"].ToString();
                txtValor.Text = dr["VALOR"].ToString();
            } else
            {
                MessageBox.Show("Evento não Localizado !", "Consultar Evento");
                Limpar();
            }

            dr.Close();
            cmd.Dispose();
        }
        private void Limpar()
        {
            txtId.Text = "";
            txtEvento.Text = "";
            txtInicio.Text = "";
            txtTermino.Text = "";
            txtLocal.Text = "";
            txtValor.Text = "";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "DELETE EVENTOS WHERE ID_EVENTO = " + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if(retorno > 0)
            {
                MessageBox.Show("Evento Apagado !", "Apagar Evento");
                Limpar();
            } else {
                MessageBox.Show("Não foi possivel Apagar Evento !", "Apagar Evento");
            }

            cmd.Dispose();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "UPDATE EVENTOS SET EVENTO='" + txtEvento.Text + "', DATA_INICIO='" + txtInicio.Text + "', " +
                "DATA_TERMINO='" + txtTermino.Text + "', LOCAL='" + txtLocal.Text + "', VALOR='" + txtValor.Text + "' WHERE ID_EVENTO =" + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if(retorno > 0)
            {
                MessageBox.Show("Alteração Realizada !", "Alterar Evento");
            }
            else
            {
                MessageBox.Show("Alteração não Realizada !", "Alterar Evento");
            }

            cmd.Dispose();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
