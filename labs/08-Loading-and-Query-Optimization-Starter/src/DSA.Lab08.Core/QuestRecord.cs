namespace DSA.Lab08
{
    public sealed class QuestRecord
    {
        public QuestRecord(string id, string region, int difficulty)
        {
            Id = id;
            Region = region;
            Difficulty = difficulty;
        }

        public string Id { get; }
        public string Region { get; }
        public int Difficulty { get; }
    }
}
