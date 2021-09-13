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
    public partial class Instituicoes : Form
    {
        SqlConnection conexao = new(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Source\Repos\ManipularTabelas\ManipularTabelas\instituicoes.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Instituicoes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "INSERT INTO INSTITUICOES (NM_INSTITUICAO, DS_CIDADE, DS_UF) VALUES ('" + txtInstituicao.Text + "','" + txtCidade.Text + "','" + txtUf.Text + "')";
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if (retorno > 0)
            {
                MessageBox.Show("Instituição Inserida !", "Inserir Instituição");
                Limpar();
            }
            else
            {
                MessageBox.Show("Instituição não Inserida !", "Inserir Instituição");
            }

            cmd.Dispose();
        }

        private void Instituicoes_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message.ToString(), "Conexão Banco");
            }
        }

        private void Limpar()
        {
            txtId.Text = "";
            txtInstituicao.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String cmd_sql;
            cmd_sql = "SELECT NM_INSTITUICAO, DS_CIDADE, DS_UF FROM INSTITUICOES WHERE  ID_INSTITUICAO = " + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                txtInstituicao.Text = dr["NM_INSTITUICAO"].ToString();
                txtCidade.Text = dr["DS_CIDADE"].ToString();
                txtUf.Text = dr["DS_UF"].ToString();
            }
            else
            {
                MessageBox.Show("Instituição não Localizada !", "Consultar Instituição");
                Limpar();
            }

            dr.Close();
            cmd.Dispose();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "DELETE INSTITUICOES WHERE ID_INSTITUICAO = " + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if (retorno > 0)
            {
                MessageBox.Show("Instituição Apagado !", "Apagar Instituição");
                Limpar();
            }
            else
            {
                MessageBox.Show("Não foi possivel Apagar Instituição !", "Apagar Instituição");
            }

            cmd.Dispose();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int retorno;
            String cmd_sql;
            cmd_sql = "UPDATE INSTITUICOES SET NM_INSTITUICAO='" + txtInstituicao.Text + "', DS_CIDADE='" + txtCidade.Text + "', " +
                "DS_UF='" + txtUf.Text + "' WHERE ID_INSTITUICAO =" + txtId.Text;
            cmd = new SqlCommand(cmd_sql, conexao);
            retorno = cmd.ExecuteNonQuery();

            if (retorno > 0)
            {
                MessageBox.Show("Alteração Realizada !", "Alterar Instituição");
            }
            else
            {
                MessageBox.Show("Alteração não Realizada !", "Alterar Instituição");
            }

            cmd.Dispose();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }

}
