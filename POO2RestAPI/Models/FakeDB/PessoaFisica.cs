using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.FakeDB
{   
    
    /// <summary>
     /// Classe Pessoa Fisica.
     /// </summary>
    public class PessoaFisica : Pessoa
    {
        /// <summary>
        /// Data de nascimento da pessoa.
        /// </summary>
        public DateTime DataDeNascimento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RG { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TituloDeEleitor { get; set; }

        public PessoaFisica(int id) : base(id)
        { }
    }
}