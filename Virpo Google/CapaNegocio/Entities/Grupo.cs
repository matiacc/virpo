using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Grupo
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string tema; //Temas: Instrumento, Bandas, Ubicacion, Club de Fan, Escuela, Generico
        private string imagen;
        private string tags;
        private Usuario creador;
        private string enlaces;

        
        //private int idProyecto; CREAR IDGRUPO EN PROYECTO 
        //private int idDebate;

        #region Propiedades
        public string Enlaces
        {
            get { return enlaces; }
            set { enlaces = value; }
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
        public string Tema
        {
            get { return tema; }
            set { tema = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public string Tags
        {
            get { return tags; }
            set { tags = value; }
        }
        public Usuario Creador
        {
            get { return creador; }
            set { creador = value; }
        }
        #endregion
    }
}
