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
    /// <sumary>
    /// Recurso Estado
    /// </sumary>
    [RoutePrefix("api/Cadastro/Estado")]
    public class EstadoController : BaseAncestralController
    {
        /// <sumary>
        /// Construtor da classe
        /// </sumary>
        public EstadoController() : base()
        { }

        /// <sumary>
        /// Obtem todos os registros da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            List<Estado> listaEF = this.Contexto.Estados.ToList();
            List<PocoEstado> listaPoco = new List<PocoEstado>();
            foreach (Estado item in listaEF)
            {
                PocoEstado poco = new PocoEstado()
                {
                    RegiaoBrasil = item.RegiaoBrasil,
                    IdEstado = item.IdEstado,
                    SiglaUF = item.SiglaUF,
                    IdRegiao = item.IdRegiao,
                    Descricao = item.Descricao,
                    DataInsert = item.DataInsert,
                    DataUpdate = item.DataUpdate
                };
                listaPoco.Add(poco);
            };
            return Request.CreateResponse(HttpStatusCode.OK, listaPoco);
        }

        /// <sumary>
        /// Obtem um registro da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id:int}")]
        public HttpResponseMessage GetByID([FromUri] int id)
        {
            Estado estadoEF = this.Contexto.Estados.Find(id);
            if (estadoEF != null)
            {
                PocoEstado poco = new PocoEstado()
                {
                    SiglaUF = estadoEF.SiglaUF,
                    RegiaoBrasil = estadoEF.RegiaoBrasil,
                    IdEstado = estadoEF.IdEstado,
                    IdRegiao = estadoEF.IdRegiao,
                    Descricao = estadoEF.Descricao,
                    DataInsert = estadoEF.DataInsert,
                    DataUpdate = estadoEF.DataUpdate
                };

                return Request.CreateResponse(HttpStatusCode.OK, poco);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Estado não encontrado");
            }

        }

        /// <summary>
        /// Cria um registro na tabela referente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Create([FromBody] PocoEstado poco)
        {
            try
            {
                Estado estadoEF = new Estado()
                {
                    IdEstado = poco.IdEstado,
                    RegiaoBrasil = poco.RegiaoBrasil,
                    SiglaUF = poco.SiglaUF,
                    IdRegiao = poco.IdRegiao,
                    Descricao = poco.Descricao,
                    DataInsert = DateTime.Now
                };

                this.Contexto.Estados.Add(estadoEF);
                this.Contexto.SaveChanges();
                poco.IdRegiao = estadoEF.IdEstado;

                return Request.CreateResponse(HttpStatusCode.OK, poco);
            } catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        /// <summary>
        /// Atualiza um registro na tabela referente
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Update([FromBody] PocoEstado poco)
        {
            try
            {
                Estado estadoEF = new Estado()
                {
                    RegiaoBrasil = poco.RegiaoBrasil,
                    SiglaUF = poco.SiglaUF,
                    IdEstado = poco.IdEstado,
                    IdRegiao = poco.IdRegiao,
                    Descricao = poco.Descricao,
                    DataInsert = poco.DataInsert,
                    DataUpdate = DateTime.Now
                };
                this.Contexto.Entry(estadoEF).State = System.Data.Entity.EntityState.Modified;
                this.Contexto.SaveChanges();
                poco.DataUpdate = estadoEF.DataUpdate;
                return Request.CreateResponse(HttpStatusCode.OK, poco);
            } catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e);

            }

        }

        /// <summary>
        /// Apaga um registro na tabela referente 
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            Estado estadoEF = this.Contexto.Estados.Find(id);

            if (estadoEF != null)
            {
                try
                {
                    PocoEstado poco = new PocoEstado()
                    {
                        IdEstado = estadoEF.IdEstado,
                        IdRegiao = estadoEF.IdRegiao,
                        Descricao = estadoEF.Descricao,
                        DataInsert = estadoEF.DataInsert,
                        DataUpdate = estadoEF.DataUpdate
                    };
                    this.Contexto.Entry(estadoEF).State = System.Data.Entity.EntityState.Deleted;
                    this.Contexto.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, poco);
                }

                catch(Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Não encontrado o estado!");
            }

        }
    }
}
