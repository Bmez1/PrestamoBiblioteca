using PruebaIngresoblibliotecario.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoblibliotecario.Core.Interfaces.Services
{
    public interface IPrestamoService
    {
        Task<IEnumerable<Prestamo>> GetAllAsync();
        Task<Prestamo> GetByIdAsync(Guid id);
        Task<Prestamo> CreateAsync(Prestamo prestamo);
    }
}
