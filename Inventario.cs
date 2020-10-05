using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_III_2020_2_sesion_1
{
    class Inventario
    {
        public static List<Inventario> ListaInventario;
        public int IdInventario { get; set; }
        public Carro Car { get; set; }
        public int Cantidad { get; set; }
        public long PrecioBase { get; set; }
        public long PrecioVenta { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }

        public void Add()
        {
            if (ListaInventario == null)
            {
                ListaInventario = new List<Inventario>();
            }

            ListaInventario.Add(this);

            Save();
        }

        private void Save()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("Inventario.txt", true);

            writer.WriteLine(IdInventario.ToString() + "," + Car.ToString() + "," + Cantidad.ToString() + "," + PrecioBase.ToString() + "," + PrecioVenta.ToString()
                + "," + FechaIngreso.ToShortDateString() + "," + FechaSalida.ToShortDateString());

            writer.Close();
        }




        public static void Delete(int IdInventario)
        {
            if (Find(IdInventario))
            {
                foreach (Inventario v in ListaInventario)
                {
                    if (v.IdInventario == IdInventario)
                        ListaInventario.Remove(v);
                }
            }
        }

        public void Delete()
        {
            if (Find(this.IdInventario))
            {
                ListaInventario.Remove(this);
            }
        }

        public static void Update(int IdInventario, int NDato)
        {
            if (Find(IdInventario))
            {
                Inventario v = Search(IdInventario);

                switch (NDato)
                {
                    case 1:
                        Console.WriteLine("\nNueva Cantidad: ");
                        v.Cantidad = Scanner.NextInt();
                        break;

                    case 2:
                        Console.Write("\nNuevo Precio Base: ");
                        v.PrecioBase = Scanner.NextLong();
                        break;
                    case 3:
                        Console.Write("\nNuevo Precio de venta: ");
                        v.PrecioVenta = Scanner.NextLong();
                        break;
                    case 4:
                        Console.Write("\nFecha de ingreso dd/MM/yyy: ");
                        v.FechaIngreso = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);
                        break;

                    case 5:
                        Console.Write("\nFecha de Salida dd/MM/yyy: ");
                        v.FechaSalida = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);
                        break;

                }

                v.Save();

            }

        }

        /// <summary>
        /// Muestra los datos de todos los Inventarioes
        /// </summary>

        public static void ToList()
        {

            foreach (Inventario v in Inventario.ListaInventario)
            {
                v.Show();
            }
        }

        //public string List()
        //{
        //    string todos = "";
        //    foreach (Inventario Inventario in ListaInventario)
        //    {
        //        todos += Inventario.ToString();
        //    }
        //    return todos;
        //}

        /// <summary>
        /// Muestra los datos de un Inventario
        /// </summary>
        public void Show()
        {
            Console.WriteLine(IdInventario.ToString().PadRight(4) + Car.ToString() + Cantidad.ToString() + PrecioBase.ToString()+
                PrecioVenta.ToString() + FechaIngreso.ToString() + FechaSalida.ToString());
        }

        public override string ToString()
        {
            return (IdInventario.ToString() + "\t" + Car.ToString() + "\t" + Cantidad.ToString() + "\t" + PrecioBase.ToString() + "\t" +
                PrecioVenta.ToString() + "\t" + FechaIngreso.ToString() + "\t" + FechaSalida.ToString() + "\n");
        }

        public static bool Find(int IdInventario)
        {
            foreach (Inventario Inventario in ListaInventario)
            {
                if (Inventario.IdInventario == IdInventario) return true;
            }
            return false;
        }

        public static bool Find(string VIN)
        {
            foreach (Inventario Inventario in ListaInventario)
            {
                if (Inventario.VIN.ToLower() == VIN.ToLower()) return true;
            }
            return false;
        }

        public static Inventario Search(int IdInventario)
        {
            foreach (Inventario v in ListaInventario)
            {
                if (v.IdInventario == IdInventario)
                {
                    return v;
                }
            }
            return new Inventario();
        }

        public static Inventario Search(string VIN)
        {
            foreach (Inventario v in ListaInventario)
            {
                if (v.VIN.ToLower() == VIN.ToLower())
                {
                    return v;
                }
            }
            return new Inventario();
        }

        public void SetItems(int i, string value)
        {
            switch (i)
            {
                case 0:
                    IdInventario = Convert.ToInt32(value);
                    break;
                case 1:
                    VIN = (string)value;
                    break;
                case 2:
                    Modelo = (string)value;
                    break;
                case 3:
                    Color = (string)value;
                    break;
                case 4:
                    Marca = (string)value;
                    break;
                case 5:
                    TipoCombustible = (Combustible)Combustible.Parse(typeof(Combustible), value.ToString());
                    break;
                case 6:
                    TipoTransmision = (Transmision)Transmision.Parse(typeof(Transmision), value.ToString());
                    break;
            }
        }

        public static void LoadList()
        {
            ListaInventario = new List<Inventario>();
            if (System.IO.File.Exists("Inventario.txt"))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("Inventario.txt");

                while (!reader.EndOfStream)
                {
                    string[] var = reader.ReadLine().Split(',');

                    Inventario v = new Inventario();
                    for (int i = 0; i < var.Length; i++)
                    {
                        v.SetItems(i, var[i]);
                    }

                    ListaInventario.Add(v);

                }

                reader.Close();
            }
        }
    }
}
