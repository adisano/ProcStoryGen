using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEvolvingStory
{
    class Event
    {
        //the time of the event ie., "10 years ago", "in the distant past"
        public string Time { get; set; }
        //what happened, ie., "a storm raged", "the revolution began"
        public string Occurrence { get; set; }
        public bool IsLocked { get; set; }
        public bool IsOngoing { get; set; }

        public string ChangeCharacterName()
        {
            //this should change the current name to a new name.
            string newName = "tempName";
            return newName;
        }

        public string ChangeCharacterQuality()
        {
            //this should change the current quality to a new quality.
            string newQuality = "tempQuality";
            return newQuality;
        }
    }
}
