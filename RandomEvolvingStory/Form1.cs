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

        //to do: figure out how to delete old labels so new labels can be added
        //and iterated through

        //create character and event objects
        Random rnd = new Random();
        Storyteller storyteller = new Storyteller();
        List<Label> labels = new List<Label>();

        //increment/decrement this to affect x position of labels
        int positionx = 48;
        //increment/decrement this to affect y position of labels
        int positiony = 48;
        //use this to lock/unlock labels from being randomized.
        //false by default.
        List<bool> isLocked = new List<bool> { };

        private void button1_Click(object sender, EventArgs e)
        {
            //these are used for iteration
            positionx = 48;
            positiony = 48;

            //get story elements before drawing them so we can manipulate them
            //to make them grammatically correct.
            GetStory();
            DrawStory();
        }

        //use storyteller.StoryElements for labelText
        private void DrawNewLabel(string labelText)
        {
            Label label = new Label();

            //add Label_Click method
            label.Click += Label_Click;

            label.Text = labelText;
            labels.Add(label);

            //add a false bool to the isLocked bool list.
            //this will allow iteration through each bool to see if corresponding
            //labels are locked or unlocked.
            isLocked.Add(false);
            PositionText(label);
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Control ctrl = ((Control)sender);
            int index = labels.FindIndex(x => x == ctrl);
            if (!isLocked[index])
            {
                ctrl.BackColor = Color.DarkGray;
                isLocked[index] = true;
            }
            else if (isLocked[index])
            {
                ctrl.BackColor = Color.LightGray;
                isLocked[index] = false;
            }
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

        private List<string> GetStory()
        {
            //clear lists so we can create and iterate through new ones
            isLocked.Clear();
            storyteller.StoryElements.Clear();

            storyteller.GetStoryElements(rnd);
            return storyteller.StoryElements;
        }

        //draws story to screen
        private void DrawStory()
        {
            int temp = 0;

            //draw labels for the current story
            foreach (var item in storyteller.StoryElements)
            {
                DrawNewLabel(storyteller.StoryElements[temp]);
                temp++;
            }
        }
        
    }
}
