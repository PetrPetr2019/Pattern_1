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
            
            ClientCa a = new ClientCa(new HoracterFactory());
            a.Engi();
            a.Pri();
            
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
  // Абстрактный класс двигатель
    abstract class EngineCAr
  {
      public abstract void Engine();
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
    // Класс цена машины
    class Price : PriceCar
    {
        public override void Prise()
        {
            Console.WriteLine("Цена машины 2.000000");
        }
    }
    // Класс марка машины
    class MarkaCar : PriceCar
    {
        public override void Prise()
        {
            Console.WriteLine("Марка NISSAN");

        }
    }
    // Класс кузов  машины
    class TypeAudi : EngineCAr
    {
        public override void Engine()
        {
            Console.WriteLine("Кузов:" + "Седан");
        }
    }
    // Класс двигатель машины
    class EngineAudi : EngineCAr
    {
        public override void Engine()
        {
            Console.WriteLine("Двигатель машины:" + "Hubrid");
        }
    }
    // класс абстрактной фабрики
    abstract class MarketCar
    {
        public abstract Project Project();
        public abstract PriceCar PriceCar();
        public abstract EngineCAr EngineCAr();
    }
    // Конкретный класс фабрики
    class ClientCar : MarketCar
    {
        public override EngineCAr EngineCAr()
        {
            return  new TypeAudi();
        }

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
        public override EngineCAr EngineCAr()
        {
            return  new EngineAudi();
        }

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
        private EngineCAr engineCAr;

        public ClientCa(MarketCar market)
        {
            project = market.Project();
            priceCar = market.PriceCar();
            engineCAr = market.EngineCAr();
        }

        public void Price()
        {
            project.Cars();
        }

        public void Pri()
        {
            priceCar.Prise();
        }

        public void Engi()
        {
            engineCAr.Engine();
        }

    }
}










