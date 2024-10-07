using CalculadoraProgram;


// vamos a realizar una calculadora
while (true)
{
    // instanciamos la clase
    Calculadora calculadora = new Calculadora();
    double number1 = 0;
    double number2 = 0;
    string num1Temp = "";
    string num2Temp = "";


    // primero pedimos el primer número
    Console.WriteLine("Introduce el primer número");
    // lo guardamos pero en un string 
    num1Temp = Console.ReadLine();
    // checamos si es un número
    if (!calculadora.CheckNumber(num1Temp))
    {
        Console.WriteLine("No es un número");
        break;
    }
    // Convertimos el número a double
    number1 = calculadora.ConvertNumber(num1Temp);

    // le pedimos la operacion 
    Console.WriteLine("Introduce la operación");
    string ?operacion = Console.ReadLine();
    // checamos operacion
    if (calculadora.CheckOperacion(operacion))
    {
        Console.WriteLine("error la operacion no es correcta");
        break;
    }
   
   // le pedimos el segundo número
    Console.WriteLine("Introduce el segundo número");
    num2Temp = Console.ReadLine();
    if (!calculadora.CheckNumber(num2Temp))
    {
        Console.WriteLine("No es un número");
        break;
    }
    // convertimos el número a double
    number2 = calculadora.ConvertNumber(num2Temp);

    // llamamos al método Calcular
    double resultado = calculadora.Calcular(number1, number2, operacion);

    // mostramos el resultado
    Console.WriteLine("El resultado es: " + resultado);

    // le preguntamos si quiere seguir calculando
    Console.WriteLine("¿Quieres seguir calculando? (s/n)");
    string respuesta = Console.ReadLine();
    if (respuesta != "s")
        break;
}