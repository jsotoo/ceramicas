using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using Pruebas.EF;
using ApplicationCore.Bussiness;
namespace Pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usu = new Usuario();
            usu.id_usu = 1;
            usu.nombres_usu = "Jonathan Steven";
            usu.Apellidos_usu = "Soto Orjuela";
            usu.tipo_usu = "C";
            usu.telefono_usu = 23123123;
            InsertarOne(usu);
        }

        public static async void InsertarOne(Usuario u)
        {
            Users e = new Users();
            Usuario usu = await e.Add(u);

        }
    }

  }

