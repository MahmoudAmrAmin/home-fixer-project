using Project.BLL.DTOs.Specialization;

namespace Project.BLL.ServiceContracts
{
    public interface ISpecialization
    {
        void Add(AddSpecializationDto specializationDto);
        void Delete(int id);
        public IEnumerable<SpecializationDto> GetAll();
        SpecializationDto GetById(int id);
        void Update(EditSpecializationDto specializationDto);

        public Task<IEnumerable<SpecializationDto>> GetSpecificNumOfRecords(int num);

    }
}
