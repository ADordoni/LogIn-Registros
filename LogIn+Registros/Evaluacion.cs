using System;
using System.Collections.Generic;
using System.Text;

namespace LogIn_Registros
{
    internal class Evaluacion
    {
        int numero;
        
        public Evaluacion(string number)
        {
            try
            {
                numero = int.Parse(number);
            }
            catch (FormatException)
            {
                numero = 0;
            }
        }        
        public int MandarNumero()
        {
            return numero;
        }        
    }
}
