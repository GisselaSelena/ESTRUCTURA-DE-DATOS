using System;

public class Circulo
{
    // Propiedad para el radio del círculo
    public double Radio { get; set; }

    // Constructor
    public Circulo(double radio)
    {
        Radio = radio;
    }

    // Método para calcular el área
    public double CalcularArea()
    {
        return Math.PI * Math.Pow(Radio, 2);
    }

    // Método para calcular el perímetro
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Radio;
    }
}

public class Cuadrado
{
    // Propiedad para el lado del cuadrado
    public double Lado { get; set; }

    // Constructor
    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    // Método para calcular el área
    public double CalcularArea()
    {
        return Math.Pow(Lado, 2);
    }

    // Método para calcular el perímetro
    public double CalcularPerimetro()
    {
        return 4 * Lado;
    }
}

public class Rectangulo
{
    // Propiedades para la base y la altura del rectángulo
    public double Base { get; set; }
    public double Altura { get; set; }

    // Constructor
    public Rectangulo(double baseRectangulo, double altura)
    {
        Base = baseRectangulo;
        Altura = altura;
    }

    // Método para calcular el área
    public double CalcularArea()
    {
        return Base * Altura;
    }

    // Método para calcular el perímetro
    public double CalcularPerimetro()
    {
        return 2 * (Base + Altura);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un círculo con radio 5
        Circulo circulo = new Circulo(5);
        Console.WriteLine($"Área del círculo: {circulo.CalcularArea():F2}");
        Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro():F2}");

        // Crear un cuadrado con lado 4
        Cuadrado cuadrado = new Cuadrado(4);
        Console.WriteLine($"Área del cuadrado: {cuadrado.CalcularArea():F2}");
        Console.WriteLine($"Perímetro del cuadrado: {cuadrado.CalcularPerimetro():F2}");

        // Crear un rectángulo con base 4 y altura 6
        Rectangulo rectangulo = new Rectangulo(4, 6);
        Console.WriteLine($"Área del rectángulo: {rectangulo.CalcularArea():F2}");
        Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro():F2}");
    }
}

