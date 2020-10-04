using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.FakeDB
{   
    
    /// <summary>
     /// Classe Pessoa.
     /// </summary>
    public abstract class Pessoa
    {
        /// <summary>
        /// chave primária do registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da pessoa.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de Inscrição no Aplicativo.
        /// </summary>
        public DateTime DataDeInscricao { get; set; }

        public Pessoa(int id)
        {
            this.Id = id;
        }
    }
}