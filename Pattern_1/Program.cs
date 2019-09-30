using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Pattern_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();
           Hero voin =new Hero(new VoinFactory());
           voin.Hit();
           voin.Run();
           Console.ReadLine();
        }
    }
    //Абстрактный класс оружие
    abstract class Weapon //Оружие
    {
        public abstract void Hit();
    }
    //Абстрактный класс движение
    abstract class Movement// Движение
    {
        public abstract void Move();
    }
    //Класс арбалет
    class Arbalet:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
    //Класс меч
    class Sword:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }
    //Движение полета
    class FlyMovement:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
    //Движение бег
    class RunMovement:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    //Класс абстрактной фабрики
   abstract class HeroFactory
   {
       public abstract Movement CreMovement();
       public abstract Weapon CreWeapon();
   }
   // Фабрика создание летящего героя с арбалетом
    class ElfFactory:HeroFactory
   {
       public override Movement CreMovement()
       {
          return new FlyMovement();
       }

        public override Weapon CreWeapon()
        {
           return  new Arbalet();
        }
    }
    // Фабрика создания бегущего героя  с мячом 
    class VoinFactory : HeroFactory
    {
        public override Movement CreMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreWeapon()
        {
            return  new Sword();
        }
    }
    // Клиент сам супергерой
    class Hero
    {
        private Weapon weapon;
        private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreWeapon();
            movement = factory.CreMovement();
        }

        public void Run()
        {
            movement.Move();

        }

        public void Hit()
        {
            weapon.Hit();
        }
    }
}
