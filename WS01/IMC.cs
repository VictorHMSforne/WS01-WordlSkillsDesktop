using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// adicionado
using System.Data.SqlClient;// adicionado
using System.Windows.Forms;

namespace WS01
{
    public class IMC
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string altura { get; set; }
        public string peso { get; set; }
        public string imc { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\WorldSkills\\WS01\\WS01\\DbIMC.mdf;Integrated Security=True"); // dever de casa

        public List<IMC> ListaIMC() //nome do metodo
        {
            List<IMC> li = new List<IMC>();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Pessoa", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IMC mi = new IMC();
                mi.Id = (int)dr["Id"];
                mi.nome = dr["nome"].ToString();
                mi.altura = dr["altura"].ToString();
                mi.peso = dr["peso"].ToString();
                mi.imc = dr["imc"].ToString();
                li.Add(mi);
            }
            con.Close();
            return li;
        }

        public void Inserir(string nome, string altura, string peso, string imc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Pessoa (nome,altura,peso,imc) VALUES ('" + nome + "','" + altura + "','" + peso + "','" + imc + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)// Exception Generalizado
            {
                MessageBox.Show(er.Message);         
            }
            
        }
        public void Atualizar(int Id, string nome, string altura, string peso, string imc)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Pessoa SET nome='"+nome+"',altura='"+altura+"',peso='"+peso+"',imc='"+imc+"' WHERE Id='"+Id+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Pessoa WHERE Id='"+Id+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
