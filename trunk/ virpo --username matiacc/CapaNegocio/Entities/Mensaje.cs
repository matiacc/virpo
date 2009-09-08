using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Mensaje
    {
        private int id;
        private AvisoClasificado aviso;
        private Usuario remitente;
        private DateTime fecha;
        private string msj;
        private DateTime fechaRespuesta;
        private EstadoMensaje estado;
        private string respuesta;

       

        #region Propiedades
        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public AvisoClasificado Aviso
        {
            get { return aviso; }
            set { aviso = value; }
        }
        

        public Usuario Remitente
        {
            get { return remitente; }
            set { remitente = value; }
        }
        

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public string Msj
        {
            get { return msj; }
            set { msj = value; }
        }
        

        public DateTime FechaRespuesta
        {
            get { return fechaRespuesta; }
            set { fechaRespuesta = value; }
        }
       
        public EstadoMensaje Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        #endregion
    }
}
