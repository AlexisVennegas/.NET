using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CalculadoraProgram
{
    internal class Calculadora
    {
        // creamos un método que recibe dos números y una operación
        public double Calcular(double num1, double num2, string operacion)
        {
            // dependiendo de la operación realizamos una operación
            switch (operacion)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    // comprobamos que el segundo número no sea 0
                    if (num2 == 0)
                    {
                        Console.WriteLine("No se puede dividir entre 0");
                        return 0;
                    }
                    return num1 / num2;
                default:
                    return 0;
            }
        }
        public Boolean CheckNumber(string num) 
        {
            if (double.TryParse(num, out double result))
                return true;

            return false;
        }
        public Double ConvertNumber(string num)
        {
            return double.Parse(num);
        }
        public Boolean CheckOperacion(string operation)
        {
            // comprobamos que la operacion sea correcta
            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                return false;
            return true;
        }
        public Boolean SaveResult(double result)
        {
            // guardamos en una variable global el resultado
            // para poder recuperarlo
            double resultado = result;
            return false;

        }
    }
}
