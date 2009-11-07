using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Entities;

namespace CapaNegocio.Entities
{

    public class Evento
    {
        private int id;
        private String lugar;
        private String nombre;
        private String ubicacion;
        private DateTime fecha;
        private DateTime hora;
        private String imagen;
        private String descripcion;
        private Usuario musico;
        private Banda banda;
        private String estado;

        



        #region Propiedades

        public Banda Banda
        {
            get { return banda; }
            set { banda = value; }
        }

        public String Lugar
        {
            get { return lugar; }
            set { lugar = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        

        public String Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }
        

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        

        public String Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        

        public Usuario Musico
        {
            get { return musico; }
            set { musico = value; }
        }

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }



        #endregion








    }


}