using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string password;
        private string imagen;
        private string imagenThumb;
        private string barrio;
        private string eMail;
        private string telFijo;
        private string telMovil;
        private DateTime fecNac;
        private string sexo;
        private int idPermiso;
        private int idLocalidad;
        private int idTipoUsuario;
        private int idRangoPosteo;
        private int cantPostHechos;
        private int idInstrumento;
        
        #region Propiedades

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
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        public string ImagenThumb
        {
            get { return imagenThumb; }
            set { imagenThumb = value; }
        }
        public string Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }
        public string EMail
        {
            get { return eMail; }
            set { eMail = value; }
        }
        public string TelFijo
        {
            get { return telFijo; }
            set { telFijo = value; }
        }
        public string TelMovil
        {
            get { return telMovil; }
            set { telMovil = value; }
        }
        public DateTime FecNac
        {
            get { return fecNac; }
            set { fecNac = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public int IdPermiso
        {
            get { return idPermiso; }
            set { idPermiso = value; }
        }
        public int IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }
        public int IdTipoUsuario
        {
            get { return idTipoUsuario; }
            set { idTipoUsuario = value; }
        }
        public int IdRangoPosteo
        {
            get { return idRangoPosteo; }
            set { idRangoPosteo = value; }
        }
        public int CantPostHechos
        {
            get { return cantPostHechos; }
            set { cantPostHechos = value; }
        }
        public int IdInstrumento
        {
            get { return idInstrumento; }
            set { idInstrumento = value; }
        }
        #endregion
    }
}
