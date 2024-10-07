using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasess
{
    internal class Empleado
    {
        // hacemos el get and set de sus propiedades 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }

        public int Telefono { get; set; }

        // creamos un constructor con los parametros que queremos que tenga

        public Empleado(string nombre, string apellido, string departamento, string direccion, int telefono = 9)
        {
            Nombre = nombre;
            Apellido = apellido;
            Departamento = departamento;
            Direccion = direccion;
            Telefono = telefono;
        }

    }
}
