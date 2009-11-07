using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class PostGrupo
    {
        private int id;
        private int idTopic;
        private DateTime fechaCreacion;
        private Usuario creador;
        private string comentario;

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int IdTopic
        {
            get { return idTopic; }
            set { idTopic = value; }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }


        public Usuario Creador
        {
            get { return creador; }
            set { creador = value; }
        }


        public string Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        #endregion
        
    }
}
