using System;
//5kt
namespace InterfaceTasks
{
    interface IAnimal
    {
        string Name { get; }
        void MakeSound();
    }

    class Dog : IAnimal
    {
        public string Name => "Dog";
        public void MakeSound() => Console.WriteLine("Woof!");
    }

    class Cat : IAnimal
    {
        public string Name => "Cat";
        public void MakeSound() => Console.WriteLine("Meow!");
    }

    interface IShape
    {
        double Area { get; }
        double Perimeter { get; }
    }

    class Circle : IShape
    {
        private double Radius { get; }
        public Circle(double radius) => Radius = radius;
        public double Area => Math.PI * Radius * Radius;
        public double Perimeter => 2 * Math.PI * Radius;
    }

    class Rectangle : IShape
    {
        private double Width { get; }
        private double Height { get; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);
    }

    class Triangle : IShape
    {
        private double A { get; }
        private double B { get; }
        private double C { get; }
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        public double Area
        {
            get
            {
                double s = Perimeter / 2;
                return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
            }
        }
        public double Perimeter => A + B + C;
    }

    class Student : IComparable<Student>
    {
        public string Name { get; }
        public int Age { get; }
        public double Grade { get; }
        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
        public int CompareTo(Student other) => Grade.CompareTo(other.Grade);
    }

    class Book : IComparable<Book>
    {
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }
        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }
        public int CompareTo(Book other) => Price.CompareTo(other.Price);
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите задание (1-3):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    IAnimal dog = new Dog();
                    IAnimal cat = new Cat();
                    dog.MakeSound();
                    cat.MakeSound();
                    break;

                case "2":
                    IShape circle = new Circle(5);
                    IShape rectangle = new Rectangle(4, 6);
                    IShape triangle = new Triangle(3, 4, 5);
                    Console.WriteLine($"Circle: Area={circle.Area}, Perimeter={circle.Perimeter}");
                    Console.WriteLine($"Rectangle: Area={rectangle.Area}, Perimeter={rectangle.Perimeter}");
                    Console.WriteLine($"Triangle: Area={triangle.Area}, Perimeter={triangle.Perimeter}");
                    break;

                case "3":
                    var student1 = new Student("Alice", 20, 85.5);
                    var student2 = new Student("Bob", 22, 90.0);
                    Console.WriteLine(student1.CompareTo(student2) < 0
                        ? "Bob has a higher grade."
                        : "Alice has a higher grade.");

                    var book1 = new Book("C# Basics", "John Smith", 29.99);
                    var book2 = new Book("Advanced C#", "Jane Doe", 39.99);
                    Console.WriteLine(book1.CompareTo(book2) < 0
                        ? "Advanced C# is more expensive."
                        : "C# Basics is more expensive.");
                    break;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}
