using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using ApplicationCore.EF;

namespace ApplicationCore.Bussiness
{
    class Productos: DML<Producto>
    {
        public async Task<Producto> Add(Producto entity)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Productos.Add(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }

        public List<Producto> Get(Producto entity)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Productos.Where(x =>

                    x.nombre_prod.Contains(entity.nombre_prod) ||
                    x.descp_prod.Contains(entity.descp_prod)).ToList();


            }
        }

        public async Task<Producto> Remove(Producto entity)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Productos.Remove(entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}

