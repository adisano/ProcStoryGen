using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomEvolvingStory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //create character and event objects 
        Character character1 = new Character();
        Event event1 = new Event();
        Random rnd = new Random();
        Grammar grammar1 = new Grammar();
        List<Label> labels = new List<Label>();
        int labelsInt = 0;

        //increment/decrement this to affect x position of labels
        int positionx = 48;
        //increment/decrement this to affect y position of labels
        int positiony = 48;
        //the adjective we use to describe our character.
        //used to determine whether we use "a" or "an" in grammar
        string quality1;
        bool storyDrawn = false;

        private void button1_Click(object sender, EventArgs e)
        {
            positionx = 48;
            positiony = 48;

            if (!storyDrawn)
            {
                DrawStory();
            }
            else if (storyDrawn)
            {
                ChangeStory(character1);
            }
            storyDrawn = true;
        }

        //create a character and write their name to the screen
        private void DrawNewCharacter(Character character)
        {
            Label charLabel = new Label();
            //add on-click event for this label
            charLabel.Click += CharLabel_Click;
            character.Name = character.GetCharacterName();
            charLabel.Text = character.Name;
            PositionText(charLabel);
            labels.Add(charLabel);
            grammar1.WroteCharacter = true;
        }

        //on label click
        private void CharLabel_Click(object sender, EventArgs e)
        {
            if (!character1.IsNameLocked)
            {
                character1.IsNameLocked = true;
            }
            else if (character1.IsNameLocked)
            {
                character1.IsNameLocked = false;
            }
        }

        //draw a verb (for example, "was")
        private void DrawNewVerb(Grammar grammar)
        {
            Label verbLabel = new Label();
            verbLabel.Text = grammar1.GetVerb(character1, event1);
            labels.Add(verbLabel);
            PositionText(verbLabel);
        }

        //draw an article (for example, "a" or "the")
        private void DrawNewArticle(Grammar grammar)
        {
            Label artLabel = new Label();
            artLabel.Text = grammar1.GetArticle(rnd);
            if (artLabel.Text == "a")
            {
                char[] quality1array = quality1.ToCharArray();
                if (quality1array[0] == 'a' || quality1array[0] == 'e' || quality1array[0] == 'i'
                    || quality1array[0] == 'o' || quality1array[0] == 'u')
                {
                    artLabel.Text = "an";
                }
                else
                {

                }
            }
            else
            {

            }
            PositionText(artLabel);
            labels.Add(artLabel);
        }

        private void DrawNewCharQuality(Character character)
        {
            Label qualLabel = new Label();
            character.Quality = character.GetCharacterQuality(rnd);
            qualLabel.Text = character.Quality;
            PositionText(qualLabel);
            labels.Add(qualLabel);
        }

        private void DrawNewCharProfession(Character character)
        {
            Label profLabel = new Label();
            profLabel.Text = character.GetCharacterProfession(rnd);
            PositionText(profLabel);
            labels.Add(profLabel);
        }

        private void DrawNewPunctuation()
        {
            Label punctLabel = new Label();
            punctLabel.Text = grammar1.GetPunctuation(rnd);
            PositionText(punctLabel);
            //this closes some of the white space between labels to make punctuation look better
            punctLabel.Location = new Point (punctLabel.Location.X - 2, punctLabel.Location.Y);
            labels.Add(punctLabel);
        }

        private void PositionText(Label label)
        {
            this.Controls.Add(label);
            label.AutoSize = true;
            label.Location = new Point(positionx, positiony);
            //if label reaches the end of the form, move to the next line when writing
            if (label.Width + label.Location.X > 800)
            {
                positiony += label.Height;
                positionx = 0;
                label.Location = new Point(positionx, positiony);
            }
            else
            {

            }
            //update the x position of the next label
            positionx += label.Width - 2;
        }

        //draws story to screen
        private void DrawStory()
        {
            DrawNewCharacter(character1);
            DrawNewVerb(grammar1);
            //get a quality for the character so we can determine whether or not
            //it starts with a vowel (so we know whether we need to use "a" or "an")
            quality1 = character1.GetCharacterQuality(rnd);
            DrawNewArticle(grammar1);
            DrawNewCharQuality(character1);
            DrawNewCharProfession(character1);
            DrawNewPunctuation();
        }

        //re-randomizes unlocked story elements when Generate button is clicked
        private void ChangeStory(Character character)
        {
            if (character.IsNameLocked)
            {
                //change this to character1.GetCharacterName();
                character.Name = "NewName";
                labels[labelsInt].Text = character.Name;
                //FIX THIS
                while (labelsInt < labels.Count)
                {
                    foreach (var item in labels)
                    {
                        PositionText(labels[labelsInt]);
                        labelsInt++;
                    }
                }
                labelsInt++;

            }
            else
            {

            }
            if (character.IsQualityLocked)
            {
                character.Quality = character.GetCharacterQuality(rnd);
                PositionText(labels[labelsInt]);
                labelsInt++;
            }
            else
            {

            }
            if (character.IsProfessionLocked)
            {
                character.Profession = character.GetCharacterProfession(rnd);
                PositionText(labels[labelsInt]);
                labelsInt++;
            }
            else
            {

            }
        }

        

    }
}
