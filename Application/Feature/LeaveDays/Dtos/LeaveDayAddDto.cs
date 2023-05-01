using Application.Feature.Positions.Dtos;

namespace Application.Feature.LeaveDays.Dtos
{
    public class LeaveDayAddDto
    {
        public int? NumberOfDays { get; set; }
        public string? Note { get; set; }
        public int? PositionId { get; set; }
        public IList<PositionListDto>? Positions { get; set; }
    }
}
