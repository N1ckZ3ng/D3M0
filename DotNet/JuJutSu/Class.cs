using System.Runtime.Serialization;

namespace classA
{

    [Serializable]
    public class JujutsuSorcerers
    {
        public string Name { get; set; }
        public string CursedTechniques { get; set; }
        public int CursedEnergy { get; set; }
        public void DoaminExpansion()
        {
            if (CursedTechniques == "limitless")
            {
                Console.WriteLine("Doamin Expansion... INFINITE VOID 4 (ﾟдﾟ)");
            }
            else
            {
                Console.WriteLine(" I don't car ┐(´д`)┌ ");
            }
            CursedEnergy = CursedEnergy - 100;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            if (CursedEnergy < 100)
            {
                Console.WriteLine("DIE ...");
                Name = "NaN";
                CursedEnergy = 0;
                CursedTechniques = "NaN";
            }
        }
    }
}