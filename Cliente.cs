using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_III_2020_2_sesion_1
{
    class Cliente : Persona
    {
        public static List<Cliente> ListaClientes;

        public int IdCliente { get; set; }

        public void Add()
        {
            if (ListaClientes == null)
            {
                ListaClientes = new List<Cliente>();
            }

            ListaClientes.Add(this);

            Save();
        }

        private void Save()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("Cliente.txt", true);

            writer.WriteLine(Cedula.ToString() + "," + Nombre + "," + FechaNacimiento.ToShortDateString() + "," +
                Sexo.ToString() + "," + Telefono.ToString() + "," + Correo + "," + Direccion + "," +
                EstadoCivil.ToString() + "," + IdCliente.ToString());

            writer.Close();
        }




        public static void Delete(int IdCliente)
        {
            if (Find(IdCliente))
            {
                foreach (Cliente v in ListaClientes)
                {
                    if (v.IdCliente == IdCliente)
                        ListaClientes.Remove(v);
                }
            }
        }

        public void Delete()
        {
            if (Find(this.IdCliente))
            {
                ListaClientes.Remove(this);
            }
        }

        public static void Update(long CedCliente, int NDato)
        {
            if (Find(CedCliente))
            {
                Cliente v = Search(CedCliente);

                switch (NDato)
                {
                    case 1:
                        Console.Write("Nueva Cedula: ");
                        v.Cedula = Scanner.NextLong();
                        break;
                    case 2:
                        Console.Write("Nuevo Nombre: ");
                        v.Nombre = Scanner.NextLine();
                        break;
                    case 3:
                        Console.Write("Nueva Fecha de nacimiento dd/MM/yyy");
                        v.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);
                        break;
                    case 4:
                        Console.Write("Nuevo Sexo\n1. Femenino.\n2. Masculino.\n::");
                        if (Scanner.NextInt() == 1) v.Sexo = Sexo.Femnino;
                        else v.Sexo = Sexo.Masculino;
                        break;
                    case 5:
                        Console.Write("Nuevo Teléfono: ");
                        v.Telefono = Scanner.NextLong();
                        break;
                    case 6:
                        Console.Write("Nuevo Correo: ");
                        v.Correo = Scanner.NextLine();
                        break;
                    case 7:
                        Console.Write("Nueva Dirección: ");
                        v.Direccion = Scanner.NextLine();
                        break;
                    case 8:
                        Console.Write("Nuevo Estado civil\n1. Soltero.\n2. Casado.\n3. Viudo.\n4. Divorciado.\n5. Union libre.\n:: ");
                        int estado = Scanner.NextInt();
                        for (int i = 0; i < 5; i++)
                        {
                            if (estado - 1 == i)
                            {
                                v.EstadoCivil = (EstadoCivil)i;
                                break;
                            };
                        }
                        break;
                }

                v.Save();

            }

        }

        /// <summary>
        /// Muestra los datos de todos los Clientees
        /// </summary>

        public static void ToList()
        {

            foreach (Cliente v in Cliente.ListaClientes)
            {
                v.Show();
            }
        }

        //public string List()
        //{
        //    string todos = "";
        //    foreach (Cliente Cliente in ListaClientes)
        //    {
        //        todos += Cliente.ToString();
        //    }
        //    return todos;
        //}

        /// <summary>
        /// Muestra los datos de un Cliente
        /// </summary>
        public void Show()
        {
            Console.WriteLine(Cedula.ToString().PadRight(12) + Nombre.PadRight(35) + FechaNacimiento.ToShortDateString().PadLeft(12) +
                Sexo.ToString().PadRight(12).PadLeft(15) + Telefono.ToString().PadLeft(12).PadRight(15) + Correo.PadRight(40) + Direccion.PadRight(40) +
                EstadoCivil.ToString().PadRight(12) + IdCliente.ToString().PadLeft(5));
        }

        public override string ToString()
        {
            return (Cedula.ToString() + "\t" + Nombre + "\t" + FechaNacimiento.ToShortDateString() + "\t" +
                Sexo.ToString() + "\t" + Telefono.ToString() + "\t" + Correo + "\t" + Direccion + "\t" +
                EstadoCivil.ToString() + "\t" + IdCliente.ToString() + "\n");
        }

        public static bool Find(int CodCliente)
        {
            foreach (Cliente Cliente in ListaClientes)
            {
                if (Cliente.IdCliente == CodCliente) return true;
            }
            return false;
        }

        public static bool Find(long CedCliente)
        {
            foreach (Cliente Cliente in ListaClientes)
            {
                if (Cliente.Cedula == CedCliente) return true;
            }
            return false;
        }

        public static Cliente Search(long CedCliente = 0, int IdCliente = 0, int Telefono = 0)
        {
            foreach (Cliente v in ListaClientes)
            {
                if (v.Cedula == CedCliente | v.IdCliente == IdCliente | v.Telefono == Telefono)
                {
                    return v;
                }
            }
            return new Cliente();
        }

        public void SetItems(int i, string value)
        {
            switch (i)
            {
                case 0:
                    Cedula = Convert.ToInt64(value);
                    break;
                case 1:
                    Nombre = (string)value;
                    break;
                case 2:
                    FechaNacimiento = DateTime.ParseExact(value, "d/MM/yyyy", null);
                    break;
                case 3:
                    Sexo = (Sexo)Sexo.Parse(typeof(Sexo), value.ToString());
                    break;
                case 4:
                    Telefono = Convert.ToInt64(value);
                    break;
                case 5:
                    Correo = (string)value;
                    break;
                case 6:
                    Direccion = (string)value;
                    break;
                case 7:
                    EstadoCivil = (EstadoCivil)EstadoCivil.Parse(typeof(EstadoCivil), value.ToString());
                    break;
                case 8:
                    IdCliente = Convert.ToInt32(value);
                    break;
            }
        }

        public static void LoadList()
        {
            ListaClientes = new List<Cliente>();
            if (System.IO.File.Exists("Cliente.txt"))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader("Cliente.txt");

                while (!reader.EndOfStream)
                {
                    string[] var = reader.ReadLine().Split(',');

                    Cliente v = new Cliente();
                    for (int i = 0; i < var.Length; i++)
                    {
                        v.SetItems(i, var[i]);
                    }

                    ListaClientes.Add(v);

                }

                reader.Close();
            }
        }

        public static void MenuClientes()
        {
            int option;

            LoadList();

            do
            {
                Console.Write("\tBienvenido al menú de clienteses\n" +
                    "\t1. Crear clientes.\n" +
                    "\t2. Eliminar clientes.\n" +
                    "\t3. Editar clientes.\n" +
                    "\t4. Listar clienteses.\n" +
                    "\t5. Busacar clientes.\n" +
                    "\t6. Salir.\n" +
                    "\t:: ");

                option = Scanner.NextInt();

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\t-- Crear clientes ---");
                        Cliente v = new Cliente();

                        Console.Write("Cedula: ");
                        v.Cedula = Scanner.NextLong();

                        Console.Write("Nombre: ");
                        v.Nombre = Scanner.NextLine();

                        Console.Write("Fecha de nacimiento dd/MM/yyy");
                        v.FechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);

                        Console.Write("Sexo\n1. Femenino.\n2. Masculino.\n::");
                        if (Scanner.NextInt() == 1) v.Sexo = Sexo.Femnino;
                        else v.Sexo = Sexo.Masculino;

                        Console.Write("Teléfono: ");
                        v.Telefono = Scanner.NextLong();

                        Console.Write("Correo: ");
                        v.Correo = Scanner.NextLine();

                        Console.Write("Dirección: ");
                        v.Direccion = Scanner.NextLine();

                        Console.Write("Estado civil\n1. Soltero.\n2. Casado.\n3. Viudo.\n4. Divorciado.\n5. Union libre.\n:: ");
                        int estado = Scanner.NextInt();
                        for (int i = 0; i < 5; i++)
                        {
                            if (estado - 1 == i)
                            {
                                v.EstadoCivil = (EstadoCivil)i;

                            };
                        }
                        if (ListaClientes.Count != 0)
                            v.IdCliente = ListaClientes.Last().IdCliente + 1;
                        else
                            v.IdCliente = 1;

                        v.Add();

                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("\t--- Eliminar clientes ---\nNúmero de cédula del clientes: ");
                        Int64 NCClientes = Scanner.NextLong();

                        if (Find(NCClientes))
                        {
                            Cliente vn = Search(NCClientes);
                            vn.Show();
                            Console.Write("¿Borrar cliente?\n\t1. Si.\n\t2. No.\n::");
                            if (Scanner.NextInt() == 1)
                            {
                                vn.Delete();
                                Console.WriteLine("¡Proceso realizado con éxito!");
                            }
                            else Console.WriteLine("¡Proceso cancelado!");

                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("\t--- Editar datos del cliente ---\nNúmero de cédula del cliente: ");
                        Int64 NCedclientes = Scanner.NextLong();
                        Search(NCedclientes).Show();
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

                        Update(NCedclientes, Scanner.NextInt());

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\t-- Lista de clientes ---");
                        ToList();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("\t-- Buscar cliente ---\n");
                        Console.WriteLine("Seleccione el método de busqueda: " +
                            "\t1. Por número de cédula.\n" +
                            "\t2. Por número de identificación.\n" +
                            "\t3. Por número de teléfono.\n" +
                            "\t:: ");
                        switch (Scanner.NextInt())
                        {
                            case 1:
                                Console.Write("\tCédula: ");
                                Search(Scanner.NextLong()).Show();
                                break;
                            case 2:
                                Console.Write("\tIdentificación: ");
                                Search(0, Scanner.NextInt()).Show();
                                break;
                            case 3:
                                Console.Write("\tTeléfono: ");
                                Search(0, 0, Scanner.NextInt()).Show();
                                break;
                        }
                        break;
                }

            } while (option != 6);
        }

    }
}
