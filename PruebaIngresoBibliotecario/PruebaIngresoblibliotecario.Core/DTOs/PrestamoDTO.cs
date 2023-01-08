using PruebaIngresoblibliotecario.Core.Enums;
using PruebaIngresoblibliotecario.Core.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PruebaIngresoblibliotecario.Core.DTOs
{
    public class PrestamoDTO
    {
        [Required]
        public Guid Isbn { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "La identificación debe poseer máximo 10 digitos")]
        public string IdentificacionUsuario { get; set; }
        [Required]
        [ExisteTipoUsuario(ErrorMessage = "El tipo de usuario no existe")]
        public TipoUsuario TipoUsuario { get; set; }
    }
}
