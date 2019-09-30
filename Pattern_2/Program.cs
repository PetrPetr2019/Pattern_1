using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Pattern_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElFFactory());
            elf.Run();
            elf.Hit();
            elf.Smile();

            Hero Voin = new Hero(new voinFactory());
            Voin.Run();
            Voin.Hit();
            Voin.Smile();
            Console.ReadLine();

        }
    }

    abstract class Weapont// Абстрактный класс оружие
    {
        public abstract void Hit();
    }

    abstract class Movement// абстрактный класс движение
    {
        public abstract void Move();
    }

    class Arbalet : Weapont // Конкретный класс арбалет
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }

    class Axe : Weapont // Конкретный класс Топор
    {
        public override void Hit()
        {
            Console.WriteLine("Метаем топорик");
        }
    }

    abstract class Live
    {
        public abstract void Smile();
    }

    class Mouth : Live
    {
        public override void Smile()
        {
            Console.WriteLine("Улыбаемся шире");
        }
    }
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }

    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }

    abstract class HeroFactory // Абстрактный класс фабрика
                    {
                        public abstract Movement CreateMovement();
                        public abstract Weapont CreateWeapont();
                        public abstract Live CreateLive();
                    }

    class ElFFactory : HeroFactory
    {
        public override Live CreateLive()
        {
            return  new Mouth();
        }

        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapont CreateWeapont()
        {
            return new Arbalet();
        }
    }
    
    class voinFactory : HeroFactory
                        {
        public override Live CreateLive()
        {
            return  new Mouth();
        }

        public override Movement CreateMovement()
                            {
                                return new RunMovement();
                            }

                            public override Weapont CreateWeapont()
                            {
                                return new Axe();
                            }
                        }

                        class Hero
                            {
                                private Weapont weapont;
                                private Movement movement;
                                private Live live;

                                public Hero(HeroFactory factory)
                                {
                                    weapont = factory.CreateWeapont();
                                    movement = factory.CreateMovement();
                                    live = factory.CreateLive();
                                }

                                public void Run()
                                {
                                    movement.Move();
                                }

                                public void Hit()
                                {
                                    weapont.Hit();
                                }

                                public void Smile()
                                {
                                    live.Smile();
                                }
                            }
                        }
      

       