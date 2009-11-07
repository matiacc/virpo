using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class TopicGrupo
    {
        private int id;
        private Grupo grupo;
        private int visitas;
        private Usuario creador;
        private string titulo;
        private DateTime fechaCreacion;
        private PostGrupo ultimoPost;

        #region Propiedades
        public Grupo Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Visitas
        {
            get { return visitas; }
            set { visitas = value; }
        }

        public Usuario Creador
        {
            get { return creador; }
            set { creador = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }


        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        public PostGrupo UltimoPost
        {
            get { return ultimoPost; }
            set { ultimoPost = value; }
        }
        #endregion
    }
}
