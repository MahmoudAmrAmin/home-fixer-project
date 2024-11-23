using Microsoft.EntityFrameworkCore;
using Project.BLL.Repositories;
using Project.DAL.Context;
using Project.DAL.Entities;
using Project.DAL.Interfaces;

namespace Project.DAL.Repositories
{

    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(DEPIProjectContext context) : base(context)
        {
        }

        public override IEnumerable<Offer> GetAll()
        {
            return _dbSet
                .Include(offer => offer.Technician.Person);
        }

        public override Offer GetEntityById(int id)
        {
            return _dbSet
                .Include(offer => offer.Technician.Person)
                .FirstOrDefault(offer => offer.OfferID == id)
                ;
        }

        public IEnumerable<Offer> GetAcceptedOffers(int techId)
        {
            return _dbSet
                .Where(offer => offer.TechnicianID == techId &&
                                offer.OfferStatus == OfferStatus.Accepted
                );
        }

        public IEnumerable<Offer> GetOffersByRequestId(int requestId)
        {
            return _dbSet
                .Where(offer => offer.RequestID == requestId && offer.OfferStatus == OfferStatus.Pending)
                .Include(offer => offer.Technician.Person);
        }

        public IEnumerable<Offer> GetAcceptedOffersByRequestId(int requestId)
        {
            return _dbSet.Where(offer => offer.RequestID == requestId && offer.OfferStatus == OfferStatus.Accepted)
                .Include(offer => offer.Technician.Person);

        }

        public IEnumerable<Offer> GetPageByRequestID(int requestId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false)
        {
            var query = _dbSet
               .Include(offer => offer.Technician.Person )
               .Where(offer => offer.RequestID == requestId && offer.OfferStatus == OfferStatus.Pending);

            if (sortByPrice)
                query.OrderByDescending(offer => offer.Price);
            else
                query.OrderBy(offer => offer.Price);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Offer> GetPageAcceptedOffersForClient(int clientId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false)
        {
            var query = _dbSet
               .Include(offer => offer.Technician.Person)
               .Where(offer => offer.Request.UserId == clientId && offer.OfferStatus == OfferStatus.Accepted);

            if (sortByPrice)
                query.OrderByDescending(offer => offer.Price);
            else
                query.OrderBy(offer => offer.Price);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Offer> GetPageAcceptedOffersForTechnician(int technicianId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false)
        {
            var query = _dbSet
               .Include(offer => offer.Request.User.Person)
               .Where(offer => offer.TechnicianID == technicianId && offer.OfferStatus == OfferStatus.Accepted);

            if (sortByPrice)
                query.OrderByDescending(offer => offer.Price);
            else
                query.OrderBy(offer => offer.Price);

            count = needTotalCount ? query.Count() : null;
            return query.Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

    }
}
