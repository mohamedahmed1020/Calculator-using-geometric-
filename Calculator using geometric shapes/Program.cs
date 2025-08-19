using System;
using System.Collections.Generic;

class Program
{
    private static List<string> history = new List<string>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Geometry Program");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("3. History");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowGeometryMenu();
                    break;
                case "2":
                    Calculator();
                    break;
                case "3":
                    ShowHistory();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowGeometryMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Geometry Program ===");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Square");
            Console.WriteLine("3. Rectangle");
            Console.WriteLine("4. Triangle");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Select a shape: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    HandleCircle();
                    break;
                case "2":
                    HandleSquare();
                    break;
                case "3":
                    HandleRectangle();
                    break;
                case "4":
                    HandleTriangle();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void HandleCircle()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Circle Calculations ===");
            double radius = GetValidDouble("Enter radius: ");

            Console.WriteLine("1. Calculate Area");
            Console.WriteLine("2. Calculate Circumference");
            Console.Write("Select operation: ");

            switch (Console.ReadLine())
            {
                case "1":
                    double area = Math.PI * radius * radius;
                    AddHistory($"Circle Area: r={radius} => {area:F2}");
                    Console.WriteLine($"Area: {area:F2}");
                    break;
                case "2":
                    double circumference = 2 * Math.PI * radius;
                    AddHistory($"Circle Circumference: r={radius} => {circumference:F2}");
                    Console.WriteLine($"Circumference: {circumference:F2}");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (!AskForRepeat("circle")) return;
        }
    }

    static void HandleSquare()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Square Calculations ===");
            double side = GetValidDouble("Enter side length: ");

            Console.WriteLine("1. Calculate Area");
            Console.WriteLine("2. Calculate Perimeter");
            Console.Write("Select operation: ");

            switch (Console.ReadLine())
            {
                case "1":
                    double area = side * side;
                    AddHistory($"Square Area: a={side} => {area}");
                    Console.WriteLine($"Area: {area}");
                    break;
                case "2":
                    double perimeter = 4 * side;
                    AddHistory($"Square Perimeter: a={side} => {perimeter}");
                    Console.WriteLine($"Perimeter: {perimeter}");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (!AskForRepeat("square")) return;
        }
    }

    static void HandleRectangle()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Rectangle Calculations ===");
            double length = GetValidDouble("Enter length: ");
            double width = GetValidDouble("Enter width: ");

            Console.WriteLine("1. Calculate Area");
            Console.WriteLine("2. Calculate Perimeter");
            Console.Write("Select operation: ");

            switch (Console.ReadLine())
            {
                case "1":
                    double area = length * width;
                    AddHistory($"Rectangle Area: l={length}, w={width} => {area}");
                    Console.WriteLine($"Area: {area}");
                    break;
                case "2":
                    double perimeter = 2 * (length + width);
                    AddHistory($"Rectangle Perimeter: l={length}, w={width} => {perimeter}");
                    Console.WriteLine($"Perimeter: {perimeter}");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (!AskForRepeat("rectangle")) return;
        }
    }

    static void HandleTriangle()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Triangle Calculations ===");
            double baseLength = GetValidDouble("Enter base length: ");
            double height = GetValidDouble("Enter height: ");

            Console.WriteLine("1. Calculate Area");
            Console.WriteLine("2. Calculate Perimeter");
            Console.Write("Select operation: ");

            switch (Console.ReadLine())
            {
                case "1":
                    double area = 0.5 * baseLength * height;
                    AddHistory($"Triangle Area: b={baseLength}, h={height} => {area}");
                    Console.WriteLine($"Area: {area}");
                    break;
                case "2":
                    double side2 = GetValidDouble("Enter second side length: ");
                    double side3 = GetValidDouble("Enter third side length: ");
                    double perimeter = baseLength + side2 + side3;
                    AddHistory($"Triangle Perimeter: sides={baseLength},{side2},{side3} => {perimeter}");
                    Console.WriteLine($"Perimeter: {perimeter}");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            if (!AskForRepeat("triangle")) return;
        }
    }

    static void Calculator()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Calculator ===");
            double num1 = GetValidDouble("Enter first number: ");
            double num2 = GetValidDouble("Enter second number: ");

            Console.Write("Enter operation (+, -, *, /): ");
            string op = Console.ReadLine();

            double result = 0;
            bool valid = true;

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero!");
                        valid = false;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation!");
                    valid = false;
                    break;
            }

            if (valid)
            {
                string calculation = $"{num1} {op} {num2} = {result}";
                AddHistory(calculation);
                Console.WriteLine($"Result: {result}");
            }

            Console.Write("\nPerform another calculation? (y/n): ");
            if (Console.ReadLine().ToLower() != "y") break;
        }
    }

    static void ShowHistory()
    {
        Console.Clear();
        Console.WriteLine("=== Calculation History ===");
        foreach (string entry in history)
        {
            Console.WriteLine(entry);
        }
        Console.WriteLine("\nPress any key to return...");
        Console.ReadKey();
    }

    #region Helper Methods
    static double GetValidDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value)) return value;
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    static bool AskForRepeat(string shape)
    {
        Console.WriteLine("\n1. New calculation for this {0}", shape);
        Console.WriteLine("2. Return to geometry menu");
        Console.WriteLine("3. Exit program");
        Console.Write("Enter choice: ");

        switch (Console.ReadLine())
        {
            case "1":
                return true;
            case "2":
                return false;
            case "3":
                Environment.Exit(0);
                return false;
            default:
                Console.WriteLine("Invalid choice! Returning to geometry menu...");
                return false;
        }
    }

    static void AddHistory(string entry)
    {
        history.Add($"[{DateTime.Now:HH:mm:ss}] {entry}");
    }
    #endregion
}