using Project.DAL.Entities;
using Project.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceContracts
{

    public interface IPhotoService
    {

        public IEnumerable<Photo> GetAll();
        public Photo GetById(int id);

        public void Add(Photo photo);
        public void Delete(int id);
        public void Update(Photo photo);
    }
}

