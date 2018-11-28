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
            //these are used for iteration
            positionx = 48;
            positiony = 48;
            labelsInt = 0;

            if (!storyDrawn)
            {
                DrawStory();
                storyDrawn = true;
            }
            else if (storyDrawn)
            {
                ReDrawStory(character1);
            }
        }

        //create a character and write their name to the screen
        private void DrawNewCharacter(Character character)
        {
            Label charLabel = new Label();
            //add on-click event for this label
            charLabel.Click += CharLabel_Click;
            character.Name = character.GetCharacterName(rnd);
            charLabel.Text = character.Name;
            PositionText(charLabel);
            labels.Add(charLabel);
            grammar1.WroteCharacter = true;
        }

        //on label click
        private void CharLabel_Click(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            if (!character1.IsNameLocked)
            {
                ctrl.BackColor = Color.DarkGray;
                character1.IsNameLocked = true;
            }
            else if (character1.IsNameLocked)
            {

                ctrl.BackColor = Color.LightGray;
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
            artLabel.Text = grammar1.GetArticle(rnd, quality1);
            PositionText(artLabel);
            labels.Add(artLabel);
        }

        private void DrawNewCharQuality(Character character)
        {
            Label qualLabel = new Label();
            qualLabel.Click += QualLabel_Click;
            //quality1 should be used the first time a story is drawn,
            //then every time a story is re-drawn, character.GetCharacterQuality() should be used.
            character.Quality = quality1;
            qualLabel.Text = character.Quality;
            PositionText(qualLabel);
            labels.Add(qualLabel);
        }

        private void QualLabel_Click(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            if (!character1.IsQualityLocked)
            {
                ctrl.BackColor = Color.DarkGray;
                character1.IsQualityLocked = true;
            }
            else if (character1.IsQualityLocked)
            {
                ctrl.BackColor = Color.LightGray;
                character1.IsQualityLocked = false;
            }
        }

        private void DrawNewCharProfession(Character character)
        {
            Label profLabel = new Label();
            profLabel.Click += ProfLabel_Click;
            profLabel.Text = character.GetCharacterProfession(rnd);
            PositionText(profLabel);
            labels.Add(profLabel);
        }

        private void ProfLabel_Click(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            if (!character1.IsProfessionLocked)
            {
                ctrl.BackColor = Color.DarkGray;
                character1.IsProfessionLocked = true;
            }
            else if (character1.IsProfessionLocked)
            {
                ctrl.BackColor = Color.LightGray;
                character1.IsProfessionLocked = false;
            }
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
        private void ReDrawStory(Character character)
        {

            if (!character.IsNameLocked)
            {
                //change this to character1.GetCharacterName();
                character.Name = character.GetCharacterName(rnd);
                labels[labelsInt].Text = character.Name;
                grammar1.WroteCharacter = true;
                grammar1.WrotePunctuation = false;
                //iterate through labels to reposition them
                labelsInt++;
            }
            else
            {
                grammar1.WroteCharacter = true;
                grammar1.WrotePunctuation = false;
                labelsInt++;
            }

            string verb = grammar1.GetVerb(character1, event1);
            labels[labelsInt].Text = verb;
            labelsInt++;

            //character quality and article are linked
            if (!character.IsQualityLocked)
            {
                character.Quality = character.GetCharacterQuality(rnd);

                string article = grammar1.GetArticle(rnd, character.Quality);
                labels[labelsInt].Text = article;
                labelsInt++;

                labels[labelsInt].Text = character.Quality;
                labelsInt++;
            }
            else
            {
                labelsInt += 2;
            }

            if (!character.IsProfessionLocked)
            {
                character.Profession = character.GetCharacterProfession(rnd);
                labels[labelsInt].Text = character.Profession;
                labelsInt++;
            }
            else
            {
                labelsInt++;
            }

            string punctuation = grammar1.GetPunctuation(rnd);
            labels[labelsInt].Text = punctuation;
            labelsInt++;
            grammar1.WrotePunctuation = true;

            //reposition labels
            int temp = 0;

            while (temp < labels.Count)
            {
                foreach (var item in labels)
                {
                    PositionText(labels[temp]);
                    temp++;
                    if (temp >= labels.Count)
                    {
                        break;
                    }
                }
            }

        }

        

    }
}
