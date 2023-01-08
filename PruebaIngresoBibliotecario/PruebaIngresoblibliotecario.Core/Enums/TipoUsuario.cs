using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoblibliotecario.Core.Enums
{
    public enum TipoUsuario
    {
        AFILIADO = 1, EMPLEADO, INVITADO
    }

    public class DiasPrestamos
    {
        public static IDictionary<string, int> dias { get; } = new Dictionary<string, int>()
        {
            { "AFILIADO", 10 },
            { "EMPLEADO", 8 },
            { "INVITADO", 7 }
        };
    }
}
