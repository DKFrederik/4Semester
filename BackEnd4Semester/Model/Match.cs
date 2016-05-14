namespace Model
{
    public class Match : Events
    {
        public Team Team { get; set; }
        public string Opponent { get; set; }
        public int HomeGoal { get; set; }
        public int AwayGoal { get; set; }
    }
}
