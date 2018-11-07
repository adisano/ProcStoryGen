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
        public bool IsAlive { get; set; }
        public List<string> Quality { get; set; }

        public string NameCharacter()
        {
            //change this so it outputs a random name
            string characterName = "Name";
            return characterName;
        }

    }
}
