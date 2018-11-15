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
            
            DrawNewCharacter(character1);

        }

        private void DrawNewCharacter(Character character)
        {
            Label charLabel = new Label();
            charLabel.AutoSize = true;
            character.Name = character1.NameCharacter();
            charLabel.Text = character.Name;
            charLabel.BorderStyle = BorderStyle.FixedSingle;
            charLabel.Location = new Point(positionx + charLabel.Width, positiony + charLabel.Height);
            positionx += charLabel.Width;
            this.Controls.Add(charLabel);
        }

    }
}
