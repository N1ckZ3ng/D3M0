using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using classA;

class DeserializeProgram
{
    static void Main(string[] args)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("JujutsuSorcerers.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            JujutsuSorcerers deserializedObj = (JujutsuSorcerers)formatter.Deserialize(stream);

            string name = deserializedObj.Name;
            int Energy = deserializedObj.CursedEnergy;
            Console.WriteLine($"Say my name... {name}");
            Console.WriteLine($"Energy...{Energy}");
        
        }

    }
}
