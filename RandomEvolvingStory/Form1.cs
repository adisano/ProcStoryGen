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

        //increment/decrement this to affect x position of labels
        int positionx = 48;
        //increment/decrement this to affect y position of labels
        int positiony = 48;
        //the adjective we use to describe our character. used to determine whether we use "a" or "an" in grammar
        string quality1;

        private void button1_Click(object sender, EventArgs e)
        {
            DrawNewCharacter(character1);
            DrawNewVerb(grammar1);
            //get a quality for the character so we can determine whether or not
            //it starts with a vowel (so we know whether we need to use "a" or "an")
            quality1 = character1.GetCharacterQuality(rnd);
            DrawNewArticle(grammar1);
            DrawNewCharQuality(quality1);
            DrawNewCharProfession(character1);
            DrawNewPunctuation();
        }

        //create a character and write their name to the screen
        private void DrawNewCharacter(Character character)
        {
            Label charLabel = new Label();
            character.Name = character1.NameCharacter();
            charLabel.Text = character.Name;
            PositionText(charLabel);
            grammar1.WroteCharacter = true;
        }

        //draw a verb and article (for example, "... was a...")
        private void DrawNewVerb(Grammar grammar)
        {
            Label verbLabel = new Label();
            verbLabel.Text = grammar1.GetVerb(character1, event1);
            PositionText(verbLabel);
        }

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
        }

        private void DrawNewCharQuality(string quality)
        {
            Label qualLabel = new Label();
            qualLabel.Text = quality;
            PositionText(qualLabel);
        }

        private void DrawNewCharProfession(Character character)
        {
            Label profLabel = new Label();
            profLabel.Text = character.GetCharacterProfession(rnd);
            PositionText(profLabel);
        }

        private void DrawNewPunctuation()
        {
            Label punctLabel = new Label();
            punctLabel.Text = grammar1.GetPunctuation(rnd);
            PositionText(punctLabel);
            punctLabel.Location = new Point (punctLabel.Location.X - 2, punctLabel.Location.Y);
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
    }
}
