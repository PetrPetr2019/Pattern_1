using System;

namespace Abstract_factory_4
{
    class Program
    {
        static void Main(string[] args)
        {

            ClientCa audiCa = new ClientCa(new ClientCar());
            audiCa.Price();
            audiCa.Pri();
            ClientCa horCa = new ClientCa(new HoracterFactory());
            horCa.Price();
            horCa.Pri();
            Console.ReadLine();
        }
    }
  // Абстрактный класс  Продукт
  abstract class Project
  {
      public abstract void Cars();
  }
  // Абстрактный класс Цена машины
  abstract class PriceCar
  {
      public abstract void Prise();
  }
    // Класс цвет
    class Audi : Project
    {
        public override void Cars()
        {
            Console.WriteLine("Цвет машины синий");
        }
    }
    // Класс пробег машины
    class Probeg : Project
    {
        public override void Cars()
        {
            Console.WriteLine("Пробег машины : 240км");
        }
    }

    class Price : PriceCar
    {
        public override void Prise()
        {
            Console.WriteLine("Цена машины 2000000");
        }
    }

    class MarkaCar : PriceCar
    {
        public override void Prise()
        {
            Console.WriteLine("Марка NISSAN");

        }
    }
    // класс абстрактной фабрики
    abstract class MarketCar
    {
        public abstract Project Project();
        public abstract PriceCar PriceCar();
    }
    // Конкретный класс фабрики
    class ClientCar : MarketCar
    {
        public override PriceCar PriceCar()
        {
            return new Price();
        }

        public override Project Project()
        {
            return new Audi();
        }
    }

    class HoracterFactory : MarketCar
    {
        public override PriceCar PriceCar()
        {
            return  new MarkaCar();
        }

        public override Project Project()
        {
            return new Probeg();
        }
    }
    // Клиент
    class ClientCa
    {
        private Project project;
        private PriceCar priceCar;

        public ClientCa(MarketCar market)
        {
            project = market.Project();
            priceCar = market.PriceCar();
        }

        public void Price()
        {
            project.Cars();
        }

        public void Pri()
        {
            priceCar.Prise();
        }
    }
}










