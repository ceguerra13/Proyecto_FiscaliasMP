using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiFiscalias.Datos;
using ApiFiscalias.Models;

namespace ApiFiscalias.Controllers
{
    public class NumerosController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            try
            {
                Conexion con = new Conexion();
                List<Telefonos> resLis = con.GetTelefonosFis(id);
                if (resLis != null)
                    return Content(HttpStatusCode.OK, resLis);
                else
                    return Content(HttpStatusCode.BadRequest, "No existen datos");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Interno -->" + ex.Message);

            }
        }
        public IHttpActionResult Delete(int id)
        {

            try
            {
                Conexion conCli = new Conexion();
                bool res = conCli.DeleteTelefonos(id);
                if (res)
                    return Content(HttpStatusCode.OK, "Datos eliminados correctamente");
                else
                    return Content(HttpStatusCode.BadRequest, "Ocurrio un error");

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Interno en servidor" + ex.Message);
            }

        }
    }
}