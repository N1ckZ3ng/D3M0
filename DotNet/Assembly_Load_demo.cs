using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {

        string dllPath = "C:\\Users\\nz\\Desktop\\A.dll";

        byte[] assemblyData = File.ReadAllBytes(dllPath);

        Assembly assembly = Assembly.Load(assemblyData);

        Type t = assembly.GetType("ExploitClass.Exploit");

        object myClassInstance = Activator.CreateInstance(t);

    }
    
}
