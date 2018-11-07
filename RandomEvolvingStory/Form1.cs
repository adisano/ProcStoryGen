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
        Character character1 = new Character();
        Event event1 = new Event();

        //increment/decrement this to affect horizontal position of text
        int positionx = 0;
        //increment/decrement this to affect vertical position of text
        int positiony = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            AddCharacter(character1);




            /*
            Label label1 = new Label();
            label1.Text = "Test";
            label1.AutoSize = true;
            label1.Location = new Point(24, 48);
            this.Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "Test2";
            label2.AutoSize = true;
            label2.Location = new Point(label1.Location.X + label1.Width, label1.Location.Y);
            this.Controls.Add(label2);
            */
        }

        private void AddCharacter(Character character)
        {
            Label charLabel = new Label();
            character.Name = character1.NameCharacter();
            charLabel.Text = character.Name;
            charLabel.AutoSize = true;
            charLabel.Location = new Point(positionx + charLabel.Width, positiony + charLabel.Height);
            this.Controls.Add(charLabel);
        }

    }
}
