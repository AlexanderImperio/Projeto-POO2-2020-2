using POO2RestAPI.Models.Poco;
using POO2RestAPI.Models.ProjetoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POO2RestAPI.Controllers
{
    public class MunicipioController : BaseAncestralController
    {
        public MunicipioController() : base()
        { }

        /// <sumary>
        /// Obtem todos os registros da tabela referente
        /// </sumary>
        /// <param name="id"></param>
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

        /// <sumary>
        /// Obtem um registro da tabela referente
        /// </sumary>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/Estado/{id:int}")]
        public HttpResponseMessage GetByFkID([FromUri] int idEstado)
        {
            List<Municipio> listaEF = this.Contexto.Municipios.Where(x => x.IdEstado == idEstado).ToList();
            List<PocoMunicipio> listaPoco = listaEF.Select(x => new PocoMunicipio()
            {
                IdMunicipio = x.IdMunicipio,
                IdEstado = x.IdEstado,
                Descricao = x.Descricao,
                SiglaUF = x.SiglaUF,
                DataInsert = x.DataInsert,
                DataUpdate = x.DataUpdate
            }).ToList();
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
