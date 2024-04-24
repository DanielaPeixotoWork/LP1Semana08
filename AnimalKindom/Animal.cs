namespace AnimalKingdom
{
    public abstract class Animal
    {
        public virtual string Sound()
        {
            return "Sound will be ";
        }
    }

    public class Dog : Animal, IMammal
    {
        public int NumberOfNipples { get; }

        public Dog()
        {
            NumberOfNipples = 10;
        }

        public override string Sound()
        {
            return base.Sound() + "Woof!";
        }
    }

    public class Cat : Animal, IMammal
    {
        public int NumberOfNipples { get; }

        public Cat()
        {
            NumberOfNipples = 8; 
        }

        public override string Sound()
        {
            return base.Sound() + "Miau";
        }
    }

    public class Bat : Animal, IMammal, ICanFly
    {
        public int NumberOfNipples { get; }

        public Bat()
        {
            NumberOfNipples = 2;
        }

        public int NumberOfWings { get; }

        public Bat(int numberOfWings)
        {
            NumberOfWings = numberOfWings;
        }

        public override string Sound()
        {
            return base.Sound() + "Screech";
        }
    }

    public class Bee : Animal, ICanFly
    {
        public int NumberOfWings { get; }

        public Bee()
        {
            NumberOfWings = 4;
        }

        public override string Sound()
        {
            return base.Sound() + "Buzz";
        }
    }

    public interface IMammal
    {
        int NumberOfNipples { get; }
    }

    public interface ICanFly
    {
        int NumberOfWings { get; }
    }
}
