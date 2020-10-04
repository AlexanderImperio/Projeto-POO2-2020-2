﻿using POO2RestAPI.Models.Poco;
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
    /// Recurso Região
    /// </sumary>
    [RoutePrefix("api/Cadastro/Regiao")]
    public class RegiaoController : BaseAncestralController
    {
        private ModelProjetoDB contexto;

        /// <sumary>
        /// Construtor da classe
        /// </sumary>

        public RegiaoController() : base()
        { }

        /// <sumary>
        /// Obtem todos os registros da tabela referente
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public HttpResponseMessage Get()
        {
            List<Regiao> listaEF = this.contexto.Regioes.ToList();
            List<PocoRegiao> listaPoco = new List<PocoRegiao>();
            foreach (Regiao item in listaEF)
            {
                PocoRegiao poco = new PocoRegiao() { 
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
        public HttpResponseMessage GetByID([FromUri]int id)
        {
            // Regiao regiaoEF = this.contexto.Regioes.Where(r => r.IdRegiao == id).FirstOrDefault();
            // Regiao regiaoEF = this.contexto.Regioes.Find(id);
            Regiao regiaoEF = this.contexto.Regioes.SingleOrDefault(r => r.IdRegiao == id);
            PocoRegiao poco = new PocoRegiao()
            {
                IdRegiao = regiaoEF.IdRegiao,
                Descricao = regiaoEF.Descricao,
                DataInsert = regiaoEF.DataInsert,
                DataUpdate = regiaoEF.DataUpdate
            };

            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public HttpResponseMessage Create([FromBody] PocoRegiao poco)
        {
            Regiao regiaoEF = new Regiao()
            {
                IdRegiao = poco.IdRegiao,
                Descricao = poco.Descricao,
                DataInsert = DateTime.Now
            };

            this.Contexto.Regioes.Add(regiaoEF);
            this.Contexto.SaveChanges();
            poco.IdRegiao = regiaoEF.IdRegiao;

            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("Put")]
        public HttpResponseMessage Update([FromBody] PocoRegiao poco)
        {
            Regiao regiaoEF = new Regiao()
            {
                IdRegiao = poco.IdRegiao,
                Descricao = poco.Descricao,
                DataInsert = poco.DataInsert,
                DataUpdate = DateTime.Now
            };
            this.Contexto.Entry(regiaoEF).State = System.Data.Entity.EntityState.Modified;
            this.Contexto.SaveChanges();
            poco.DataUpdate = regiaoEF.DataUpdate;
            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            Regiao regiaoEF = this.contexto.Regioes.Find(id);
            PocoRegiao poco = new PocoRegiao()
            {
                IdRegiao = regiaoEF.IdRegiao,
                Descricao = regiaoEF.Descricao,
                DataInsert = regiaoEF.DataInsert,
                DataUpdate = regiaoEF.DataUpdate
            };
            this.Contexto.Entry(regiaoEF).State = System.Data.Entity.EntityState.Deleted;
            this.Contexto.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }
    }
}