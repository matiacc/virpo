using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class AvisoClasificado
    {
        private int id;
        private string descripcion;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private List<string> imagen;
        private double precio;
        private Usuario dueño;
        private EstadoAvisoClasificado estado;
        private string titulo;
        private string imagenThumb;
        private Rubro rubro;
        private string ubicacion;
        private string moneda;

        public AvisoClasificado()
        {
            imagen = new List<string>();
        }
        
        #region Propiedades
        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }
        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        public string ImagenThumb
        {
            get { return imagenThumb; }
            set { imagenThumb = value; }
        }
        public Rubro Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }

        
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
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
        
        public DateTime FechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }
        
        public DateTime FechaFin
        {
            get { return fechaFin; }
            set { fechaFin = value; }
        }

        public List<string> Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        
        
        
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        
        public Usuario Dueño
        {
            get { return dueño; }
            set { dueño = value; }
        }
        

        public EstadoAvisoClasificado Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion
    }
}
