using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using ApplicationCore.EF;

namespace ApplicationCore.Bussiness
{
    class Personas : DML<Persona>
    {
        public async Task<Persona> Add(Persona element)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                var obj = context.Personas.Find(element.id_persona);
                if (obj == null)
                {
                    obj = new Persona();
                    context.Personas.Add(obj);
                    await context.SaveChangesAsync();

                }
                obj.id_persona = element.id_persona;
                obj.nombres_per = element.nombres_per;
                obj.primerApellido_per =element.primerApellido_per;
                obj.segundoApellido_per = element.segundoApellido_per;
                obj.telefono_per = element.telefono_per;
                await context.SaveChangesAsync(); 
               
                
            }

            return element;
        }
    

        public List<Persona> Get(Persona element)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                return context.Personas.Where(x =>

                    x.nombres_per.Contains(element.nombres_per) ||
                    x.primerApellido_per.Contains(element.primerApellido_per) ||
                    x.segundoApellido_per.Contains(element.segundoApellido_per)).ToList();


            }
        }

        public async Task<Persona> Remove(Persona element)
        {
            using (CeramicasEntities context = new CeramicasEntities())
            {
                context.Personas.Remove(element);
                await context.SaveChangesAsync();
            }

            return element;
        }
    }
}
