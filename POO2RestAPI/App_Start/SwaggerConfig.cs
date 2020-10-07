using System.Web.Http;
using WebActivatorEx;
using POO2RestAPI;
using Swashbuckle.Application;
using System.Linq;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace POO2RestAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            var filePath = Path.Combine(System.AppContext.BaseDirectory, "C:\\Users\\alexa\\Desktop\\Aulas\\POO2\\workspace\\Projeto-POO2-2020-2\\POO2RestAPI\\Docs\\POO2RestAPI.xml");
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.Schemes(new[] { "http", "https" });
                        c.SingleApiVersion("v1", "POO2RestAPI - 2020")
                            .Description("Conjunto de Recursos diponível para o projeto.")
                            .TermsOfService("Termos de Serviço")
                            .Contact(cc => cc
                                .Name("Alexander Rodrigues do Imperio")
                                .Url("http://POO2RestAPI.com/contato")
                                .Email("conato@POO2RestAAPI.com.br"))
                            .License(lc => lc
                                .Name("Licença do Projeto")
                                .Url("http://POO2RestAPI.com.br/licenca"));

                        c.PrettyPrint();
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                        c.ApiKey("apikey")
                            .Description("API Key para acessar API de forma segura.")
                            .Name("API-key-projeto")
                            .In("header");
                        c.IncludeXmlComments(filePath);
                    })
              

                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("POO2RestAPI - 2020 - Swagger UI");
                        c.DocExpansion(DocExpansion.List);
                        c.EnableDiscoveryUrlSelector();
                    });

        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\Docs\POO2RestAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
