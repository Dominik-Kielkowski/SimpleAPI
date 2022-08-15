using SimpleAPI.Models;

namespace SimpleAPI.AllDtos.Dtos
{
    public class OccupationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Person> People { get; set; }
    }
}
