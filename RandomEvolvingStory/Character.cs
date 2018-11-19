using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEvolvingStory
{
    class Character
    {
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Profession { get; set; }
        public bool IsNameLocked = false;
        public bool IsQualityLocked = false;
        public bool IsProfessionLocked = false;
        public bool IsAlive { get; set; }
        public List<string> Qualities = new List<string> { "strange", "beautiful", "mysterious",
        "intelligent", "strong", "independent", "bloodthirsty", "odd", "weird", "precious",
        "evil", "cute", "adventurous", "witty" };
        public List<string> Professions = new List<string> { "baker", "knight", "writer", "sailor",
        "songwriter" };
        
        public string GetCharacterName()
        {
            //change this so it outputs a random name
            string characterName = "Name";
            return characterName;
        }
        
        public string GetCharacterQuality(Random random)
        {
            string characterQuality = Qualities[random.Next(Qualities.Count)];
            return characterQuality;
        }
        
        public string GetCharacterProfession(Random random)
        {
            string characterProfession = Professions[random.Next(Professions.Count)];
            return characterProfession;
        }

    }
}
