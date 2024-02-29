﻿using System;

namespace Application.DTOs
{
    public class CustomerDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public int Edad { get; set; }
    }
}
