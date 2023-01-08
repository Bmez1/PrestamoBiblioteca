using PruebaIngresoblibliotecario.Core.Entities;
using PruebaIngresoblibliotecario.Core.Enums;
using PruebaIngresoblibliotecario.Core.Exceptions;
using PruebaIngresoblibliotecario.Core.Interfaces.Repository;
using PruebaIngresoblibliotecario.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoblibliotecario.Core.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoRepository _prestamoRepository;

        public PrestamoService(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public async Task<Prestamo> CreateAsync(Prestamo prestamo)
        {
            if (prestamo.TipoUsuario == Enums.TipoUsuario.INVITADO && _prestamoRepository.ExisteCliente(prestamo.IdentificacionUsuario))
                throw new ExistePrestamoException(prestamo);

            GetFechaMaximaPrestamo(prestamo);
            return await _prestamoRepository.CreateAsync(prestamo);
        }

        public async Task<IEnumerable<Prestamo>> GetAllAsync() => await _prestamoRepository.GetAllAsync();
        

        public async Task<Prestamo> GetByIdAsync(Guid id)
        {
            return await _prestamoRepository.GetByIdAsync(id);
        }

        private void GetFechaMaximaPrestamo(Prestamo prestamo)
        {
            int maximoDiasPrestamo = DiasPrestamos.dias[prestamo.TipoUsuario.ToString()];
            var fechaPrestamo = prestamo.FechaPrestamo;

            Func<DayOfWeek, int> agregarDia = dia => dia == DayOfWeek.Sunday || dia == DayOfWeek.Saturday ? 1 : 0;

            int cantidadFind = 0;

            for (int i = 0; i < maximoDiasPrestamo; i++)
            {
                fechaPrestamo = fechaPrestamo.AddDays(1);
                cantidadFind += agregarDia(fechaPrestamo.DayOfWeek);
            }

            prestamo.FechaMaximaDevolucion = prestamo.FechaPrestamo.AddDays(cantidadFind + maximoDiasPrestamo);      

        }
    }
}
