using PruebaIngresoblibliotecario.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaIngresoblibliotecario.Core.Validations
{
    public class ExisteTipoUsuario : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Enum.IsDefined(typeof(TipoUsuario), value);
            
        }
    }
}
