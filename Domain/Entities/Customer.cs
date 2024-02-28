﻿using Domain.Common;
using System;

namespace Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {
        private int _edad;

        public string Nombe { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public int Edad
        {
            get
            {
                if(this._edad <= 0)
                {
                    this._edad = new DateTime(DateTime.Now.Subtract(this.FechaNacimiento).Ticks).Year - 1;
                }
                return this._edad;
            }
        }
    }
}
