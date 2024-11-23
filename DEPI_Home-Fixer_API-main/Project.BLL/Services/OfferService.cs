using Project.BLL.DTOs.Offer;
using Project.BLL.DTOs.Pagination;
using Project.BLL.ServiceContracts;
using Project.DAL.Entities;
using Project.DAL.UnitOfWork;

namespace Project.BLL.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(AddOfferDto offerDto)
        {
            _unitOfWork.OfferRepository.AddEntity(new Offer
            {
                OfferDetails = offerDto.OfferDetails,
                Price = offerDto.Price,
                TechnicianID = offerDto.TechnicianID,
                RequestID = offerDto.RequestID,
                VisitDate = offerDto.VisitDate,
            });
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.OfferRepository.DeleteEntity(id);
            _unitOfWork.Save();
        }

        public IEnumerable<OfferDto> GetAll()
        {
            var offers = _unitOfWork.OfferRepository.GetAll();

            return offers.Select(offer => new OfferDto
            {
                OfferID = offer.OfferID,
                OfferStatus = offer.OfferStatus,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                TechnicianFullName = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName
            });
        }

        public OfferDto GetById(int id)
        {
            var offer = _unitOfWork.OfferRepository.GetEntityById(id);
            return new OfferDto
            {
                OfferID = offer.OfferID,
                OfferStatus = offer.OfferStatus,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                TechnicianFullName = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName
            };
        }

        public IEnumerable<OfferDto> GetOffersByRequestId(int requestId)
        {
            var offers = _unitOfWork.OfferRepository.GetOffersByRequestId(requestId);

            return offers.Select(offer => new OfferDto
            {
                OfferID = offer.OfferID,
                OfferStatus = offer.OfferStatus,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                TechnicianFullName = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName
            });
        }

        public void Update(EditOfferDto dto)
        {
            var offer = _unitOfWork.OfferRepository.GetEntityById(dto.Id);

            if (offer != null)
            {
                offer.Price = dto.Price;
                offer.OfferDetails = dto.OfferDetails;
                offer.VisitDate = dto.VisitDate;
                _unitOfWork.OfferRepository.UpdateEntity(offer);

                _unitOfWork.Save();
            }
        }

        public void AcceptOffer(int offerId)
        {
            var offer = _unitOfWork.OfferRepository.GetEntityById(offerId);

            if (offer != null)
            {
                // accept the offer
                offer.OfferStatus = OfferStatus.Accepted;
                _unitOfWork.OfferRepository.UpdateEntity(offer);

                var request = _unitOfWork.RequestRepository.GetEntityById(offer.RequestID);
                if (request != null)
                {
                    // change the status to not appears for the Technician
                    request.Status = RequestStatus.InProgress;
                    _unitOfWork.RequestRepository.UpdateEntity(request);
                }

                var technician = _unitOfWork.TechnicianRepository.GetEntityById(offer.TechnicianID);
                if (technician != null)
                {
                    technician.FinishedWorks++;
                    _unitOfWork.TechnicianRepository.UpdateEntity(technician);
                }
                _unitOfWork.Save();
            }
        }

        public void RejectOffer(int offerId)
        {
            var offer = _unitOfWork.OfferRepository.GetEntityById(offerId);

            if (offer != null)
            {
                // reject the offer
                offer.OfferStatus = OfferStatus.Rejected;
                _unitOfWork.OfferRepository.UpdateEntity(offer);
                _unitOfWork.Save();
            }
        }

        public IEnumerable<OfferDto> GetAcceptedOffersByRequestId(int requestId)
        {
            var offers = _unitOfWork.OfferRepository.GetAcceptedOffersByRequestId(requestId);

            return offers.Select(offer => new OfferDto
            {
                OfferID = offer.OfferID,
                OfferStatus = offer.OfferStatus,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                TechnicianFullName = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName
            });
        }


        public PageData<OfferDto> GetpageByRequestId(int requestId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false)
        {
            int? totalCount;
            var offers = _unitOfWork.OfferRepository.GetPageByRequestID(requestId, pageSize, pageNo, out totalCount, needCount, sortByPrice);

            var data = offers.Select(offer => new OfferDto
            {
                OfferID = offer.OfferID,
                OfferStatus = offer.OfferStatus,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                TechnicianFullName = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName,
                TechnicianTotalWorks = offer.Technician.FinishedWorks,
            }).ToList();

            return new PageData<OfferDto>
            {
                Data = data,
                TotalRecords = totalCount,
                PageNumber = pageNo,
                PageSize = pageSize,
            };
        }
        
        public PageData<AcceptedOfferDto> GetPageAcceptedOffersForClient(int clientId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false)
        {
            int? totalCount;
            var offers = _unitOfWork.OfferRepository.GetPageAcceptedOffersForClient(clientId, pageSize, pageNo, out totalCount, needCount, sortByPrice);

            var data = offers.Select(offer => new AcceptedOfferDto
            {
                OfferID = offer.OfferID,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                Name = offer.Technician.Person.FirstName + " " + offer.Technician.Person.LastName,
                PhoneNumber = offer.Technician.Person.PhoneNumber,
            }).ToList();

            return new PageData<AcceptedOfferDto>
            {
                Data = data,
                TotalRecords = totalCount,
                PageNumber = pageNo,
                PageSize = pageSize,
            };
        }

        public PageData<AcceptedOfferDto> GetPageAcceptedOffersForTechnician(int technicianId, int pageSize, int pageNo, bool needCount, bool sortByPrice = false)
        {
            int? totalCount;
            var offers = _unitOfWork.OfferRepository.GetPageAcceptedOffersForTechnician(technicianId, pageSize, pageNo, out totalCount, needCount, sortByPrice);

            var data = offers.Select(offer => new AcceptedOfferDto
            {
                OfferID = offer.OfferID,
                OfferDetails = offer.OfferDetails,
                VisitDate = offer.VisitDate,
                Price = offer.Price,
                Name = offer.Request.User.Person.FirstName + " " + offer.Request.User.Person.LastName,
                PhoneNumber = offer.Request.User.Person.PhoneNumber,
            }).ToList();

            return new PageData<AcceptedOfferDto>
            {
                Data = data,
                TotalRecords = totalCount,
                PageNumber = pageNo,
                PageSize = pageSize,
            };
        }


    }
}

