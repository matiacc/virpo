using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Banda
    {
        private int id;
        private string nombre;
        private string descripcion;
        private Genero genero;
        private string paginaWeb;
        private string imagen;
        private DateTime fechaInicio;
        private Localidad localidad;
        private string imagenThumb;
        private DateTime fecSistema;

        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }


        public Genero Genero
        {
            get { return genero; }
            set { genero = value; }
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
        public string PaginaWeb
        {
            get { return paginaWeb; }
            set { paginaWeb = value; }
        }

        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
        public string ImagenThumb
        {
            get { return imagenThumb; }
            set { imagenThumb = value; }
        }
        public DateTime FecSistema
        {
            get { return fecSistema; }
            set { fecSistema = value; }
        }
        #endregion
    }
}