using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Noticia
    {
        private int id;
        private string descripcion;
        private string cuerpo;
        private DateTime fechaCreacion;
        private Usuario idAutor;
        private int cantVisitas;
        private string posicion;
        private int esVigente;



        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }
        
        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }
        
        public Usuario IdAutor
        {
            get { return idAutor; }
            set { idAutor = value; }
        }
        
        public int CantVisitas
        {
            get { return cantVisitas; }
            set { cantVisitas = value; }
        }
       
        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
     
        public int EsVigente
        {
            get { return esVigente; }
            set { esVigente = value; }
        }

    }
}
