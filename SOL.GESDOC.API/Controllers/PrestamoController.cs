using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOL.GESDOC.SERVICES;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;
using SOL.GESDOC.DTO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.ObjectPool;

namespace SOL.GESDOC.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private ITranPresServices _SRVPrestamo;

        public PrestamoController(ITranPresServices SRVPrestamo)
        {
            this._SRVPrestamo = SRVPrestamo;
        }

        [HttpPost]
        public async Task<dynamic> SolicitudPrestamo([FromBody] Object objTran)
        {
            try
            {
                var objParams = JsonConvert.DeserializeObject<dynamic>(objTran.ToString());

                T_TranSoliCabDto obj = new T_TranSoliCabDto();

                obj.NumSoli = objParams.NumSoli.ToString();
                obj.FecSoli = Convert.ToDateTime(objParams.FecSoli.ToString());
                obj.IdeUser = Convert.ToInt64(objParams.IdeUser.ToString());
                obj.CanSoli = Convert.ToInt32(objParams.CanSoli.ToString());
                obj.EstRegi = objParams.EstRegi.ToString();
                obj.CodUscr = objParams.CodUscr.ToString();                

                var Res = _SRVPrestamo.SolicitudPrestamo(obj);

                return Ok(new
                {
                    success = true,
                    message = "Ok"                   
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = true,
                    message = ex.Message                    
                });
            }
        }
    }
}
