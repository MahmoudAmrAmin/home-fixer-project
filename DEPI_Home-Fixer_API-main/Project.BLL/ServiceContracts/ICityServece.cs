using Project.BLL.DTOs.City;

namespace Project.BLL.ServiceContracts
{
    public interface ICityServece
    {
        public IEnumerable<CityDto> GetAll();
        public CityDto GetById(int id);

        public void Add(AddCityDto cityDto);
        public void Delete(int id);
        public void Update(EditCityDto cityDto);
        public Task<IEnumerable<CityDto>> GetSpecificNumOfRecords(int num);




    }
}
