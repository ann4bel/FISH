namespace FISH.Server
{
    public class Game
    {
        public Game()
        {
            Size = 1;
            TotalSize = 6;
        }
        public int Id { get; set; }
        public int Size { get; set; }

        public int TotalSize { get; set; }

        public string? OwnerName { get; set; }
    }
}
