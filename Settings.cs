namespace Snake
{
    public enum Direction   //defines possible directions a player can move
    {
        Up,
        Down,
        Left,
        Right
    };

    public class Settings
    {
        public static int Width { get; set; }   //Used to alter the width of objects relative to the board
        public static int Height { get; set; }  //Used to alter the hieght of objects relative to the board
        public static int Speed { get; set; }   //Used to alter the speed of the snake (and other objects)
        public static int Score { get; set; }   //The current score
        public static int Eaten { get; set; }   //The amount of food eaten
        public static int EnemyBonus { get; set; }  //A bonus used in score keeping (during the remove enemy powerup) 
        public static int FoodBonus { get; set; }   //A bonus used in score keeping (during the bonus points powerup)
        public static int Points { get; set; }  //Value of eating a food object
        public static bool GameOver { get; set; }   //Tracks the status of the game
        public static Direction direction { get; set; } //Which direction the player is moving
        public static bool PowerupDown;     //When a powerup is visable and can be gotten
        public static int EatenMultiplier;  //A bonus used in score keeping (during the double points powerup)
        public static int EnemySpeed;       //Multiplier used for powerups that alter the enemies' speed
        public static bool ChaseMode;       //Signifies if that powerup is active
        public static bool IronStomach;     //Signifies if that powerup is active
        public static bool FreezeFrame;     //Signifies if that powerup is active
        public static int PowerupLength;    //Determines how long powerups are in effect for

        public Settings()   //Declares default values
        {
            Width = 16;
            Height = 16;
            Speed = 10;
            Score = 0;
            Eaten = 0;
            FoodBonus = 0;
            EnemyBonus = 0;
            Points = 1;
            GameOver = false;
            direction = Direction.Down;
            PowerupDown = false;
            EatenMultiplier = 0;
            EnemySpeed = 2;
            ChaseMode = false;
            IronStomach = false;
            FreezeFrame = false;
            PowerupLength = 5;
        }
    }


}