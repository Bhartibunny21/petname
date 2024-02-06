using System;

class VirtualPet
{
    private string type;
    private string name;
    private int hunger;
    private int happiness;
    private int health;

    public VirtualPet(string type, string name)
    {
        this.type = type;
        this.name = name;
        this.hunger = 5;
        this.happiness = 5;
        this.health = 5;
    }

    public void Feed()
    {
        hunger = Math.Max(0, hunger - 2);
        health = Math.Min(10, health + 1);
        Console.WriteLine($"{name} is fed. Hunger decreased, health increased.");
    }

    public void Play()
    {
        happiness = Math.Min(10, happiness + 2);
        hunger = Math.Max(0, hunger + 1);
        Console.WriteLine($"{name} is playing. Happiness increased, hunger increased.");
    }

    public void Rest()
    {
        health = Math.Min(10, health + 2);
        happiness = Math.Max(0, happiness - 1);
        Console.WriteLine($"{name} is resting. Health increased, happiness decreased.");
    }

    public void StatusCheck()
    {
        Console.WriteLine($"Status of {name} ({type}):");
        Console.WriteLine($"Hunger: {hunger}/10 | Happiness: {happiness}/10 | Health: {health}/10");

        if (hunger <= 2 || happiness <= 2 || health <= 2)
        {
            Console.WriteLine("Warning: Pet is not doing well. Consider taking care of it.");
        }
    }

    public void SimulateTimePassage()
    {
        hunger = Math.Min(10, hunger + 1);
        happiness = Math.Max(0, happiness - 1);
    }

    public void NeglectConsequences()
    {
        if (hunger >= 8)
        {
            health = Math.Max(0, health - 2);
            Console.WriteLine($"{name} is very hungry. Health is deteriorating.");
        }

        if (happiness <= 2)
        {
            Console.WriteLine($"{name} is too unhappy to play.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Virtual Pet Simulator!");
        Console.Write("Enter the type of pet (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();
        Console.Write("Enter the name of your pet: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome, {petName} the {petType}!");

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Feed the pet");
            Console.WriteLine("2. Play with the pet");
            Console.WriteLine("3. Rest the pet");
            Console.WriteLine("4. Check pet status");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Rest();
                    break;
                case "4":
                    pet.StatusCheck();
                    break;
                case "5":
                    Console.WriteLine("Exiting the Virtual Pet Simulator. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            pet.SimulateTimePassage();
            pet.NeglectConsequences();
        }
    }
}

