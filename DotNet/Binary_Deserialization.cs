using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

class DeserializeProgram
{


    static void Main(string[] args)
    {
        System.Configuration.ConfigurationManager.AppSettings.Set("microsoft:WorkflowComponentModel:DisableActivitySurrogateSelectorTypeCheck", "true");
        BinaryFormatter formatter = new BinaryFormatter();

        Console.WriteLine("Serialize BIN ?");
        string targetBIN = Console.ReadLine();
        try
        {
            using (FileStream stream = new FileStream(targetBIN, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                formatter.Deserialize(stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        Console.ReadKey();
    }
}
