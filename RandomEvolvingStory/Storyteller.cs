using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomEvolvingStory
{
    class Storyteller
    {
        //a list of each story element (character name, character quality, event, etc.)
        //in order.
        //use to assign story elements to labels, etc..
        public List<string> StoryElements = new List<string> { };

        //used to get story elements and order them in StoryElements.
        public List<string> GetStoryElements(Random random)
        {            
            Character character = new Character();
            Grammar grammar = new Grammar();
            //use to increment random
            int rnd;
            //use to add strings to StoryElements
            string temp;

            //begin getting the story
            character.Name = character.GetCharacterName(random);

            //character name
            StoryElements.Add(character.Name);

            //determine whether or not character is alive.
            //this can be used to give context to other story elements,
            //for example the verb in "character1 was alive" vs "character1 is alive".
            rnd = random.Next(1, 11);
            if (rnd >= 6)
                character.IsAlive = true;
            else
                character.IsAlive = false;

            temp = grammar.GetVerb(character);

            StoryElements.Add(temp);

            return StoryElements;
        }

    }
}
