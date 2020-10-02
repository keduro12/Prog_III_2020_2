using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Prog_III_2020_2_sesion_1
{
    public class Vendedor : Persona
    {
        /// <summary>
        /// static
        /// </summary>
        public static List<Vendedor> ListaVendedor;

        

        public int IdVendedor
        {
            get;
            set;
        }

        public DateTime FechaIngreso
        {
            get;
            set;
        }

        public int Salario
        {
            get;
            set;
        }

        public string Profesion
        {
            get;
            set;
        }

        public int Calificacion
        {
            get;
            set;
        }



        public void Add()
        {
            if (ListaVendedor==null)
            {
                ListaVendedor = new List<Vendedor>();
            }

            ListaVendedor.Add(this);

            Save();
        }

        private void Save()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter("Vendedor.txt", true);

            writer.WriteLine(Cedula.ToString() + "," + Nombre + "," + FechaNacimiento.ToShortDateString() + "," +
                Sexo.ToString() + "," + Telefono.ToString() + "," + Correo + "," + Direccion + "," +
                EstadoCivil.ToString() + "," + IdVendedor.ToString() + "," + FechaIngreso.ToShortDateString() + "," + 
                Salario.ToString() + "," + Profesion + "," + Calificacion.ToString());

            writer.Close();
        }




        public static void Delete(int idVendedor)
        {
            if (Find(idVendedor))
            {
                foreach (Vendedor v in ListaVendedor)
                {
                    if (v.IdVendedor == idVendedor)
                        ListaVendedor.Remove(v);
                }
            }
        }

        public void Delete()
        {
            if (Find(this.IdVendedor))
            {
                ListaVendedor.Remove(this);
            }
        }

        public static void Update(long CedVendedor, int NDato)
        {
            if (Find(CedVendedor))
            {
                Vendedor v = Search(CedVendedor);

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
                    case 9:
                        Console.Write("Nueva Fecha de ingreso dd/MM/yyy");
                        v.FechaIngreso = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);
                        break;
                    case 10:
                        Console.Write("Nuevo Salario: ");
                        v.Salario = Scanner.NextInt();
                        break;
                    case 11:
                        Console.Write("Nueva Profesión: ");
                        v.Profesion = Scanner.NextLine();
                        break;
                    case 12:
                        Console.Write("Nueva Calificación de 1 a 10: ");
                        v.Calificacion = Scanner.NextInt();
                        break;
                }

                v.Save();

            }
            
        }

        /// <summary>
        /// Muestra los datos de todos los vendedores
        /// </summary>
        
        public static void ToList()
        {

            foreach (Vendedor v in Vendedor.ListaVendedor)
            {
                v.Show();
            }
        }

        //public string List()
        //{
        //    string todos = "";
        //    foreach (Vendedor vendedor in ListaVendedor)
        //    {
        //        todos += vendedor.ToString();
        //    }
        //    return todos;
        //}
        /// <summary>
        /// Muestra los datos de un vendedor
        /// </summary>
        public void Show()
        {
            Console.WriteLine(Cedula.ToString().PadRight(12)+ Nombre.PadRight(35)+ FechaNacimiento.ToShortDateString().PadLeft(12)+
                Sexo.ToString().PadRight(12).PadLeft(15)+ Telefono.ToString().PadLeft(12).PadRight(15)+ Correo.PadRight(40)+ Direccion.PadRight(40)+
                EstadoCivil.ToString().PadRight(12) + IdVendedor.ToString().PadLeft(5)+ FechaIngreso.ToShortDateString().PadLeft(12)+
                Salario.ToString().PadLeft(10)+ Profesion.PadLeft(20).PadRight(17)+ Calificacion.ToString().PadLeft(5));
        }

        public override string ToString()
        {
            return (Cedula.ToString() + "\t" + Nombre + "\t" + FechaNacimiento.ToShortDateString() + "\t" +
                Sexo.ToString() + "\t" + Telefono.ToString() + "\t" + Correo + "\t" + Direccion + "\t" +
                EstadoCivil.ToString() + "\t" + IdVendedor.ToString() + "\t" + FechaIngreso.ToShortDateString() + "\t" +
                Salario.ToString() + "\t" + Profesion + "\t" + Calificacion.ToString() + "\n");
        }

        public static bool Find(int CodVendedor)
        {
            foreach (Vendedor vendedor in ListaVendedor)
            {
                if (vendedor.IdVendedor == CodVendedor) return true;
            }
            return false;
        }

        public static bool Find(long CedVendedor)
        {
            foreach (Vendedor vendedor in ListaVendedor)
            {
                if (vendedor.Cedula == CedVendedor) return true;
            }
            return false;
        }

        public static Vendedor Search(long CedVendedor = 0, int IdVendedor = 0, int Telefono = 0)
        {
            foreach (Vendedor v in ListaVendedor)
            {           
                if (v.Cedula == CedVendedor | v.IdVendedor == IdVendedor | v.Telefono == Telefono)
                {
                    return v;
                }
            }
            return new Vendedor();
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
                    IdVendedor = Convert.ToInt32(value);
                    break;
                case 9:
                    FechaIngreso = DateTime.ParseExact(value, "d/MM/yyyy", null);
                    break;
                case 10:
                    Salario = Convert.ToInt32(value);
                    break;
                case 11:
                    Profesion = value.ToString();
                    break;
                case 12:
                    Calificacion = Convert.ToInt32(value);
                    break;
            }
        }

        public static void LoadList()
        {
            ListaVendedor = new List<Vendedor>();

            //Type type = ListaVendedor.GetType();
            //var obj = Activator.CreateInstance(type) as object;
            //var obj1 = ListaVendedor[0];
            //obj1.
    

            System.IO.StreamReader reader = new System.IO.StreamReader("Vendedor.txt");

            while (!reader.EndOfStream)
            {
                string[] var = reader.ReadLine().Split(',');

                Vendedor v = new Vendedor();
                for (int i = 0; i < var.Length; i++)
                {
                    v.SetItems(i, var[i]);
                }

                ListaVendedor.Add(v);

            }
            
            reader.Close();
        }

        public static void MenuAdminVendedor()
        {
            int option;

            LoadList();

            do
            {
                Console.Write("\tBienvenido al menú de Vendedores\n" +
                    "\t1. Crear vendedor.\n" +
                    "\t2. Eliminar vendedor.\n" +
                    "\t3. Editar vendedor.\n" +
                    "\t4. Listar vendedores.\n" +
                    "\t5. Busacar vendedor.\n" +
                    "\t6. Salir.\n" +
                    "\t:: ");
                
                option = Scanner.NextInt();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\t-- Crear vendedor ---");
                        Vendedor v = new Vendedor();

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
                                break;
                            };
                        }

                        v.IdVendedor = ListaVendedor.Last().IdVendedor + 1;

                        Console.Write("Fecha de ingreso dd/MM/yyy");
                        v.FechaIngreso = DateTime.ParseExact(Console.ReadLine(), "d/MM/yyyy", null);

                        Console.Write("Salario: ");
                        v.Salario = Scanner.NextInt();

                        Console.Write("Profesión: ");
                        v.Profesion = Scanner.NextLine();

                        Console.Write("Calificación de 1 a 10: ");
                        v.Calificacion = Scanner.NextInt();

                        v.Add();

                        break;

                    case 2:
                        Console.Write("\t--- Eliminar vendedor ---\nNúmero de cédula del Vendedor: ");
                        Int64 NCVendedor = Scanner.NextLong();

                        if (Find(NCVendedor))
                        {
                            Vendedor vn = Search(NCVendedor);
                            vn.Show();
                            Console.Write("¿Borrar Vendedor?\n\t1. Si.\n\t2. No.\n::");
                            if (Scanner.NextInt() == 1)
                            {
                                vn.Delete();
                                Console.WriteLine("¡Proceso realizado con éxito!");
                            }
                            else Console.WriteLine("¡Proceso cancelado!");

                        }

                        break;
                    case 3:

                        Console.Write("\t--- Editar datos del Vendedor ---\nNúmero de cédula del Vendedor: ");
                        Int64 NCedVendedor = Scanner.NextLong();
                        Search(NCedVendedor).Show();
                        Console.Write("\tOpciones a editar:\n" +
                           "\t1.  Cédula.\n" +
                           "\t2.  Nombre.\n" +
                           "\t3.  Fecha de nacimiento.\n" +
                           "\t4.  Sexo.\n" +
                           "\t5.  Teléfono.\n" +
                           "\t6.  Correo.\n" +
                           "\t7.  Dirección.\n" +
                           "\t8.  Estado civil.\n" +
                           "\t9.  Fecha de ingreso.\n" +
                           "\t10. Salario.\n" +
                           "\t11. Profesión.\n" +
                           "\t12. Calificación.\n" +
                           "\t:: ");

                        Update(NCedVendedor, Scanner.NextInt());

                        break;
                    case 4:
                        Console.WriteLine("\t-- Lista de vendedores ---");
                        ToList();
                        break;

                    case 5:
                        Console.WriteLine("\t-- Buscar vendedor ---\n");
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
                    //default:
                    //    Console.WriteLine("¡Oooops, ha ocurrido un error!");
                    //    break;
                        
                }

            } while (option != 6);
        }

        public void MenuVendedor()
        {

        }
    }
}