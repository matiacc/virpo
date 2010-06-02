﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
   
    public class Publicidad
    {
        private int id;
        private string entidad;
        private string nombreContacto;
        private string telContacto;
        private string mailContacto;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private int frecuencia;
        private string imagen;
        private string consulta;
        private int idEstado;
        private int impresiones;
        private int clicks;
        private string url;
        private int disposicion;

                        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Entidad
        {
            get { return entidad; }
            set { entidad = value; }
        }
        
        public string NombreContacto
        {
            get { return nombreContacto; }
            set { nombreContacto = value; }
        }
        
        public string TelContacto
        {
            get { return telContacto; }
            set { telContacto = value; }
        }
            
        public string MailContacto
        {
            get { return mailContacto; }
            set { mailContacto = value; }
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
        
        public int Frecuencia
        {
            get { return frecuencia; }
            set { frecuencia = value; }
        }
        
        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
        
        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }

        public int IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        public int Impresiones
        {
            get { return impresiones; }
            set { impresiones = value; }
        }

        public int Clicks
        {
            get { return clicks; }
            set { clicks = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }


        public int Disposicion
        {
            get { return disposicion; }
            set { disposicion = value; }
        }
    }
}
