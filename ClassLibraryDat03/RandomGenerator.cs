using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public class RandomGenerator
    {
        private static Random rand = new Random();
        public string GenerateFruit()
        {
            string randomName = "";
            randomName = $"{(Fruit)rand.Next(0, (Enum.GetNames(typeof(Fruit))).Length)}";
            return randomName;
        }

        enum Fruit
        {
            dragon_Fruit,
            apple,
            apricot,
            avocado,
            banana,
            berry,
            cantaloupe,
            cherry,
            citron,
            citrus,
            coconut,
            date,
            fig,
            grape,
            guava,
            kiwi,
            lemon,
            lime,
            mango,
            melon,
            mulberry,
            nectarine,
            orange,
            papaya,
            peach,
            pear,
            pineapple,
            plum,
            prune,
            raisin,
            raspberry,
            tangerine,
        }

    }
}
