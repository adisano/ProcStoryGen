using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEvolvingStory
{
    class Grammar
    {
        //triggers that will help the program decide which word to Get next.
        public bool WroteCharacter { get; set; }
        public bool WroteEvent { get; set; }
        public bool WroteA { get; set; }
        public bool WroteThe { get; set; }
        public bool WrotePunctuation { get; set; }

        //Get a verb to Write later
        public string GetVerb(Character character)
        {
            string labelText = "ERROR: last noun written not found";
            if (character.IsAlive)
            {
                labelText = "is";
            }
            else if (!character.IsAlive)
            {
                labelText = "was";
            }
            else
            {
                labelText = "ERROR: character status not found";
            }
            return labelText;
        }

        //Get an article to Write later
        public string GetArticle(Random random, string quality)
        {
            string labelText = "ERROR: last noun written not found";
            char[] qualityarray = quality.ToCharArray();
            if (WroteCharacter)
            {
                int rnd = random.Next(1, 11);
                if (rnd >= 6)
                {
                    labelText = "a";
                    WroteA = true;
                }
                else if (rnd <= 5)
                {
                    labelText = "the";
                    WroteThe = true;
                }
                if (WroteA)
                {

                    if (qualityarray[0] == 'a' || qualityarray[0] == 'e' || qualityarray[0] == 'i'
                        || qualityarray[0] == 'o' || qualityarray[0] == 'u')
                    {
                        labelText = "an";
                    }
                    else
                    {
                        labelText = "a";
                    }
                }
                else
                {
                    labelText = "the";
                }
            }
            else if (WroteEvent)
            {
                int rnd = random.Next(1, 11);
                if (rnd >= 6)
                {
                    labelText = "a";
                    WroteA = true;
                }
                else if (rnd <= 5)
                {
                    labelText = "the";
                    WroteThe = true;
                }
            }
            return labelText;
        }

        //Get a punctuation to Write later
        public string GetPunctuation(Random random)
        {
            string labelText = "Error: last noun written not found";
            if (WroteA)
            {
                int rnd = random.Next(1, 11);
                if (rnd < 4)
                {
                    labelText = ".";
                    WrotePunctuation = true;
                    WroteA = false;
                    WroteCharacter = false;
                    WroteEvent = false;
                    WroteThe = false;
                }
                else
                {
                    labelText = "";
                    WroteA = false;
                    WroteCharacter = false;
                    WroteEvent = false;
                    WroteThe = false;
                }
            }
            else
            {
                labelText = "";
                WroteA = false;
                WroteCharacter = false;
                WroteEvent = false;
                WroteThe = false;
            }
            return labelText;
        }


    }
}
