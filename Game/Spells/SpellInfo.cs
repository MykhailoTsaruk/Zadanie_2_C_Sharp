
namespace Game.Spells
{
    public class SpellInfo
    {
        public string Name { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static explicit operator SpellInfo(string data)
        {
            string[] value = data.Split(";");

            return new SpellInfo
            {
                Name            = value[0],
                AnimationPath   = value[1],
                AnimationWidth  = int.Parse(value[2]),
                AnimationHeight = int.Parse(value[3]),
                EffectNames     = value[4].Split(",")
            };
        }
    }
}
