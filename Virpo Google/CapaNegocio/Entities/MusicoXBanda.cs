using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class MusicoXBanda
    {
        private int idUsuario;
        private int idBanda;
        private bool creador;
        private DateTime fecAgregado;

        #region Propiedades

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public int IdBanda
        {
            get { return idBanda; }
            set { idBanda = value; }
        }
        public bool Creador
        {
            get { return creador; }
            set { creador = value; }
        }
        public DateTime FecAgregado
        {
            get { return fecAgregado; }
            set { fecAgregado = value; }
        }
        #endregion
    }
}
