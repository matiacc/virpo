using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Composicion
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string tipo;
        private string tempo;
        private Tonalidad tonalidad;
        private Instrumento instrumento;
        private Usuario usuario;
        private string audio;
        



        # region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Audio
        {
            get { return audio; }
            set { audio = value; }
        }
        public Tonalidad Tonalidad
        {
            get { return tonalidad; }
            set { tonalidad = value; }
        }
        
        public Instrumento Instrumento
        {
            get { return instrumento; }
            set { instrumento = value; }
        }
      
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        
        public string Tempo
        {
            get { return tempo; }
            set { tempo = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion
    }
}
