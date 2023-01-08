using Microsoft.EntityFrameworkCore.Internal;
using PruebaIngresoBibliotecario.Infraestructura.Context;
using PruebaIngresoblibliotecario.Core.Entities;
using PruebaIngresoblibliotecario.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infraestructura.Repositories
{
    public class Prestamorepository : BaseRepository<Prestamo>, IPrestamoRepository
    {
        private readonly PersistenceContext _context;

        public Prestamorepository(PersistenceContext context) : base(context)
        {
            _context = context;
        }

        public bool ExisteCliente(string identificacion) => _context.Prestamos.Any(x => x.IdentificacionUsuario == identificacion);

    }
}
