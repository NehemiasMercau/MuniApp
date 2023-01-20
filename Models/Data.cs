using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MuniApp.Negocio.entidades;

namespace MuniApp.Models;

public static class Data
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ODAMuniDBContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ODAMuniDBContext>>()))
        {
            return;
        }
    }
}