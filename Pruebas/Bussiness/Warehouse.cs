using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using Pruebas.EF;

namespace ApplicationCore.Bussiness
{
    class Warehouse
    {
        public async Task<Bodega> Add(Bodega bod)
        {

            using (CeramicasEntities context = new CeramicasEntities())
            {
                var obj = context.Bodega.Find(bod.id_bog);
                if (obj == null)
                {
                    obj = new Bodega();
                    context.Bodega.Add(obj);
                    await context.SaveChangesAsync();

                }
                obj.id_bog = bod.id_bog;
                obj.id_prod = bod.id_prod;
                obj.cantidad = bod.cantidad;

                await context.SaveChangesAsync();


            }

            return bod;
        }

        public List<Bodega> Get(Bodega bod)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Bodega.Where(x =>
                    x.id_bog == bod.id_bog ||
                    x.id_prod == bod.id_prod ||
                    x.cantidad == bod.cantidad
                    ).ToList();


            }
        }

        public async Task<Bodega> Remove(Bodega bod)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Bodega.Remove(bod);
                await context.SaveChangesAsync();
            }

            return bod;
        }
    }
}

