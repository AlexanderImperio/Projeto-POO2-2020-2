using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.FakeDB
{    
    
    /// <summary>
     /// Classe Pessoa Jurídica.
     /// </summary>
    public class PessoaJuridica : Pessoa
    {
        /// <summary>
        /// 
        /// </summary>
        public string CNPJ { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string IE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CNAE { get; set; }

        public PessoaJuridica(int identificador) : base(identificador)
        { }
    }
}