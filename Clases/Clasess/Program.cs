// instaciaciamos la clase empleado 

using System;
using System.Collections.Generic;
using System.Linq;


// aqui instanciamos la clase empleado

namespace Clasess
{
    class Program
    {
        static void Main(string[] args)
        {
            // creamos una lista donde gardaremos tres empleados
            List<Empleado> empleados = new List<Empleado>();

            // instanciamos la clase empleado

            Empleado jim = new Empleado("Jim", "Halpert", "Ventasa", "Calle 123", 1919199191);

            Empleado Pam = new Empleado("Pam", "Beesly", "Secretaria", "Calle 123", 33332221);

            Empleado Michael = new Empleado("Michael", "Scott", "Gerente", "Calle 123", 3333222);

            // agregamos los empleados a la lista

            empleados.Add(jim);
            empleados.Add(Pam);
            empleados.Add(Michael);

            // imprimir los empleados de la lista con un foreach con sus valores

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine("Nombre: " + empleado.Nombre);
                Console.WriteLine("Apellido: " + empleado.Apellido);
                Console.WriteLine("Departamento: " + empleado.Departamento);
                Console.WriteLine("Direccion: " + empleado.Direccion);
                Console.WriteLine("Telefono: " + empleado.Telefono);
                Console.WriteLine();
            }

            Console.ReadKey(); // esta linea es para que no se cierre la consola
        }
    }
}

