using Ejer15.Models;
using Ejer15.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejer15.Repository
{
    public class EntradasRepository : IEntradasRepository
    {
        public Entrada Create(Entrada Entrada)
        {
            return ApplicationDbContext.applicationDbContext.Entradas.Add(Entrada);
        }
    }
}