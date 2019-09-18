namespace AdventureGame
{
    public class Player
    {
        public static string CharacterName { get; set; }
        public static bool LevelOneCompleted { get; set; }
        public static bool LevelTwoCompleted { get; set; }
        public static bool LevelThreeCompleted { get; set; }
        public static bool LevelFailed { get; set; }
        public static bool ValidResponse { get; set; } //validate user response to meet the proper criteria
        public static bool CoffeeCup { get; set; }
        public static bool Projector { get; set; }
        public static bool PeanutButterSandwich { get; set; }
        public static bool CornflowerTie { get; set; }
        public static bool EdTrap { get; set; }
        public static bool FredTrap { get; set; }
        public static int ChoicesRemaining { get; set; }

        public bool EdDead { get; set; }
        public bool FredDead { get; set; }
        public bool KarenDead { get; set; }
    }
}