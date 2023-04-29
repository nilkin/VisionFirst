namespace Domain.Entities
{
    public partial class Account : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
