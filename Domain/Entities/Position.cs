namespace Domain.Entities
{
    public partial class Position : Entity
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }
        public string Title { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int DepartmentId { get; set; } 
        public Department Department { get; set; }
        public LeaveDay LeaveDay { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
