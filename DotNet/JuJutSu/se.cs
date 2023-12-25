using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using classA;
using System.Data;

class SerializeProgram
{
    static void Main(string[] args)
    {

        JujutsuSorcerers Role = new JujutsuSorcerers();

        Console.WriteLine("Name ?");
        Role.Name = Console.ReadLine();
        Console.WriteLine("Cursed Technique ?");
        Role.CursedTechniques = Console.ReadLine();
        Console.WriteLine("Cursed Energy ?");
        string cursedEnergyInput = Console.ReadLine();
        int cursedEnergy;
        while (!int.TryParse(cursedEnergyInput, out cursedEnergy))
        {
            Console.Write("Invalid input for Cursed Energy. Please enter an integer: ");
            cursedEnergyInput = Console.ReadLine();
        }
        Role.CursedEnergy = cursedEnergy;

        Role.DoaminExpansion();

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("JujutsuSorcerers.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, Role);
        }

        Console.WriteLine(" Sealing..... (Serialization) Done");
    }
}
