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
    /// <summary>
    /// Recurso Região
    /// </summary>
    public class MunicipioController : BaseAncestralController
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        public MunicipioController() : base()
        { }

        /// <sumary>
        /// Obtem todos os registros da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            List<Municipio> listaEF = this.Contexto.Municipios.ToList();
            List<PocoMunicipio> listaPoco = new List<PocoMunicipio>();
            foreach (Municipio item in listaEF)
            {
                PocoMunicipio poco = new PocoMunicipio()
                {
                    SiglaUF = item.SiglaUF,
                    IdMunicipio = item.IdMunicipio,
                    IdEstado = item.IdEstado,
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
        public HttpResponseMessage GetByID(int id)
        {
            Regiao regiaoEF = this.Contexto.Regioes.SingleOrDefault(r => r.IdRegiao == id);
            if (regiaoEF != null)
            {
                PocoRegiao poco = new PocoRegiao()
                {
                    IdRegiao = regiaoEF.IdRegiao,
                    Descricao = regiaoEF.Descricao,
                    DataInsert = regiaoEF.DataInsert,
                    DataUpdate = regiaoEF.DataUpdate
                };

                return Request.CreateResponse(HttpStatusCode.OK, poco);

            } else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não encontrado municipio");
            }

        }

        /// <sumary>
        /// Obtem todos os municpios de um estado
        /// </sumary>
        /// <param name="idEstado"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/Estado/{id:int}")]
        public HttpResponseMessage GetByFkID([FromUri] int idEstado)
        {
            List<Municipio> listaEF = this.Contexto.Municipios.Where(x => x.IdEstado == idEstado).ToList();
            if(listaEF != null)
            {
                List<PocoMunicipio> listaPoco = listaEF.Select(x => new PocoMunicipio()
                {
                    IdMunicipio = x.IdMunicipio,
                    IdEstado = x.IdEstado,
                    Descricao = x.Descricao,
                    SiglaUF = x.SiglaUF,
                    DataInsert = x.DataInsert,
                    DataUpdate = x.DataUpdate
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, listaPoco);
            } else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Não encontrado municipios desse estado.");

            }

        }


        /// <summary>
        /// Insere um registro na tabela referente
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Create([FromBody] PocoMunicipio poco)
        {
            try
            {
                Municipio municipioEF = new Municipio()
                {
                    IdMunicipio = poco.IdMunicipio,
                    SiglaUF = poco.SiglaUF,
                    IdEstado = poco.IdEstado,
                    Descricao = poco.Descricao,
                    DataInsert = DateTime.Now
                };

                this.Contexto.Municipios.Add(municipioEF);
                this.Contexto.SaveChanges();
                poco.IdMunicipio = municipioEF.IdMunicipio;

                return Request.CreateResponse(HttpStatusCode.OK, poco);
            } catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }

        }

        /// <summary>
        /// Atualiza um registro na tabela referente
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Update([FromBody] PocoMunicipio poco)
        {
            Municipio municipioEF = new Municipio()
            {
                IdEstado = poco.IdEstado,
                IdMunicipio = poco.IdMunicipio,
                SiglaUF = poco.SiglaUF,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                DataUpdate = DateTime.Now
            };
            this.Contexto.Entry(municipioEF).State = System.Data.Entity.EntityState.Modified;
            this.Contexto.SaveChanges();
            poco.DataUpdate = municipioEF.DataUpdate;
            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        /// <summary>
        /// Apaga um registro da tabela referente
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            Municipio municipioEF = this.Contexto.Municipios.Find(id);

            if (municipioEF != null)
            {
                try
                {
                    PocoMunicipio poco = new PocoMunicipio()
                    {
                        IdEstado = municipioEF.IdEstado,
                        IdMunicipio = municipioEF.IdMunicipio,
                        SiglaUF = municipioEF.SiglaUF,
                        Descricao = municipioEF.Descricao,
                        DataInsert = municipioEF.DataInsert,
                        DataUpdate = municipioEF.DataUpdate
                    };
                    this.Contexto.Entry(municipioEF).State = System.Data.Entity.EntityState.Deleted;
                    this.Contexto.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, poco);
                }

                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                }

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Não encontrado o Municipio!");
            }

        }
    }
}
