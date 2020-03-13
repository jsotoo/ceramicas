using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using Pruebas.EF;

namespace ApplicationCore.Bussiness
{
    public class Products: DML<Productos>
    {

        public async Task<Productos> Add(Productos prod)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Productos.Add(prod);
                await context.SaveChangesAsync();
            }

            return prod;
        }

        public List<Productos> Get(Productos prod)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Productos.Where(x =>

                    x.nombre_prod.Contains(prod.nombre_prod) ||
                    x.descp_prod.Contains(prod.descp_prod)).ToList();


            }
        }

        public async Task<Productos> Remove(Productos prod)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Productos.Remove(prod);
                await context.SaveChangesAsync();
            }

            return prod;
        }
    }
}

