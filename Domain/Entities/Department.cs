namespace Domain.Entities
{
    public partial class Department:Entity
    {
        public Department()
        {
            Positions = new HashSet<Position>();
        }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string? Record { get; set; }
        public DateTime DateOfEntry { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
