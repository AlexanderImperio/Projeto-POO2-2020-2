using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.Poco
{
    public class PocoMunicipio
    {
        public PocoMunicipio() { }

        public int IdMunicipio { get; set; }

        public int IdEstado { get; set; }

        public string Descricao { get; set; }
       
        public string SiglaUF { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }
    }
}