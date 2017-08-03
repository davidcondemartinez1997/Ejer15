using Ejer15.Models;
using Ejer15.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejer15.Servicios
{
    public class EntradasService : IEntradasService
    {
        private IEntradasRepository EntradasRepository;

        public EntradasService(IEntradasRepository _EntradasRepository)
        {
            this.EntradasRepository = _EntradasRepository;
        }

        public Entrada Create(Entrada Entrada)
        {
            using (var context = new ApplicationDbContext())
            {
                ApplicationDbContext.applicationDbContext = context;
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Entrada = EntradasRepository.Create(Entrada);

                        context.SaveChanges();

                        dbContextTransaction.Commit();

                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw new Exception("He hecho rollback de la transaccion", e);
                    }

                }
                return Entrada;
            }
        }
    }
}