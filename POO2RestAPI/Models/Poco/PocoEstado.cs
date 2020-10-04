using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.Poco
{
    public class PocoEstado
    {
        public PocoEstado() { }

        public int IdEstado { get; set; }

        public int IdRegiao { get; set; }

        public string Descricao { get; set; }

        public string SiglaUF { get; set; }

        public string RegiaoBrasil { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }
    }
}