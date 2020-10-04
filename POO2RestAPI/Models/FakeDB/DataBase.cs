using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POO2RestAPI.Models.FakeDB
{
    public static class DataBase
    {
        private static List<PessoaFisica> pessoasFisicas;

        public static List<PessoaFisica> PessoaFisicas
        {
            get 
            {
                if(pessoasFisicas == null)
                {
                    pessoasFisicas = new List<PessoaFisica>();
                    preencherPessoasFisicas();
                }
                return pessoasFisicas;
            }
        }

        private static void preencherPessoasFisicas()
        {

            pessoasFisicas.Add(CriarRegistro(4, "12345678900", DateTime.Now, new DateTime(1990, 04, 02),"Severino", "123456789 SSP/RJ", "123456789"));

            PessoaFisica pf = new PessoaFisica(1);
            pf.CPF = "12345678900";
            pf.DataDeNascimento = new DateTime(1990, 04, 20);
            pf.Nome = "Alexander";
            pf.DataDeInscricao = DateTime.Now;
            pf.RG = "123456789 SSP/RJ";
            pf.TituloDeEleitor = "123456789";
            pessoasFisicas.Add(pf);

            PessoaFisica pf2 = new PessoaFisica(2)
            {
                CPF = "12345678900",
                DataDeNascimento = new DateTime(1990, 04, 20),
                Nome = "Gabriel",
                DataDeInscricao = DateTime.Now,
                RG = "123456789 SSP/RJ",
                TituloDeEleitor = "123456789",
            };
            pessoasFisicas.Add(pf2);

            pessoasFisicas.Add(new PessoaFisica(3)
            {
                CPF = "12345678900",
                DataDeNascimento = new DateTime(1990, 04, 20),
                Nome = "Erick",
                DataDeInscricao = DateTime.Now,
                RG = "123456789 SSP/RJ",
                TituloDeEleitor = "123456789",
            });

        }

        private static PessoaFisica CriarRegistro(int id, string cpf, DateTime dataDeInscricao, DateTime dataDeNascimento, string nome, string rg, string tituloDeEleitor)
        {

            return new PessoaFisica(id)
            {
                CPF = cpf,
                DataDeNascimento = dataDeNascimento,
                Nome = nome,
                DataDeInscricao = dataDeInscricao,
                RG = rg,
                TituloDeEleitor = tituloDeEleitor
            };
        }

    }
}
