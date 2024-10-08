using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кт_5
{
    public interface IAnimal
    {
        string Name { get; set; }
        void MakeSound();
    }
    public interface IShape
    {
        double Area { get; }
        double Perimeter { get; }
    }
    public interface IComparable<T>
    {
        int CompareTo(T other);
    }


    public class Dog : IAnimal
    {
        public string Name { get; set; }

        public Dog(string name)
        {
            Name = name;
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} говорит гав");
        }
    }
    public class Cat : IAnimal
    {
        public string Name { get; set; }

        public Cat(string name)
        {
            Name = name;
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} говорит мяу");
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area => Math.PI * Radius * Radius;
        public double Perimeter => 2 * Math.PI * Radius;
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Area => Width * Height;
        public double Perimeter => 2 * (Width + Height);
    }

    public class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double Area
        {
            get
            {
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            }
        }

        public double Perimeter => SideA + SideB + SideC;
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            int nameComparison = string.Compare(Name, other.Name);
            if (nameComparison != 0) return nameComparison;

            if (Age != other.Age) return Age.CompareTo(other.Age);

            return Grade.CompareTo(other.Grade);
        }
    }

    public class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, double price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public int CompareTo(Book other)
        {
            if (other == null) return 1;

            int authorComparison = string.Compare(Author, other.Author);
            if (authorComparison != 0) return authorComparison;

            int titleComparison = string.Compare(Title, other.Title);
            if (titleComparison != 0) return titleComparison;

            return Price.CompareTo(other.Price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal dog = new Dog("Рекс");
            IAnimal cat = new Cat("Барсик");

            dog.MakeSound();
            cat.MakeSound();


            IShape circle = new Circle(5);
            IShape rectangle = new Rectangle(4, 6);
            IShape triangle = new Triangle(3, 4, 5);

            Console.WriteLine($"площадь круга {circle.Area} периметр круга: {circle.Perimeter}");
            Console.WriteLine($"площадь прямоугольника: {rectangle.Area} периметр прямоугольника: {rectangle.Perimeter}");
            Console.WriteLine($"площадь треугольника: {triangle.Area}, периметр треугольника: {triangle.Perimeter}");

            Student student1 = new Student("Иван", 23, 4.5);
            Student student2 = new Student("Иван", 22, 4.0);

            Console.WriteLine($"сравнение студентов: {student1.CompareTo(student2)}");

            Book book1 = new Book("война и мир", "Толстой", 500);
            Book book2 = new Book("преступление и наказание", "Достоевский", 450);

            Console.WriteLine($"сравнение книг: {book1.CompareTo(book2)}");
        }
    }
}
