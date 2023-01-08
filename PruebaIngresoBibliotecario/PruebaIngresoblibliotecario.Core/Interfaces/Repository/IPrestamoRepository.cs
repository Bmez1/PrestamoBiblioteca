using PruebaIngresoblibliotecario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoblibliotecario.Core.Interfaces.Repository
{
    public interface IPrestamoRepository : IBaseRepository<Prestamo>
    {
        bool ExisteCliente(string identificacion);

    }
}
