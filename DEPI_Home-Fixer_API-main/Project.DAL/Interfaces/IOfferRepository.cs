using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{

    public interface IOfferRepository : IGenericRepository<Offer>
    {
        public IEnumerable<Offer> GetAcceptedOffers(int techId);
        public IEnumerable<Offer> GetOffersByRequestId(int requestId);

        public IEnumerable<Offer> GetAcceptedOffersByRequestId(int requestId);

        public IEnumerable<Offer> GetPageByRequestID(int requestId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false);

        public IEnumerable<Offer> GetPageAcceptedOffersForClient(int clientId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false);
        public IEnumerable<Offer> GetPageAcceptedOffersForTechnician(int technicianId, int pageSize, int pageNo, out int? count, bool needTotalCount, bool sortByPrice = false);

    }
}


