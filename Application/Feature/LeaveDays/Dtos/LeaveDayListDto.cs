using Domain.Dtos;
using Domain.Entities;

namespace Application.Feature.LeaveDays.Dtos
{
    public class LeaveDayListDto : IDto
    {
        public int NumberOfDays { get; set; }
        public string Note { get; set; }
        public DateTime EntryDate { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
