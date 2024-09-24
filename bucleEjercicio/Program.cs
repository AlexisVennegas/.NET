// / Modificar para incorporar las siguientes características:    
// Indicar el numero de intentos que le quedan
// Indicar si el número a adivinar es mayor o menor que el introducido

int numeroAdivinar;
int numeroIntentos = 3;
// Pedir al usuario que ingrese un número a adivinar
Console.Write("Introduce un número para que otro jugador lo adivine: ");

// Validar que el número ingresado sea un número entero
if (int.TryParse(Console.ReadLine(), out numeroAdivinar) == false)
{
    Console.WriteLine("Número inválido. Inténtalo de nuevo.");
    return;
}



// Limpiar la consola para que el segundo jugador no vea el número
Console.Clear();

// Dar tres oportunidades para adivinar el número
for (int i = 0; i < 3; i++)
{
    Console.WriteLine("Te quedan " + (numeroIntentos - i) + " intentos.");
    Console.Write("Adivina el número: ");
    // if para limpiar la consola
    int intento = int.Parse(Console.ReadLine() ?? "0");

    if (intento == numeroAdivinar)
    {
     Console.WriteLine("¡Felicidades! Has adivinado el número.");
    return;
    }   
        
    else 
        Console.WriteLine("El número a adivinar es " + (intento > numeroAdivinar ? "menor" : "mayor") + " que el número introducido.");

}

Console.WriteLine("Lo siento, no has adivinado el número.");