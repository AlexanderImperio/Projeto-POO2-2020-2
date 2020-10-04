using POO2RestAPI.Models.ProjetoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POO2RestAPI.Controllers
{
    /// <sumary>
    /// Recurso Estado
    /// </sumary>
    [RoutePrefix("api/Cadastro/Municipio")]
    public class EstadoController : BaseAncestralController
    {
        private ModelProjetoDB contexto;

        /// <sumary>
        /// Construtor da classe
        /// </sumary>

        public EstadoController(): base()
        { }

        /// <sumary>
        /// Obtem todos os registros da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Método não implementado");
        }

        /// <sumary>
        /// Obtem um registro da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id:int}")]
        public HttpResponseMessage GetByID(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Método não implementado");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Create()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Método não implementado");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Update()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Método não implementado");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(HttpStatusCode.NotImplemented, "Método não implementado");
        }
    }
}
