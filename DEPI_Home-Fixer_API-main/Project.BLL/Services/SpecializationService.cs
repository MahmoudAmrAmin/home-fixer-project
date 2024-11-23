using Project.BLL.DTOs.Specialization;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class SpecializationService : ISpecialization
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecializationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddSpecializationDto categoryDto)
        {
            var specialization = new Specialization
            {
                SpecializationName = categoryDto.SpecializationName,
            };

            _unitOfWork.SpecializationRepository.AddEntity(specialization);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.SpecializationRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<SpecializationDto> GetAll()
        {
            var categories = _unitOfWork.SpecializationRepository.GetAll();

            return categories.Select(c => new SpecializationDto
            {
                SpecializationName = c.SpecializationName,
                SpecializationID = c.SpecializationId
            });
        }

        public async Task<IEnumerable<SpecializationDto>> GetSpecificNumOfRecords(int num)
        {
            var specializations = await _unitOfWork.SpecializationRepository.GetSpecificNumOfRecords(num);

            return specializations.Select(c => new SpecializationDto
            {
                SpecializationName = c.SpecializationName,
                SpecializationID = c.SpecializationId
            });
        }

        public SpecializationDto GetById(int id)
        {
            var specialization = _unitOfWork.SpecializationRepository.GetEntityById(id);
            return new SpecializationDto
            {
                SpecializationName = specialization.SpecializationName,
                SpecializationID = specialization.SpecializationId
            };
        }

        public void Update(EditSpecializationDto specializationDto)
        {
            var specialization = _unitOfWork.SpecializationRepository.GetEntityById(specializationDto.SpecializationID);

            specialization.SpecializationName = specializationDto.SpecializationName;

            _unitOfWork.SpecializationRepository.UpdateEntity(specialization);
            _unitOfWork.Save();
        }
    }
}
