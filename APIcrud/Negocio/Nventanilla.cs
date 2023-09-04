using APIcrud.Datos;
using APIcrud.Entidad;
using System.Data.SqlClient;

namespace APIcrud.Negocio
{
    public class Nventanilla
    {
        public List<Ventanilla> listaVentanilla()
        {
           List<Ventanilla> oLista = null;
           oLista = new List<Ventanilla>();
           String selectsegmento = $@"SELECT cagencia,tventanilla,dventana
                                                FROM Ventanilla";
            try
            {
                string con = conDatos.ConSQL();
                using (SqlConnection connection2 = new SqlConnection(con))
                {
                    using (SqlCommand command2 = new SqlCommand(selectsegmento, connection2)) //1
                    {
                        connection2.Open();
                        using (SqlDataReader readercolasdts = command2.ExecuteReader())
                        {
                            //Console.WriteLine(lresult);
                            if (readercolasdts.HasRows)
                            {
                                while (readercolasdts.Read())
                                {
                                    Ventanilla oventa = new Ventanilla();
                                    oventa.cagencia = (int)readercolasdts["cagencia"];
                                    oventa.tventanilla = (int)readercolasdts["tventanilla"];
                                    oventa.dventana = (string)readercolasdts["dventana"];
                                    oLista.Add(oventa);
                                }
                            }
                        }
                    } //1
                }
            }
            catch (Exception ex)
            {

                //funciones.AddText("listaSegmento--" + ex.Message.ToString());
            }
            //funciones.AddText("listaSegmento=OK");
            

            return oLista;

        }
        public bool AddVentanilla( Ventanilla oventa)
        {
            string sqlinsert = $@"insert into ventanilla(cagencia,tventanilla,dventana) values( {oventa.cagencia},{oventa.tventanilla},'{oventa.dventana}')";
            bool status = false;
            try
            {
                string con = conDatos.ConSQL();
                using (SqlConnection connection = new SqlConnection(con))
                {
                    using (SqlCommand command = new SqlCommand(sqlinsert, connection))
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        
                    }

                }
                status = true;
            }
            catch (Exception ex)
            {
                //xResult = ex.Message.ToString();
                status = false;
            }
            return status;
        }
    }
}
