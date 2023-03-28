using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Game.Spells
{
    public class SpellDataProvider : ISpellDataProvider
    {
        // TODO: add exceptions as per step 1.5 in lab 9

        private class SpellEffect
        {
            public string Name { get; set; }
            public int Cost { get; set; }
        }

        private static SpellDataProvider instance;
        private Dictionary<string, SpellInfo> spellInfos;
        private Dictionary<string, int> effectInfos;

        private SpellDataProvider()
        {

        }

        public static SpellDataProvider GetInstance()
        {
            if (instance == null)
                instance = new SpellDataProvider();

            return instance;
        }

        private void LoadEffectInfo()
        {
            effectInfos = new Dictionary<string, int>();
            string json = File.ReadAllText("resources/effects.json");

            List<SpellEffect> parsed = JsonConvert.DeserializeObject<List<SpellEffect>>(json);

            foreach (SpellEffect effect in parsed)
            {
                effectInfos.Add(effect.Name, effect.Cost);
            }
        }

        public Dictionary<string, int> GetSpellEffects()
        {
            if (effectInfos == null)
                this.LoadEffectInfo();

            return effectInfos;
        }

        private void LoadSpellInfo()
        {
            string[] lines = File.ReadAllLines("resources/spell.csv");
            spellInfos = new Dictionary<string, SpellInfo>();

            foreach (string line in lines[1..])
            {
                spellInfos.Add(line.Split(';')[0], (SpellInfo)line);
            }
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (spellInfos == null)
                this.LoadSpellInfo();

            return spellInfos;
        }
    }
}
