using Project.BLL.DTOs.Pagination;
using Project.BLL.DTOs.Photo;
using Project.BLL.DTOs.Request;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddRequestDto requestDto)
        {
            var request = new Request
            {
                CityId = requestDto.CityId,
                SpecializationId = requestDto.SpecializationId,
                Description = requestDto.Description,
                UserId = requestDto.UserId,
            };

            request.Photos = requestDto.PhotosUrl.Select(photoUrl => new Photo
            {
                PhotoUrl = photoUrl,

            }).ToList();

            _unitOfWork.RequestRepository.AddEntity(request);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var request = _unitOfWork.RequestRepository.GetEntityById(id);

            if (request != null)
            {
                var photos = request.Photos;
                if (photos != null)
                    _unitOfWork.PhotoRepository.DeleteAll(photos);

                _unitOfWork.RequestRepository.DeleteEntity(id);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<RequestDto> GetAll()
        {
            var requests = _unitOfWork.RequestRepository.GetAll();
            return requests.Select(request => new RequestDto
            {
                Id = request.Id,
                UserFullName = request.User.Person.FirstName + " " + request.User.Person.LastName,
                SpecializationName = request.Specialization.SpecializationName,
                Description = request.Description,
                CityName = request.City.Name,
                RequestedAt = request.AddedAt,
                Status = request.Status.ToString(),

                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList(),
            });
        }

        public PageData<RequestDto> Getpage(int? cityId, int specializationId, int pageSize, int pageNo, bool needCount, bool sortByCity = false)
        {
            int? totalCount;
            var requests = _unitOfWork.RequestRepository.GetPage(cityId, specializationId, pageSize, pageNo, out totalCount, needCount, sortByCity);

            var data = requests.Select(request => new RequestDto
            {
                Id = request.Id,
                UserFullName = request.User.Person.FirstName + " " + request.User.Person.LastName,
                SpecializationName = request.Specialization.SpecializationName,
                Description = request.Description,
                CityName = request.City.Name,
                RequestedAt = request.AddedAt,
                Status = request.Status.ToString(),

                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList()
            }).ToList();

            return new PageData<RequestDto>
            {
                Data = data,
                TotalRecords = totalCount,
                PageNumber = pageNo,
                PageSize = pageSize,
            };
        }

        public PageData<RequestDto> GetpageByUserId(int userId, int pageSize, int pageNo, bool needCount, bool sortByCity = false)
        {
            int? totalCount;
            var requests = _unitOfWork.RequestRepository.GetPageByUserId(userId, pageSize, pageNo, out totalCount, needCount, sortByCity);

            var data = requests.Select(request => new RequestDto
            {
                Id = request.Id,
                UserFullName = request.User.Person.FirstName + " " + request.User.Person.LastName,
                SpecializationName = request.Specialization.SpecializationName,
                Description = request.Description,
                CityName = request.City.Name,
                RequestedAt = request.AddedAt,
                Status = request.Status.ToString(),

                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList()
            }).ToList();

            return new PageData<RequestDto>
            {
                Data = data,
                TotalRecords = totalCount,
                PageNumber = pageNo,
                PageSize = pageSize,
            };
        }


        public IEnumerable<RequestDto> GetAllBySpecializationId(int specializationI)
        {
            var requests = _unitOfWork.RequestRepository.GetAllBySpecializationId(specializationI);

            return requests.Select(request => new RequestDto
            {
                Id = request.Id,
                UserFullName = request.User.Person.FirstName + " " + request.User.Person.LastName,
                SpecializationName = request.Specialization.SpecializationName,
                Description = request.Description,
                CityName = request.City.Name,
                RequestedAt = request.AddedAt,
                Status = request.Status.ToString(),

                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList(),
            });
        }

        public RequestDto GetById(int id)
        {
            var request = _unitOfWork.RequestRepository.GetEntityById(id);
            return new RequestDto
            {
                Id = request.Id,
                UserFullName = request.User.Person.FirstName + " " + request.User.Person.LastName,
                SpecializationName = request.Specialization.SpecializationName,
                Description = request.Description,
                CityName = request.City.Name,
                RequestedAt = request.AddedAt,
                Status = request.Status.ToString(),

                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList(),
            };
        }

        public RequestDtoForEdit GetByIdForEdit(int id)
        {
            var request = _unitOfWork.RequestRepository.GetEntityById(id);
            return new RequestDtoForEdit
            {
                RequestId = request.Id,
                CityId = request.CityId,
                SpecializationID=request.SpecializationId,
                Description = request.Description,
                Photos = request.Photos.Select(p => new PhotoDto
                {
                    Id = p.PhotoID,
                    PhotoUrl = p.PhotoUrl,
                }).ToList(),
            };
        }

        public void Update(EditRequestDto dto)
        {
            var request = _unitOfWork.RequestRepository.GetEntityById(dto.RequestId);

            if (request != null)
            {
                request.Description = dto.Description;
                request.CityId = dto.CityId;
                request.SpecializationId = dto.SpecializationId;

            }
            _unitOfWork.Save();
        }

       
    }

}
