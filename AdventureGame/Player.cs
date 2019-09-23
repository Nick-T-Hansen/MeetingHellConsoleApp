namespace AdventureGame
{
    public class Player //can this be refactored?
    {
        public static string CharacterName { get; set; }
        public static bool LevelOneCompleted { get; set; }
        public static bool LevelTwoCompleted { get; set; }
        public static bool LevelThreeCompleted { get; set; }
        public static bool BossFightCompleted { get; set; }
        public static bool LevelFailed { get; set; }
        public static bool ValidResponse { get; set; }
        //items
        public static bool CoffeeCup { get; set; }
        public static bool Projector { get; set; }
        public static bool PeanutButterSandwich { get; set; }
        public static bool CornflowerTie { get; set; }
        //level two requirements
        public static bool EdTrap { get; set; }
        public static bool FredTrap { get; set; }
        public static int ChoicesRemaining { get; set; }
        //level three requirements
        public static bool EdDead { get; set; }
        public static bool FredDead { get; set; }
        public static bool KarenDead { get; set; }
    }
}