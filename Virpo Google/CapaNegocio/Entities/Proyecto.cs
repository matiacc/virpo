using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Proyecto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string imagen;
        private string licencia;
        private string genero;
        private string tags;
        private int tipo; //0 Publico 1 Privado
        private Usuario usuario;
        private DateTime fechaCreacion;
        private int idGrupo;
        private int idBanda;

        #region Propiedades

        public int IdBanda
        {
            get { return idBanda; }
            set { idBanda = value; }
        }
        public int IdGrupo
        {
            get { return idGrupo; }
            set { idGrupo = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public string Licencia
        {
            get { return licencia; }
            set { licencia = value; }
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        #endregion

    }
}
