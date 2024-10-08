using CalculadoraProgram;

// Calculadora básica
Calculadora calculadora = new Calculadora();
double memoria = 0; 
List<InformationOperation> informationOperations = new List<InformationOperation>();

while (true)
{
    
    InformationOperation operation = new InformationOperation();
   
    // Pedir el primer número
    Console.WriteLine("Introduce el primer número (o 'r' para recuperar el resultado guardado):");
    operation.num1Temp = Console.ReadLine();

    if (!calculadora.CheckNumber(operation.num1Temp) && operation.num1Temp!= "r")
    {
        Console.WriteLine("No es un número válido");
        continue;  // Continua en lugar de terminar el programa
    }
    else if (operation.num1Temp== "r")
    {
        if (memoria != 0)
        {
            Console.WriteLine("Resultado recuperado: " + memoria);
            operation.num1Temp = memoria.ToString();
        }
        else
        {
            Console.WriteLine("No hay resultados guardados");
            continue;  // Continua en lugar de terminar el programa
        }
    }
    operation.Numero1 = calculadora.ConvertNumber(operation.num1Temp);
    //number1 = calculadora.ConvertNumber(num1Temp);

    // Pedir la operación
    Console.WriteLine("Introduce la operación (+, -, *, /):");
    operation.Operador = Console.ReadLine();

    if (!calculadora.CheckOperacion(operation.Operador))
    {
        Console.WriteLine("Operación no válida");
        continue;
    }

    // Pedir el segundo número
    Console.WriteLine("Introduce el segundo número (o 'r' para recuperar el resultado guardado):");
    operation.num2Temp = Console.ReadLine();

    if (!calculadora.CheckNumber(operation.num2Temp) && operation.num2Temp != "r")
    {
        Console.WriteLine("No es un número válido");
        continue;
    }
    else if (operation.num2Temp== "r")
    {
        if (memoria != 0)
        {
            Console.WriteLine("Resultado recuperado: " + memoria);
            operation.num2Temp= memoria.ToString();
        }
        else
        {
            Console.WriteLine("No hay resultados guardados");
            continue;
        }
    }

    operation.Numero2 = calculadora.ConvertNumber(operation.num2Temp);

    // Calcular resultado
    double resultado = calculadora.Calcular(operation.Numero1, operation.Numero2, operation.Operador);
    Console.Clear();
    Console.WriteLine("El resultado es: " + resultado);

    // Preguntar si quiere seguir calculando o guardar el resultado
    Console.WriteLine("¿Quieres seguir calculando? (s/n), para guardar el resultado presiona m, para recuperar el resultado presiona r");
    string respuesta = Console.ReadLine();

    if (respuesta == "m")
    {

        memoria = resultado;  // Ahora memoria se guarda correctamente
        Console.WriteLine("Resultado guardado en memoria: " + memoria);
    }

    if (respuesta == "n")
        break;

    // Limpiar consola
    Console.Clear();
}
    