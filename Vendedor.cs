using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Update()
        {
           
        }

        /// <summary>
        /// Muestra los datos de todos los vendedores
        /// </summary>
        public string List()
        {
            string todos = "";
            foreach (Vendedor vendedor in ListaVendedor)
            {
                todos += vendedor.ToString();
            }
            return todos;
        }
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

        public Vendedor Search(int vendedor)
        {
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
    }
}