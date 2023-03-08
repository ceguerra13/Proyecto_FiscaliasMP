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
    public class FiscaliasController : ApiController
    {
        public IHttpActionResult Post(Fiscalias fiscalia) {

            try
            {
                Conexion conFiscalias = new Conexion();
                bool res = conFiscalias.InsertFiscalias(fiscalia);
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
                Fiscalias res = con.GetFiscalias(id);
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
        public IHttpActionResult Get()
        {
            try
            {
                Conexion con = new Conexion();
                List<Fiscalias> resLis = con.GetAllFiscalias();
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


        public IHttpActionResult Put(Fiscalias fiscalia)
        {
            try
            {
                Conexion conCli = new Conexion();
                bool res = conCli.UpdateFiscalias(fiscalia);
                if (res)
                    return Content(HttpStatusCode.OK, "Datos guardados correctamente");
                else
                    return Content(HttpStatusCode.BadRequest, "Ocurrio un error");

            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Error Interno en servidor" + ex.Message);
            }

        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Conexion conCli = new Conexion();
                bool res = conCli.DeleteFiscalias(id);
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
