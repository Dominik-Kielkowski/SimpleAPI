using Microsoft.AspNetCore.Mvc;
using SimpleAPI.AllDtos.Dtos;
using SimpleAPI.AllDtos.UpdateDtos;
using SimpleAPI.Dtos.CreateDtos;

namespace SimpleAPI.Services
{
    public interface IOccupationService
    {
        IEnumerable<OccupationDto> GetAllOccupations();
        OccupationDto GetOccupationById(int id);
        int AddOccupationToDatabase(CreateOccupationDto occupationDto);
        int UpdateOccupation(int id, UpdateOccupationDto updateOccupationDto);
        void DeleteOccupation(int id);
    }
}