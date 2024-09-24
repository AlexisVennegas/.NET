internal class Program
{
    static void Main(string[] args)
    {
        // declara la variable edadString
        string edadString;

        // pide la edad
        Console.WriteLine("Introduce tu edad: ");
        
        // lee la edad
        edadString = Console.ReadLine() ?? string.Empty;

        //comprobamos que la edad no sea nula o si es un numero o si es negativo
        if (string .IsNullOrEmpty(edadString) || !int.TryParse(edadString, out _) || int.Parse(edadString) < 0)
        {
            Console.WriteLine("La edad introducida no es válida");
            return;
        }
        // convertimos la edad a entero
        int edadInt = int.Parse(edadString);

        // comprobamos si es mayor de edad
        if (edadInt >= 12)
            Console.WriteLine("Eres un niño");
        else if (edadInt > 12 && edadInt < 18)
            Console.WriteLine("Eres un adolescente");
        else if (edadInt >= 18 && edadInt < 65)
            Console.WriteLine("Eres un adulto");
        else
            Console.WriteLine("Eres un adulto mayor");
    }
}