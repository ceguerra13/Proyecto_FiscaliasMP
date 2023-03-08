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
    public class TelefonosController : ApiController
    {
        public IHttpActionResult Post(Telefonos fiscalia)
        {

            try
            {
                Conexion conFiscalias = new Conexion();
                bool res = conFiscalias.InsertTelefonos(fiscalia);
                if (res)
                    return Content(HttpStatusCode.OK, "Guardado correctamente");
                else
                    return Content(HttpStatusCode.BadRequest, "Ocurrio un error");

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Interno en servidor" + ex.Message);
            }

        }
        public IHttpActionResult Get(int id)
        {
            try
            {
                Conexion con = new Conexion();
                Telefonos res = con.GetTelefonos(id);
                if (res != null)
                    return Content(HttpStatusCode.OK, res);
                else
                    return Content(HttpStatusCode.BadRequest, "No existen datos");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Interno -->" + ex.Message);

            }
        }
        
    }
}