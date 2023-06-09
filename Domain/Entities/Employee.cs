﻿namespace Domain.Entities
{
    public partial class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<LeaveApplication> LeaveApplications { get; set; }
        public virtual Account Account { get; set; }


    }
}
