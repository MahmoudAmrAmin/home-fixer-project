using Microsoft.IdentityModel.Tokens;
using Project.DAL.Context;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DEPIProjectContext _context;
        public IRequestRepository RequestRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public ISpecializationRepository SpecializationRepository { get; }
        public ICityRepository CityRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
        public ITechnicianRepository TechnicianRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            DEPIProjectContext context,

            IRequestRepository requestRepository,
            IOfferRepository offerRepository,
            ICityRepository cityRepository,
            ISpecializationRepository specializationRepository,
           IPhotoRepository photoRepository,
           ITechnicianRepository technicianRepository,
           IUserRepository userRepository

            )
        {
            _context = context;

            RequestRepository = requestRepository;
            OfferRepository = offerRepository;
            CityRepository = cityRepository;
            SpecializationRepository = specializationRepository;
            PhotoRepository = photoRepository;
            TechnicianRepository = technicianRepository;
            UserRepository = userRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
