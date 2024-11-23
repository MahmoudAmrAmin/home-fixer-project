using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{


    public class PhotoService : IPhotoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Photo photo)
        {
            _unitOfWork.PhotoRepository.AddEntity(photo);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.PhotoRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public void DeleteAll(List<Photo> photos)
        {
            _unitOfWork.PhotoRepository.DeleteAll(photos);
            _unitOfWork.Save();
        }

        public IEnumerable<Photo> GetAll()
        {
            return _unitOfWork.PhotoRepository.GetAll();
        }

        public Photo GetById(int id)
        {
            return _unitOfWork.PhotoRepository.GetEntityById(id);
        }

        public void Update(Photo photo)
        {
            _unitOfWork.PhotoRepository.UpdateEntity(photo);
            _unitOfWork.Save();
        }
    }
}

