using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.Poco
{
    public class PocoRegiao
    {
        public PocoRegiao() { }

        public int IdRegiao { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }
    }
}