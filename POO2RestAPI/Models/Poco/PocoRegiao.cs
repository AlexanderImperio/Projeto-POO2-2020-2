using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.Poco
{
    public class PocoRegiao
    {
        public PocoRegiao() { }

        [Key]
        public int IdRegiao { get; set; }

        [Required]
        public string Descricao { get; set; }

        public DateTime DataInsert { get; set; }

        public DateTime? DataUpdate { get; set; }
    }
}