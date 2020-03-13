using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using Pruebas.EF;

namespace ApplicationCore.Bussiness
{
    class Providers: DML<Proveedores>
    {
        public async Task<Proveedores> Add(Proveedores prov)
        {

            using (CeramicasEntities context = new CeramicasEntities())
            {
                var obj = context.Proveedores.Find(prov.id_prov);
                if (obj == null)
                {
                    obj = new Proveedores();
                    context.Proveedores.Add(obj);
                    await context.SaveChangesAsync();

                }
                obj.id_prov = prov.id_prov;
                obj.ciudad_prov = prov.ciudad_prov;
                obj.id_per = prov.id_per;
               
                await context.SaveChangesAsync();


            }

            return prov;
        }

        public List<Proveedores> Get(Proveedores prov)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Proveedores.Where(x =>
                    x.id_prov == prov.id_prov ||
                    x.ciudad_prov== prov.ciudad_prov ||
                    x.id_per== prov.id_per
                    ).ToList();


            }
        }

        public async Task<Proveedores> Remove(Proveedores prov)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Proveedores.Remove(prov);
                await context.SaveChangesAsync();
            }

            return prov;
        }
    }
}
