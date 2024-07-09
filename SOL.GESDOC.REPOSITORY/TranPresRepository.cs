using Microsoft.Extensions.Options;
using SOL.GESDOC.DTO;
using SOL.GESDOC.REPOSITORY;
using SOL.GESDOC.SERVICES;
using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace SOL.GESDOC.REPOSITORY_
{
    public class TranPresRepository : ITranPresServices
    {
        private readonly IOptions<STConnectionRepository> _cn;
        public TranPresRepository(IOptions<STConnectionRepository> cn)
        {
            _cn = cn;
        }
        public bool SolicitudPrestamo(T_TranSoliCabDto objTran)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_cn.Value.ConexionSFB))
                {
                    using (SqlCommand cmd = new SqlCommand("Transaccion.USP_INS_T_SoliPres", con))
                    {
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@NumSoli", objTran.NumSoli);
                            cmd.Parameters.AddWithValue("@FecSoli", objTran.FecSoli);
                            cmd.Parameters.AddWithValue("@IdeUser", objTran.IdeUser);
                            cmd.Parameters.AddWithValue("@CanSoli", objTran.CanSoli);
                            cmd.Parameters.AddWithValue("@EstRegi", objTran.EstRegi);
                            cmd.Parameters.AddWithValue("@CodUscr", objTran.CodUscr);
                            cmd.Parameters.Add("@XML", SqlDbType.Xml).Value = objTran.GetItemsXML();

                        }

                        con.Open();

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
