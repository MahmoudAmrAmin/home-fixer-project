using Project.BLL.DTOs.City;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class CityService : ICityServece
    {
        private IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddCityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
            };
            _unitOfWork.CityRepository.AddEntity(city);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.CityRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<CityDto> GetAll()
        {
            var Cities = _unitOfWork.CityRepository.GetAll();

            return Cities.Select(city => new CityDto
            {
                CityId = city.CityId,
                CityName = city.Name,
            });
        } 
        

        public async Task <IEnumerable<CityDto>> GetSpecificNumOfRecords(int num)
        {
            var Cities =await _unitOfWork.CityRepository.GetSpecificNumOfRecords(num);

            return Cities.Select(city => new CityDto
            {
                CityId = city.CityId,
                CityName = city.Name,
            });
        }



        public CityDto GetById(int id)
        {
            var city = _unitOfWork.CityRepository.GetEntityById(id);

            return new CityDto
            {
                CityId = city.CityId,
                CityName = city.Name
            };
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
