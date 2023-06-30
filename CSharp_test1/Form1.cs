using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_test1
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    public partial class Form1 : Form
    {
        private Button playerButton;
        private Label angelLabel;
        private Label demonLabel;
        private Label godLabel;
        private Label monsterLabel;
        private Label scoreLabel;
        private Label bombLabel1;
        private Label bombLabel2;
        private Label positionLabel;
        private Label mazuLabel;
        private Label pusaLabel;
        private Button upButton;
        private Button downButton;
        private Button leftButton;
        private Button rightButton;
        private TextBox scoreTextBox;
        private TextBox positionTextBox;
        private int score = 0;

        private void ShowGameOver()
        {
            MessageBox.Show("Game Over~~");
            Application.Exit();
        }

        public Form1()
        {
            this.Text = "Csharp_Text1";
            this.Size = new Size(300, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            Panel topPanel = new Panel();
            topPanel.Dock = DockStyle.Top;
            topPanel.Height = 300;
            topPanel.BorderStyle = BorderStyle.Fixed3D;
            this.Controls.Add(topPanel);

            playerButton = new Button();
            playerButton.BackColor = Color.Black;
            playerButton.Size = new Size(36, 36);
            playerButton.Location = new Point(120, 130);
            this.Controls.Add(playerButton);

            mazuLabel = new Label();
            mazuLabel.Text = "媽祖";
            mazuLabel.Size = new Size(30, 18);
            mazuLabel.Location = new Point(30, 30);
            mazuLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(mazuLabel);


            bombLabel1 = new Label();
            bombLabel1.Text = "炸彈";
            bombLabel1.Size = new Size(30, 18);
            bombLabel1.Location = new Point(80, 80);
            topPanel.Controls.Add(bombLabel1);
            this.Controls.Add(bombLabel1);

            bombLabel2 = new Label();
            bombLabel2.Text = "炸彈";
            bombLabel2.Size = new Size(30, 18);
            bombLabel2.Location = new Point(180, 200);
            topPanel.Controls.Add(bombLabel2);
            this.Controls.Add(bombLabel2);

            angelLabel = new Label();
            angelLabel.Text = "天使";
            angelLabel.Size = new Size(30, 18);
            angelLabel.Location = new Point(30, 230);
            angelLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(angelLabel);

            demonLabel = new Label();
            demonLabel.Text = "惡魔";
            demonLabel.Size = new Size(30, 18);
            demonLabel.Location = new Point(170, 78);
            demonLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(demonLabel);

            godLabel = new Label();
            godLabel.Text = "上帝";
            godLabel.Size = new Size(30, 18);
            godLabel.Location = new Point(210, 30);
            godLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(godLabel);

            monsterLabel = new Label();
            monsterLabel.Text = "怪物";
            monsterLabel.Size = new Size(30, 18);
            monsterLabel.Location = new Point(70, 200);
            monsterLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(monsterLabel);

            pusaLabel = new Label();
            pusaLabel.Text = "菩薩";
            pusaLabel.Size = new Size(30, 18);
            pusaLabel.Location = new Point(210, 240);
            pusaLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(pusaLabel);

            scoreLabel = new Label();
            scoreLabel.Text = "Score : ";
            score.ToString();
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(10, 340);
            this.Controls.Add(scoreLabel);

            scoreTextBox = new TextBox();
            scoreTextBox.Text = "0";
            scoreTextBox.Multiline = true;
            scoreTextBox.ReadOnly = true;
            scoreTextBox.Size = new Size(70, 20);
            scoreTextBox.Location = new Point(50, 340);
            this.Controls.Add(scoreTextBox);

            positionLabel = new Label();
            positionLabel.Text = "座標 :";
            positionLabel.AutoSize = true;
            positionLabel.Location = new Point(10, 405);
            this.Controls.Add(positionLabel);

            positionTextBox = new TextBox();
            positionTextBox.Multiline = true;
            positionTextBox.ReadOnly = true;
            positionTextBox.Size = new Size(70, 20);
            positionTextBox.Location = new Point(50, 400);
            this.Controls.Add(positionTextBox);

            upButton = new Button();
            upButton.Text = "上";
            upButton.Size = new Size(50, 50);
            upButton.Location = new Point(180, 320);
            upButton.Click += (sender, e) => MovePlayer(sender, e, Direction.Up);
            this.Controls.Add(upButton);

            downButton = new Button();
            downButton.Text = "下";
            downButton.Size = new Size(50, 50);
            downButton.Location = new Point(180, 380);
            downButton.Click += (sender, e) => MovePlayer(sender, e, Direction.Down);
            this.Controls.Add(downButton);

            leftButton = new Button();
            leftButton.Text = "左";
            leftButton.Size = new Size(50, 50);
            leftButton.Location = new Point(130, 350);
            leftButton.Click += (sender, e) => MovePlayer(sender, e, Direction.Left);
            this.Controls.Add(leftButton);

            rightButton = new Button();
            rightButton.Text = "右";
            rightButton.Size = new Size(50, 50);
            rightButton.Location = new Point(230, 350);
            rightButton.Click += (sender, e) => MovePlayer(sender, e, Direction.Right);
            this.Controls.Add(rightButton);
            this.Controls.Add(topPanel);
        }


        private void MovePlayer(object sender, EventArgs e, Direction
        direction)
        {
            positionTextBox.Text = $"({playerButton.Location.X},{playerButton.Location.Y})";
            switch (direction)
            {
                case Direction.Up:
                    playerButton.Top -= 10;
                    break;
                case Direction.Down:
                    playerButton.Top += 10;
                    break;
                case Direction.Right:
                    playerButton.Left += 10;
                    break;
                case Direction.Left:
                    playerButton.Left -= 10;
                    break;
                default:
                    break;
            }

            if (playerButton.Bounds.IntersectsWith(angelLabel.Bounds))
            {
                score += 6;
            }
            else if (playerButton.Bounds.IntersectsWith(demonLabel.Bounds))
            {
                if (score < 4)
                {
                    score = 0;
                }
                else
                {
                    score -= 4;
                }
            }
            else if (playerButton.Bounds.IntersectsWith(godLabel.Bounds))
            {
                score += 3;
            }
            else if (playerButton.Bounds.IntersectsWith(mazuLabel.Bounds))
            {
                score += 2;
            }
            else if (playerButton.Bounds.IntersectsWith(monsterLabel.Bounds))
            {
                if (score < 8)
                {
                    score = 0;
                }
                else
                {
                    score -= 8;
                }
            }
            scoreTextBox.Text = score.ToString();

            if (playerButton.Bounds.IntersectsWith(bombLabel1.Bounds))
            {
                ShowGameOver();
                return;
            }
            if (playerButton.Bounds.IntersectsWith(bombLabel2.Bounds))
            {
                ShowGameOver();
                return;
            }
            if (score != 0 & score % 7 == 0)
            {
                MessageBox.Show("You Win!!");
                Application.Exit();
            }
        }
    }

}
