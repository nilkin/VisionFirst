namespace Domain.Entities
{
    public partial class LeaveDay : Entity
    {
        public int NumberOfDays { get; set; }
        public string Note { get; set; }
        public DateTime EntryDate { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
