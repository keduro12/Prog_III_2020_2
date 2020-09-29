using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_III_2020_2_sesion_1
{
    class Program
    {
        public static void Main(string[] args)
        {

            Vendedor.LoadList();

            foreach (Vendedor v in Vendedor.ListaVendedor)
            {
                v.Show();
            }

            Console.Read();
            
        }
    }
}
