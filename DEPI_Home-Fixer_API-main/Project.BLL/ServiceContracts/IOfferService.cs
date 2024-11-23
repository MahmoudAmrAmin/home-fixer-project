using Project.BLL.DTOs.Offer;
using Project.BLL.DTOs.Pagination;

namespace Project.BLL.ServiceContracts
{

    public interface IOfferService
    {
        public IEnumerable<OfferDto> GetAll();
        public IEnumerable<OfferDto> GetOffersByRequestId(int requestId);
        public OfferDto GetById(int id);

        public void Add(AddOfferDto offer);
        public void Delete(int id);
        public void Update(EditOfferDto offer);

        public void RejectOffer(int offerId);

        public void AcceptOffer(int offerId);

        public IEnumerable<OfferDto> GetAcceptedOffersByRequestId(int requestId);
        public PageData<OfferDto> GetpageByRequestId(int requestId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false);
        public PageData<AcceptedOfferDto> GetPageAcceptedOffersForClient(int clientId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false);
        public PageData<AcceptedOfferDto> GetPageAcceptedOffersForTechnician(int technicianId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false);

    }
}

