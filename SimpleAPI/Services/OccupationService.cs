using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.AllDtos.UpdateDtos;
using SimpleAPI.Data;
using SimpleAPI.Dtos.CreateDtos;
using SimpleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Services
{
    public class OccupationService : IOccupationService
    {
        private readonly ApplicationDbContext _db;
        public OccupationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<OccupationDto> GetAllOccupations()
        {
            var occupationList = _db.Occupations.Include(r => r.People).ToList();

            if (occupationList == null)
                return null;

            var occupationDtoList = occupationList.Select(r => new OccupationDto()
            {
                Id = r.Id,
                Name = r.Name,
                People = r.People
            });

            return occupationDtoList;
        }

        public OccupationDto GetOccupationById(int id)
        {
            var occupation = _db.Occupations.Include(r => r.People).FirstOrDefault(r => r.Id == id);

            if (occupation == null)
                return null;

            var occupationDto = new OccupationDto()
            {
                Id = occupation.Id,
                Name = occupation.Name,
                People = occupation.People
            };

            return occupationDto;
        }

        public int AddOccupationToDatabase(CreateOccupationDto occupationDto)
        {
            var occupation = new Occupation()
            {
                Name = occupationDto.Name
            };

            _db.Add(occupation);
            _db.SaveChanges();

            return occupation.Id;
        }

        public int? UpdateOccupation(int id, UpdateOccupationDto updateOccupationDto)
        {
            var occupation = _db.Occupations.FirstOrDefault(r => r.Id == id);

            if (occupation == null)
                return null;

            occupation.Name = updateOccupationDto.Name;

            _db.SaveChanges();

            return occupation.Id;    
        }

        public bool DeleteOccupation(int id)
        {
            var occupation = _db.Occupations.FirstOrDefault(r => r.Id == id);

            if (occupation == null)
                return false;

            _db.Remove(occupation);
            _db.SaveChanges();

            return true;
        }
    }
}
