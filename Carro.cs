using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_III_2020_2_sesion_1
{
    class Carro
    {
        public static List<Carro> ListaCarros;

        public int IdCarro { get; set; }
        public string VIN { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public Combustible TipoCombustible { get; set; }
        public Transmision TipoTransmision { get; set; }

        public void Add()
        {
            if (ListaCarros == null)
            {
                ListaCarros = new List<Carro>();
            }

            ListaCarros.Add(this);

            Save();
        }

        private void Save()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("Carro.txt", true);

            writer.WriteLine(IdCarro.ToString() + "," + VIN + "," + Modelo + "," + Color + "," + Marca + "," +
                TipoCombustible.ToString() + "," + TipoTransmision.ToString());

            writer.Close();
        }




        public static void Delete(int IdCarro)
        {
            if (Find(IdCarro))
            {
                foreach (Carro v in ListaCarros)
                {
                    if (v.IdCarro == IdCarro)
                        ListaCarros.Remove(v);
                }
            }
        }

        public void Delete()
        {
            if (Find(this.IdCarro))
            {
                ListaCarros.Remove(this);
            }
        }

        public static void Update(int IdCarro, int NDato)
        {
            if (Find(IdCarro))
            {
                Carro v = Search(IdCarro);

                switch (NDato)
                {
                    case 1:
                        Console.WriteLine("Nuevo Número de Chasis: ");
                        v.VIN = Scanner.NextLine();
                        break;

                    case 2:
                        Console.Write("Nueva Modelo: ");
                        v.Modelo = Scanner.NextLine();
                        break;
                    case 3:
                        Console.Write("Nuevo Color: ");
                        v.Color = Scanner.NextLine();
                        break;
                    case 4:
                        Console.Write("Nuevo Marca: ");
                        v.Marca = Scanner.NextLine();
                        break;

                    case 5:
                        Console.Write("Nuevo Combustible\n1. Gasolina.\n2. Biodiésel.\n3. Gas Natural.\n4. Diésel.\n:: ");
                        int tipo = Scanner.NextInt();
                        for (int i = 0; i < 4; i++)
                        {
                            if (tipo - 1 == i)
                            {
                                v.TipoCombustible = (Combustible)i;
                                break;
                            };
                        }
                        break;
                    case 6:
                        Console.Write("Nueva Transmisión\n1. Manual.\n2. Automatica.\n3. CVT.\n:: ");
                        int transmision = Scanner.NextInt();
                        for (int i = 0; i < 3; i++)
                        {
                            if (transmision - 1 == i)
                            {
                                v.TipoTransmision = (Transmision)i;
                                break;
                            };
                        }
                        break;
                        
                }

                v.Save();

            }

        }

        /// <summary>
        /// Muestra los datos de todos los Carroes
        /// </summary>

        public static void ToList()
        {

            foreach (Carro v in Carro.ListaCarros)
            {
                v.Show();
            }
        }

        //public string List()
        //{
        //    string todos = "";
        //    foreach (Carro Carro in ListaCarros)
        //    {
        //        todos += Carro.ToString();
        //    }
        //    return todos;
        //}

        /// <summary>
        /// Muestra los datos de un Carro
        /// </summary>
        public void Show()
        {
            Console.WriteLine(IdCarro.ToString() + VIN + Modelo + Color + Marca + TipoCombustible.ToString() + TipoTransmision.ToString());
        }

        public override string ToString()
        {
            return (IdCarro.ToString() + "\t" + Modelo + "\t" + Color + "\t" + Marca + "\t" +
                TipoCombustible.ToString() + "\t" + TipoTransmision.ToString() + "\n");
        }

        public static bool Find(int IdCarro)
        {
            foreach (Carro Carro in ListaCarros)
            {
                if (Carro.IdCarro == IdCarro) return true;
            }
            return false;
        }

        public static bool Find(string VIN)
        {
            foreach (Carro Carro in ListaCarros)
            {
                if (Carro.VIN.ToLower() == VIN.ToLower()) return true;
            }
            return false;
        }

        public static Carro Search(int IdCarro)
        {
            foreach (Carro v in ListaCarros)
            {
                if (v.IdCarro == IdCarro)
                {
                    return v;
                }
            }
            return new Carro();
        }

        public static Carro Search(string VIN)
        {
            foreach (Carro v in ListaCarros)
            {
                if (v.VIN.ToLower() == VIN.ToLower())
                {
                    return v;
                }
            }
            return new Carro();
        }

        public void SetItems(int i, string value)
        {
            switch (i)
            {
                case 0:
                    IdCarro = Convert.ToInt32(value);
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
            ListaCarros = new List<Carro>();

            System.IO.StreamReader reader = new System.IO.StreamReader("Carro.txt");

            while (!reader.EndOfStream)
            {
                string[] var = reader.ReadLine().Split(',');

                Carro v = new Carro();
                for (int i = 0; i < var.Length; i++)
                {
                    v.SetItems(i, var[i]);
                }

                ListaCarros.Add(v);

            }

            reader.Close();
        }

        public static void MenuCarro()
        {
            int option;

            LoadList();

            do
            {
                Console.Write("\tBienvenido al menú de Carros\n" +
                    "\t1. Crear Carro.\n" +
                    "\t2. Eliminar Carro.\n" +
                    "\t3. Editar Carro.\n" +
                    "\t4. Listar Carros.\n" +
                    "\t5. Busacar Carro.\n" +
                    "\t6. Salir.\n" +
                    "\t:: ");

                option = Scanner.NextInt();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\t-- Crear Carro ---");
                        Carro v = new Carro();

                        Console.Write("Código de chasis: ");
                        v.VIN = Scanner.NextLine();

                        Console.Write("Modelo: ");
                        v.Marca = Scanner.NextLine();

                        Console.Write("Color: ");
                        v.Color = Scanner.NextLine();

                        Console.Write("Marca: ");
                        v.Marca = Scanner.NextLine();

                        Console.Write("Combustible\n1. Gasolina.\n2. Biodiésel.\n3. Gas Natural.\n4. Diésel.\n:: ");
                        int tipo = Scanner.NextInt();
                        for (int i = 0; i < 4; i++)
                        {
                            if (tipo - 1 == i)
                            {
                                v.TipoCombustible = (Combustible)i;
                                break;
                            };
                        }

                        Console.Write("Nueva Transmisión\n1. Manual.\n2. Automatica.\n3. CVT.\n:: ");
                        int transmision = Scanner.NextInt();
                        for (int i = 0; i < 3; i++)
                        {
                            if (transmision - 1 == i)
                            {
                                v.TipoTransmision = (Transmision)i;
                            };
                        }
                        break;

                    case 2:
                        Console.Write("\t--- Eliminar Carro ---\nCódigo de chasis del Carro: ");
                        string VIN = Scanner.NextLine();

                        if (Find(VIN))
                        {
                            Carro vn = Search(VIN);
                            vn.Show();
                            Console.Write("¿Borrar Carro?\n\t1. Si.\n\t2. No.\n::");
                            if (Scanner.NextInt() == 1)
                            {
                                vn.Delete();
                                Console.WriteLine("¡Proceso realizado con éxito!");
                            }
                            else Console.WriteLine("¡Proceso cancelado!");

                        }

                        break;
                    case 3:

                        Console.Write("\t--- Editar datos del Carro ---\nNúmero de ID del Carro: ");
                        int IdCarro  = Scanner.NextInt();
                        Search(IdCarro).Show();
                        Console.Write("\tOpciones a editar:\n" +
                           "\t1.  Cédula.\n" +
                           "\t2.  Nombre.\n" +
                           "\t3.  Fecha de nacimiento.\n" +
                           "\t4.  Sexo.\n" +
                           "\t5.  Teléfono.\n" +
                           "\t6.  Correo.\n" +
                           "\t7.  Dirección.\n" +
                           "\t8.  Estado civil.\n" +
                           "\t:: ");

                        Update(IdCarro, Scanner.NextInt());

                        break;
                    case 4:
                        Console.WriteLine("\t-- Lista de Carro ---");
                        ToList();
                        break;

                    case 5:
                        Console.WriteLine("\t-- Buscar Carro ---\n");

                        Console.Write("Ingrese el ID del carro.\n:: ");
                        Search(Scanner.NextInt()).Show();
                        break;
                }

            } while (option != 6);
        }

    }

}
