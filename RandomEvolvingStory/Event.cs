using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEvolvingStory
{
    class Event
    {
        public string Time { get; set; }
        public string Occurrence { get; set; }

        public string ChangeCharacterName()
        {
            string newName = "tempName";
            return newName;
        }

        public string ChangeCharacterQuality()
        {
            string newQuality = "tempQuality";
            return newQuality;
        }
    }
}
