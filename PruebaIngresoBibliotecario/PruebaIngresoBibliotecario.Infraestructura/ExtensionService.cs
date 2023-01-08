using Microsoft.Extensions.DependencyInjection;
using PruebaIngresoBibliotecario.Infraestructura.Repositories;
using PruebaIngresoblibliotecario.Core.Interfaces.Repository;
using PruebaIngresoblibliotecario.Core.Interfaces.Services;
using PruebaIngresoblibliotecario.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaIngresoBibliotecario.Infraestructura
{
    public static class ExtensionService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPrestamoRepository, Prestamorepository>();
            return services;

        }
    }
}
