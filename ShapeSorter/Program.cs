using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            Console.WriteLine("-----------------");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4),
                new Rectangle(3.2,5.9),
                new Square(3),
                new Square(10),
                new Rectangle(2,3),
                new Circle(2),
                new Rectangle(10,10),
                new Circle(8)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}.");
            }
            Console.WriteLine("-----------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);
            Console.WriteLine("Shapes with area greater than 50.");
            Console.WriteLine("-----------------");

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Shape with area {shape.Area}.");
            }
            Console.WriteLine("-----------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();

            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and Area {shape.Area}");
            }
            Console.WriteLine("-----------------");

            IEnumerable<Circle> filteredCircles = circles.Where(circle => circle.Area > 70);

            foreach (Circle shape in filteredCircles)
            {
                Console.WriteLine($"Circle with radius {shape.Radius} and Area {shape.Area}");
            }
            Console.WriteLine("-----------------");

            var groupedshapes = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupedshapes)
            {
                Console.WriteLine($"Shapes of type {group.Key.Name}");
                Console.WriteLine("-----------------");
                foreach (var shape in group)
                {
                    Console.WriteLine($"{shape.GetType().Name} of area {shape.Area}");
                }
                Console.WriteLine("-----------------");
            }

            var groupedbyarea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach (var group in groupedbyarea)
            {
                Console.WriteLine(group.Key ? "Even Areas" : "Odd Areas");
                Console.WriteLine("-----------------");
                foreach (var shape in group)
                {
                    Console.WriteLine($"{shape.GetType().Name} of area {shape.Area}");
                }
                Console.WriteLine("-----------------");
            }

            Console.WriteLine($"Maximum area is {shapes.Max(shape => shape.Area)}");

            var totalArea = shapes.Sum(shape => shape.Area);

            Console.WriteLine($"Sum of all areas is {totalArea}");

            Console.ReadKey();
        }
    }
}
