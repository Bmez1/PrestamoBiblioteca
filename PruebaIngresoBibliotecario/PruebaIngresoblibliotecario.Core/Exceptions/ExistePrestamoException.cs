using PruebaIngresoblibliotecario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoblibliotecario.Core.Exceptions
{
    public class ExistePrestamoException : Exception
    {
        private readonly Prestamo _prestamo;
        public ExistePrestamoException(Prestamo prestamo)
        {
            _prestamo = prestamo;
        }

        public override string Message => $"El usuario con identificacion {_prestamo.IdentificacionUsuario} " +
            $"ya tiene un libro prestado por lo cual no se le puede realizar otro prestamo";
    }
}
