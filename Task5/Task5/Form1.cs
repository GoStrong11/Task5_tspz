using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            PictureBox castlePictureBox = new PictureBox();
            castlePictureBox.Size = new Size(300, 300);
            castlePictureBox.Location = new Point(10, 10);
            castlePictureBox.Paint += CastlePictureBox_Paint; 
            this.Controls.Add(castlePictureBox);

            Button okButton = new Button();
            okButton.Text = "Ok";
            okButton.Size = new Size(75, 30);
            okButton.Location = new Point(50, 370);
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            Button aboutButton = new Button();
            aboutButton.Text = "About";
            aboutButton.Size = new Size(75, 30);
            aboutButton.Location = new Point(150, 370);
            aboutButton.Click += AboutButton_Click;
            this.Controls.Add(aboutButton);
        }

        private void CastlePictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawCastle(g);
        }

        private void DrawCastle(Graphics g)
        {
            int castleWidth = 100;
            int castleHeight = 100;
            int towerWidth = 50;
            int towerHeight = 150;
            int windowSize = 40;

            int castleX = 80;
            int castleY = 150;

            g.FillRectangle(Brushes.Gray, castleX, castleY, castleWidth, castleHeight);

            int innerCubeWidth = 80;
            int innerCubeHeight = 80;
            int innerCubeX = castleX + (castleWidth - innerCubeWidth) - 10;
            int innerCubeY = castleY + (castleHeight - innerCubeHeight);
            g.FillRectangle(Brushes.Blue, innerCubeX, innerCubeY, innerCubeWidth, innerCubeHeight);

            int innermostCubeWidth = 60;
            int innermostCubeHeight = 65;
            int innermostCubeX = innerCubeX + (innerCubeWidth - innermostCubeWidth) - 10;
            int innermostCubeY = innerCubeY + (innerCubeHeight - innermostCubeHeight);
            g.FillRectangle(Brushes.Green, innermostCubeX, innermostCubeY, innermostCubeWidth, innermostCubeHeight);

            int leftTowerX = castleX - towerWidth;
            int leftTowerY = castleY - towerHeight + castleHeight;
            g.FillRectangle(Brushes.SaddleBrown, leftTowerX, leftTowerY, towerWidth, towerHeight);
            g.FillRectangle(Brushes.Yellow, leftTowerX + 15, leftTowerY + 20, windowSize / 2, windowSize);
            g.FillRectangle(Brushes.Yellow, leftTowerX + 15, leftTowerY + 90, windowSize / 2, windowSize);
            Point[] leftRoofPoints = { new Point(leftTowerX, leftTowerY),
                                       new Point(leftTowerX + towerWidth / 2, leftTowerY - 40),
                                       new Point(leftTowerX + towerWidth, leftTowerY) };
            g.FillPolygon(Brushes.Red, leftRoofPoints);

            int rightTowerX = castleX + castleWidth;
            int rightTowerY = castleY - towerHeight + castleHeight;
            g.FillRectangle(Brushes.SaddleBrown, rightTowerX, leftTowerY, towerWidth, towerHeight);
            g.FillRectangle(Brushes.Yellow, rightTowerX + 15, leftTowerY + 20, windowSize / 2, windowSize);
            g.FillRectangle(Brushes.Yellow, rightTowerX + 15, leftTowerY + 90, windowSize / 2, windowSize);
            Point[] rightRoofPoints = { new Point(rightTowerX, leftTowerY),
                                        new Point(rightTowerX + towerWidth / 2, leftTowerY - 40),
                                        new Point(rightTowerX + towerWidth, leftTowerY) };
            g.FillPolygon(Brushes.Red, rightRoofPoints); 
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
    }

    public class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Name = "AboutForm";
            this.Text = "About";

            Label aboutLabel = new Label();
            aboutLabel.Text = "Прізвище, Ім’я: Коба Костянтин\n" +
                               "Група: ІПЗ-21К\n" +
                               "Номер варіанту: 15";
            aboutLabel.AutoSize = true;
            aboutLabel.Location = new Point(10, 10);
            this.Controls.Add(aboutLabel);

            Button okButton = new Button();
            okButton.Text = "Ok";
            okButton.Location = new Point(120, 100);
            okButton.Click += new EventHandler(OkButton_Click);
            this.Controls.Add(okButton);

            this.ResumeLayout(false);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

