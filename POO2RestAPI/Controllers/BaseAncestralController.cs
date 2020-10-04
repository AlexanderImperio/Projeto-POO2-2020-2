using POO2RestAPI.Models.ProjetoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POO2RestAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseAncestralController : ApiController
    {
        private ModelProjetoDB contexto;

        /// <summary>
        /// 
        /// </summary>
        protected ModelProjetoDB Contexto
        {
            get { return this.contexto;  }
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseAncestralController(): base()
        {
            this.contexto = new ModelProjetoDB();
        }

    }
}
