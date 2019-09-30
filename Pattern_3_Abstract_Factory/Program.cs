using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace Pattern_3_Abstract_Factory
{
    class Program // Паттерн абстрактная фабрика
    {
        static void Main(string[] args)
        {
            var soldHero = new Hero(new SoldierFactory());
            Console.WriteLine("Солдат");
            Console.ForegroundColor = ConsoleColor.Red;
            soldHero.Run();
            soldHero.Gun();
            soldHero.Fly();
            var elfHero = new Hero(new ElFCactory());
            Console.WriteLine("Эльф");
            Console.ForegroundColor = ConsoleColor.Yellow;
            elfHero.Run();
            elfHero.Gun();
            elfHero.Fly();
            Console.ReadLine();
          
        }
    }

    // Создали два абстрактных класса
    internal abstract class Weapon    // Обстрактный класс оружите
    {
        public abstract void Shoot(); // Стрелять
    }

    internal abstract class Movement // Обстрактный класс движение
    {
        public abstract void Move(); // Двигаться
    }

    abstract class Navigate
    {
        public abstract void Fly();
    }
    class Gun : Weapon // Пистолет
    {
        public override void Shoot()
        {
            Console.WriteLine("Стреляет");
        }
    }

    class Knif : Weapon
    {
        public override void Shoot()
        {
            Console.WriteLine("Режет");
        }
    }

    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежит");
        }
    }

    class FlyMovement : Navigate // Класс движения полета
    {
        public override void Fly()
        {
            Console.WriteLine("Летит");
        }
    }

    abstract class HeroFactory  // Абстрактный класс фабрика
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
        public abstract Navigate CreateNavigate();
    }

    // Фабрика создания бегущего героя с пистолетом
    class ElFCactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return  new RunMovement();
        }

        public override Navigate CreateNavigate()
        {
            return  new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return  new Gun();
        }
    }
    // Фабрика создания бегущего  героя с ножем
    class SoldierFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return  new RunMovement();
        }

        public override Navigate CreateNavigate()
        {
            return  new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return  new Knif();
        }
    }

    internal class FlyFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Navigate CreateNavigate()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Knif();
        }
    }

    internal class Hero
    {
        private readonly Movement movement;
        private readonly Weapon weapon;
        private readonly Navigate navigate;

        public Hero(HeroFactory factory)
        {
            movement = factory.CreateMovement();
            weapon = factory.CreateWeapon();
            navigate = factory.CreateNavigate();
        }

        public void Run()
        {
            movement.Move();
        }

        public void Gun()
        {
            weapon.Shoot();
        }

        public void Fly()
        {
            navigate.Fly();
        }
       
    }
}


