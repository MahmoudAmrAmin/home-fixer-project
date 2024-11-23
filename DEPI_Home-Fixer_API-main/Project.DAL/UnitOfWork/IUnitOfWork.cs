using Project.DAL.Interfaces;

namespace Project.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRequestRepository RequestRepository { get; }
        public IOfferRepository OfferRepository { get; }
        public ISpecializationRepository SpecializationRepository { get; }
        public ICityRepository CityRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
        public ITechnicianRepository TechnicianRepository { get; }
        public IUserRepository UserRepository { get; }

        public void Save();
    }
}
