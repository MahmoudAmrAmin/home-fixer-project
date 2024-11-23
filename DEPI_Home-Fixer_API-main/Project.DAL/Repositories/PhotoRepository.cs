using Microsoft.Identity.Client;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{

    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DEPIProjectContext context) : base(context)
        {


        }

        public void DeleteAll(List<Photo> photos)
        {
            _dbSet.RemoveRange(photos);
        }
    }
}
