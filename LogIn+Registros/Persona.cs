using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn_Registros
{
    internal class Persona
    {
        public string dni
        {
            get;
            set;
        }
        public string nombre
        {
            get;
            set;
        }
        public string domicilio
        {
            get;
            set;
        }
        public DateTime fechanac
        {
            get;
            set;
        }
        public DateTime fechaing { get; set; }
        public string puesto { get; set; }
        public int salario { get; set; }
    }
}

