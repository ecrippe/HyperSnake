using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> snake = new List<Circle>();    //Creates the snake
        private Circle food = new Circle();                 //Creates a food object
        private Powerup pow = new Powerup();                //Creates a powerup object
        private List<Circle> enemies = new List<Circle>();  //Creates a list of all enemies
        private Random random = new Random();               //Used to generate random numbers
        private int clockTick;          //Stores Timer value
        private int gameClock;          //Shows length of current game on scoreboard
        private int initialTimer;       //Stores the timer value when the game starts (to calculate game clock)
        private int ticks = 0;          //Used to determine when to move the enemies
        private int highscore = 0;      //Tracks the highest score since the program was opened
        private int maxEnemies = 0;     //Stores the maximum number of enemies that appeared on the board that game

        public Form1()
        {
            InitializeComponent();

            //Set settings to default
            new Settings();

            //Set game speed and start timer
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //Start New game
            StartGame();
        }

        //Creates a new game and initializes things as necessary
        private void StartGame()
        {
            lblGameOver.Visible = false;

            //Set settings to default
            new Settings();

            //Define offset from continual timer
            initialTimer = Int32.Parse(clockTick.ToString());

            //Create new snake and enemy set
            snake.Clear();
            enemies.Clear();
            //Create and add the head
            Circle head = new Circle {X = 10, Y = 5};
            snake.Add(head);
            //Create and add the two body elements
            Circle circle = new Circle
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };
            snake.Add(circle);
            Circle circle2 = new Circle
            {
                X = snake[snake.Count - 2].X,
                Y = snake[snake.Count - 2].Y
            };
            snake.Add(circle2);

            //reset enemy counter
            maxEnemies = 0;
            
            lblScore.Text = Settings.Score.ToString();
            AddFood();

        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver)  //if the game is over, no more moving
            {
                if (Input.KeyPressed(Keys.Enter))   //wait to see if they want a new game
                {
                    StartGame();
                }
            }
            else    //if the game is still going, wait for next move
            {
                if ( Input.KeyPressed(Keys.Up) )
                {
                    Settings.direction = Direction.Up;
                }
                else if ( Input.KeyPressed(Keys.Down) )
                {
                    Settings.direction = Direction.Down;
                }
                else if ( Input.KeyPressed(Keys.Left) )
                {
                    Settings.direction = Direction.Left;
                }
                else if ( Input.KeyPressed(Keys.Right) )
                {
                    Settings.direction = Direction.Right;
                }

                Move();
            }

            pbCanvas.Invalidate();

        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver) //if the game isn't over, redraw everything
            {
                Brush sColor;   //Set colour of snake

                for (int i = 0; i < snake.Count; i++)   // Draws the snake
                {

                    if (Settings.IronStomach)   //sets colors for snake during iron stomach powerup
                    {
                        if (i == 0)
                        {
                            sColor = Brushes.Black;
                        }
                        else if(i == 1)
                        {
                            sColor = Brushes.Purple;
                        }
                        else
                        {
                            sColor = Brushes.DeepPink;
                        }
                    }
                    else        // Sets colors for normal snake
                    {
                        if (i == 0) // Normal snake head color
                        {
                            sColor = Brushes.Black;
                        }
                        else    // Normal snake body color
                        {
                            sColor = Brushes.Gray;
                        }
                    }

                    // Draws the snake
                    canvas.FillEllipse(sColor, new Rectangle(snake[i].X * Settings.Width,
                        snake[i].Y * Settings.Height, Settings.Width, Settings.Height));

                    // Draws a food object
                    canvas.FillEllipse(Brushes.Yellow, new Rectangle(food.X * Settings.Width,
                        food.Y * Settings.Height, Settings.Width, Settings.Height));

                    if (Settings.PowerupDown)   // Draws a powerup
                    {
                        canvas.FillEllipse(Brushes.Blue, new Rectangle(pow.X * Settings.Width,
                            pow.Y * Settings.Height, Settings.Width, Settings.Height));
                    }

                    foreach (Circle c in enemies)   // Draws the array of enemies
                    {
                        canvas.FillEllipse(Brushes.Red, new Rectangle(c.X * Settings.Width,
                            c.Y * Settings.Height, Settings.Width, Settings.Height));
                    }

                }
            }
            else    // handles the game ending
            {
                if (Settings.Score > highscore) //check for highscore
                {
                    highscore = Settings.Score;
                }
                if (Settings.EnemyBonus > maxEnemies)   //track most enemies faced that game
                {
                    maxEnemies = Settings.EnemyBonus;
                }
                string gameOver = "Game over " +
                                    "\nYour final score is: " + lblScore.Text + "\n" +
                                    "You faced " + maxEnemies + " poisoned " +
                                    "\n         apples this round" +
                                    "\nPress Enter to try again";

                lblGameOver.Text = gameOver;
                lblGameOver.Visible = true;
            }
        }

        //Move player
        private void Move()
        {
            //Get X and Y limits as adjusted for the screen and settings
            int xMax = pbCanvas.Size.Width / Settings.Width;
            int yMax = pbCanvas.Size.Height / Settings.Height;

            for (int i = snake.Count - 1; i >= 0; i--)
            {

                // Move head, rest will follow
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            snake[i].X++;
                            break;
                        case Direction.Left:
                            snake[i].X--;
                            break;
                        case Direction.Up:
                            snake[i].Y--;
                            break;
                        case Direction.Down:
                            snake[i].Y++;
                            break;
                    }

                    // Check for border collision
                    if (snake[i].X < 0)
                    {
                        Settings.direction = Direction.Right;
                        Move();
                    }
                    if (snake[i].Y < 0)
                    {
                        Settings.direction = Direction.Down;
                        Move();
                    }
                    if (snake[i].X >= xMax)
                    {
                        Settings.direction = Direction.Left;
                        Move();
                    }
                    if (snake[i].Y >= yMax)
                    {
                        Settings.direction = Direction.Up;
                        Move();
                    }

                    // Check for enemy collision
                    foreach (Circle c in enemies.Where(e => e.X == snake[0].X && e.Y == snake[0].Y))
                    {
                        if (Settings.IronStomach)
                        {
                            enemies.Remove(c);
                            break;
                        }
                        else
                        {
                            EndGame();
                        }
                    }

                    // Check for collision with food
                    if (snake[0].X == food.X && snake[0].Y == food.Y)
                    {
                        EatFood();
                    }

                    // Check for colission with powerup
                    if (snake[0].X == pow.X && snake[0].Y == pow.Y && Settings.PowerupDown)
                    {
                        switch (pow.Ability)    //enact the appropriate powerup
                        {
                            case "Bonus Points":
                                BonusPoints();
                                Settings.PowerupDown = false;
                                break;
                            case "Slow Enemies":
                                SlowEnemies();
                                Settings.PowerupDown = false;
                                break;
                            case "Double Points":
                                DoublePoints();
                                Settings.PowerupDown = false;
                                break;
                            case "Speed Enemies":
                                SpeedEnemies();
                                Settings.PowerupDown = false;
                                break;
                            case "Remove Enemy":
                                DeleteEnemy();
                                Settings.PowerupDown = false;
                                break;
                            case "Add Enemy":
                                ExtraEnemy();
                                Settings.PowerupDown = false;
                                break;
                            case "Chase Mode":
                                ChaseMode();
                                Settings.PowerupDown = false;
                                break;
                            case "Iron Stomach":
                                IronStomach();
                                Settings.PowerupDown = false;
                                break;
                            case "FreezeFrame":
                                FreezeFrame();
                                Settings.PowerupDown = false;
                                break;
                            default:
                                break;
                        }
                    }

                }
                else
                {
                    // Move body
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }

            foreach (Circle c in enemies) //movement of enemies
            {

                //deal with 'divide by zero' error
                int remainder;
                if (Settings.EnemySpeed < 1)
                {
                    remainder = 0;
                }
                else
                {
                    remainder = ticks % Settings.EnemySpeed;
                }


                if (remainder == 0) //makes the enemies move half as frequently by default
                {
                    if (Settings.ChaseMode) //all enemies move twards snake
                    {
                        if (c.Y < snake[0].Y)
                        {
                            c.Y++;
                        }
                        else if (c.Y > snake[0].Y)
                        {
                            c.Y--;
                        }
                        if (c.X < snake[0].X)
                        {
                            c.X++;
                        }
                        else if (c.X > snake[0].X)
                        {
                            c.X--;
                        }
                    }
                    else if (Settings.FreezeFrame)  //powerup that stops motion
                    {

                    }
                    else
                    {
                        //determines which direction each enemy moves randomly
                        int eDirection = random.Next(5);
                        switch (eDirection)
                        {
                            case 1:
                                c.Y--;
                                if (c.Y < 0)    //makes sure enemy doesn't leave the map
                                {
                                    c.Y += 2;
                                }
                                break;
                            case 2:
                                c.X--;
                                if (c.X < 0)
                                {
                                    c.X += 2;
                                }
                                break;
                            case 3:
                                c.Y++;
                                if (c.Y >= yMax)
                                {
                                    c.Y -= 2;
                                }
                                break;
                            case 4:
                                c.X++;
                                if (c.X >= xMax)
                                {
                                    c.X -= 2;
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }
            ticks++;    //used for enemy movement frequency
        }

        //Event handlers for the key presses
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
        
        //Add a new food object
        private void AddFood()
        {
            int xMax = pbCanvas.Size.Width / Settings.Width;
            int yMax = pbCanvas.Size.Height / Settings.Height;

            //places it randomly on the map
            food = new Circle { X = random.Next(0, xMax), Y = random.Next(0, yMax) };
        }

        //Add a new enemy object
        private void AddEnemy()
        {
            int xMax = pbCanvas.Size.Width / Settings.Width;
            int yMax = pbCanvas.Size.Height / Settings.Height;

            int xPos = random.Next(xMax);
            while (Math.Abs(xPos - snake[0].X) < 1) //error check to make sure enemies don't spawn too close
            {
                xPos = random.Next(xMax);   //random position generator
            }
            int yPos = random.Next(yMax);
            while (Math.Abs(yPos - snake[0].Y) < 1)
            {
                yPos = random.Next(yMax);
            }

            Circle circle = new Circle
            {
                X = xPos,
                Y = yPos
            };
            enemies.Add(circle);

            if (enemies.Count() >= Settings.EnemyBonus) //tracks max number of enemies faced
            {
                Settings.EnemyBonus++;
            }

        }

        //Add a new powerup object
        private void AddPowerup()
        {
            int xMax = pbCanvas.Size.Width / Settings.Width;
            int yMax = pbCanvas.Size.Height / Settings.Height;
            string ability = "None";
            int abilNum = random.Next(9);

            switch (abilNum)
            {
                case 0:
                    ability = "Remove Enemy";
                    break;
                case 1:
                    ability = "Bonus Points";
                    break;
                case 2:
                    ability = "Slow Enemies";
                    break;
                case 3:
                    ability = "Double Points";
                    break;
                case 4:
                    ability = "Speed Enemies";
                    break;
                case 5:
                    ability = "Add Enemy";
                    break;
                case 6:
                    ability = "Chase Mode";
                    break;
                case 7:
                    ability = "Iron Stomach";
                    break;
                case 8:
                    ability = "FreezeFrame";
                    break;
                default:
                    ability = "Speed Enemies";
                    break;
            }

            pow = new Powerup { X = random.Next(0, xMax), Y = random.Next(0, yMax), Ability = ability };

            Settings.PowerupDown = true;
        }

        //Adds new food and enemy when food is eaten
        private void EatFood()
        {
            //Update Score
            Settings.Eaten += Settings.Points;
            Settings.FoodBonus = Settings.EatenMultiplier + Settings.Eaten;

            AddEnemy();
            AddFood();
        }

        //Used to track when the game is over
        private void EndGame()
        {
            Settings.GameOver = true;
        }

        //**Powerup methods:
        //Add a new enemy object from powerup
        private async void ExtraEnemy()
        {
            lblPowerup.Text = pow.Ability;
            AddEnemy();
            await Task.Delay(1000);
            lblPowerup.Text = " ";
        }

        //Add extra points
        private async void BonusPoints()
        {
            lblPowerup.Text = pow.Ability;
            Settings.FoodBonus += 2;
            await Task.Delay(1000);
            lblPowerup.Text = " ";
        }

        //Cut enemy speed in half temporarily
        private async void SlowEnemies()
        {
            lblPowerup.Text = pow.Ability;
            Settings.EnemySpeed *= 2;
            await Task.Delay(Settings.PowerupLength * 1000);
            Settings.EnemySpeed /= 2;
            lblPowerup.Text = " ";
        }

        //Doubles points gained while active
        private async void DoublePoints()
        {
            lblPowerup.Text = pow.Ability;
            Settings.EatenMultiplier++;
            await Task.Delay(Settings.PowerupLength * 1000);
            Settings.EatenMultiplier--;
            lblPowerup.Text = " ";
        }

        //Doubles enemies speed temporarily
        private async void SpeedEnemies()
        {
            lblPowerup.Text = pow.Ability;
            Settings.EnemySpeed /= 2;
            await Task.Delay(Settings.PowerupLength * 1000);
            Settings.EnemySpeed *= 2;
            lblPowerup.Text = " ";
        }

        //Removes an ememy
        private async void DeleteEnemy()
        {
            lblPowerup.Text = pow.Ability;
            if (enemies.Any()) //Error check for empty lists
            {
                enemies.RemoveAt(enemies.Count - 1);
            }
            await Task.Delay(1000);
            lblPowerup.Text = " ";
        }

        //All enemies move towards the snake temporarily
        private async void ChaseMode()
        {
            lblPowerup.Text = pow.Ability;
            Settings.ChaseMode = true;
            Settings.EnemySpeed *= 2;
            await Task.Delay(Settings.PowerupLength * 500);
            Settings.ChaseMode = false;
            Settings.EnemySpeed /= 2;
            lblPowerup.Text = " ";
        }

        //snake can eat enemies temporarily
        private async void IronStomach()
        {
            lblPowerup.Text = pow.Ability;
            Settings.IronStomach = true;
            await Task.Delay(Settings.PowerupLength * 750);
            Settings.IronStomach = false;
            lblPowerup.Text = " ";
        }

        //All enemies stop movint temporarily
        private async void FreezeFrame()
        {
            lblPowerup.Text = pow.Ability;
            Settings.FreezeFrame = true;
            await Task.Delay(Settings.PowerupLength * 500);
            Settings.FreezeFrame = false;
            lblPowerup.Text = " ";
        }

        //**End of powerup methods

        //Used for the event handlers
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        //Method that is controlled by the Timer and handles things related to clock ticks
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Creates a 1/50 chance of spawning a powerup every tick
            int powerupRandomizer = random.Next(50);
            if (powerupRandomizer == 13 && !Settings.PowerupDown)
            {
                AddPowerup();
            }

            //Scoreboard information updates every tick
            lblEnemies.Text = enemies.Count.ToString();
            lblHighscore.Text = highscore.ToString();
            clockTick++;
            gameClock = ( Int32.Parse(clockTick.ToString()) - initialTimer ) / 5;
            if (Settings.Eaten != 0 && !Settings.GameOver && gameClock != 0)
            {
                Settings.Score = Settings.FoodBonus * 100 * Settings.EnemyBonus / (int)Math.Sqrt(gameClock);
            }
            else
            {
                Settings.Score = 0;
            }

            //Stop updating info when game ends
            if (!Settings.GameOver)
            {
                lblTimer.Text = gameClock.ToString();
                lblScore.Text = Settings.Score.ToString();
            }

        }

        
    }
}
