using Microsoft.AspNetCore.Identity;
using Project.BLL.DTOs.City;
using Project.BLL.DTOs.Offer;
using Project.BLL.DTOs.Pagination;
using Project.BLL.DTOs.Technician;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class TechnicianService : ITechnicianService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TechnicianService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddTechnicianDto dto)
        {
            Technician technician = new Technician
            {
                ApplicationUserId = dto.ApplicationUserId,
                SpecializationID = dto.SpecializationID
            };

            _unitOfWork.TechnicianRepository.AddEntity(technician);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.CityRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public PageData<TechnicianDto> GetPage(int? specializationId, int pageSize, int pageNo, bool needTotalCount, bool orderByWorksDesc = false)
        {
            int? totalCount;
            var techs = _unitOfWork.TechnicianRepository.GetPage(specializationId, pageSize, pageNo, out totalCount, needTotalCount, orderByWorksDesc); ;

            var data = techs.Select(t =>
                new TechnicianDto
                {
                    Email = t.Person.Email,
                    FinishedWord = t.FinishedWorks,
                    Id = t.TechnicianId,
                    FirstName = t.Person.FirstName,
                    LastName = t.Person.LastName,
                    SpecializationID = t.SpecializationID,
                    PhoneNumber = t.Person.PhoneNumber,
                    SpecializationName = t.Specialization.SpecializationName,
                    Username = t.Person.UserName,
                }).ToList();

            return new PageData<TechnicianDto>
            {
                Data = data,
                PageNumber = pageNo,
                PageSize = pageSize,
                TotalRecords = totalCount,
            };

        }

        public async Task<List<TechnicianDto>> GetAll()
        {
            var Technicians = await _unitOfWork.TechnicianRepository.GetAllAsync();

            return Technicians.Select(tech => new TechnicianDto
            {
                Email = tech.Person.Email,
                FinishedWord = tech.FinishedWorks,
                Id = tech.TechnicianId,
                FirstName = tech.Person.FirstName,
                LastName = tech.Person.LastName,
                SpecializationID = tech.SpecializationID,
                PhoneNumber = tech.Person.PhoneNumber,
                SpecializationName = tech.Specialization.SpecializationName,
                Username = tech.Person.UserName,
            }).ToList();
        }

        public async Task<List<TechnicianDto>> GetSpecificNumOfRecords(int num)
        {
            var Technicians = await _unitOfWork.TechnicianRepository.GetSpecificNumOfRecords(num);

            return Technicians.Select(tech => new TechnicianDto
            {
                Email = tech.Person.Email,
                FinishedWord = tech.FinishedWorks,
                Id = tech.TechnicianId,
                FirstName = tech.Person.FirstName,
                LastName = tech.Person.LastName,
                SpecializationID = tech.SpecializationID,
                PhoneNumber = tech.Person.PhoneNumber,
                SpecializationName = tech.Specialization.SpecializationName,
                Username = tech.Person.UserName,
            }).ToList();
        }

        public async Task<TechnicianDto> GetById(string id)
        {
            var tech = await _unitOfWork.TechnicianRepository.GetCurrentUser(id);

            return new TechnicianDto
            {
                Email = tech.Person.Email,
                FinishedWord = tech.FinishedWorks,
                Id = tech.TechnicianId,
                FirstName = tech.Person.FirstName,
                LastName = tech.Person.LastName,
                SpecializationID = tech.SpecializationID,
                PhoneNumber = tech.Person.PhoneNumber,
                SpecializationName = tech.Specialization.SpecializationName,
                Username = tech.Person.UserName,
            };
        }

        public IEnumerable<AcceptedOfferDto> GetAcceptedOffers(int techId)
        {
            var offers = _unitOfWork.OfferRepository.GetAcceptedOffers(techId);

            return offers.Select(offer => new AcceptedOfferDto
            {
                OfferID = offer.OfferID,
                Price = offer.Price,
                OfferDetails = offer.OfferDetails,
                //UserFullName = offer
            });
        }

        public void Update(EditCityDto cityDto)
        {
            var city = _unitOfWork.CityRepository.GetEntityById(cityDto.Id);

            cityDto.Name = city.Name;

            _unitOfWork.CityRepository.UpdateEntity(city);
            _unitOfWork.Save();
        }



    }
}
