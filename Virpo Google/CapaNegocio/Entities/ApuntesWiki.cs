using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class ApuntesWiki
    {
        int idMusico;
        int idArticulo;
        DateTime fechaAlta;

        #region Propiedades

        public int IdMusico
        {
            get { return idMusico; }
            set { idMusico = value; }
        }

        public int IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }

        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        #endregion

    }
}
