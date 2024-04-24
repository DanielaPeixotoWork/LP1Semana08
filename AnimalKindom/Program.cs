using System;

namespace AnimalKingdom
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[10];

            Random random = new Random();
            for (int i = 0; i < animals.Length; i++)
            {
                int randomNumber = random.Next(1, 5); 
                switch (randomNumber)
                {
                    case 1:
                        animals[i] = new Dog();
                        break;
                    case 2:
                        animals[i] = new Cat();
                        break;
                    case 3:
                        animals[i] = new Bat();
                        break;
                    case 4:
                        animals[i] = new Bee();
                        break;
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine($"Sound: {animal.Sound()}");
                if (animal is IMammal mammal)
                {
                    Console.WriteLine($"Number of Nipples: {mammal.NumberOfNipples}");
                }
                if (animal is ICanFly flyingAnimal)
                {
                    Console.WriteLine($"Number of Wings: {flyingAnimal.NumberOfWings}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
