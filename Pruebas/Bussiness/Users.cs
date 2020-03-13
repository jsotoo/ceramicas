using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using ApplicationCore.Bussiness;
using Pruebas.EF;

namespace ApplicationCore.Bussiness
{
   public class Users : DML<Usuario>
    {
        CeramicasEntities context = null;
        public Users()
        {
            context = new CeramicasEntities();
        }
        public async Task<Usuario> Add(Usuario element)
        {
            try
            { 

                element = context.Usuario.SingleOrDefault(x => x.id_usu == element.id_usu);
                if (element == null)
                {
                    element = new Usuario();
                    context.Usuario.Add(element);
                    await context.SaveChangesAsync();

                }
            
                element.tipo_usu = element.tipo_usu;
                element.nombres_usu = element.nombres_usu;
                element.Apellidos_usu = element.Apellidos_usu;
                element.telefono_usu = element.telefono_usu;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return element;
        }
    

        public List<Usuario> Get(Usuario element)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Usuario.Where(x =>

                    x.nombres_usu.Contains(element.nombres_usu) ||
                    x.Apellidos_usu.Contains(element.Apellidos_usu)).ToList();


            }
        }

        public async Task<Usuario> Remove(Usuario element)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Usuario.Remove(element);
                await context.SaveChangesAsync();
            }

            return element;
        }
    }
}
