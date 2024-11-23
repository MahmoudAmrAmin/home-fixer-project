using HomeService_front.Models.City;
using HomeService_front.Models.Client;
using HomeService_front.Models.Specialization;
using HomeService_front.Models.Technician;

namespace HomeService_front.Models.Admin
{
    public class AdminIndexVM
    {
        public List<CityVM> Cites { get; set; }

        public int CitesCount { get; set; }

        public List<ClientVM> Clients { get; set; }
        public int ClientsCount { get; set; } 
        
        public List<TechnicianVM> Technicians { get; set; }
        public int TechniciansCount { get; set; } 
        
        public List<SpecializationVM> Specializations { get; set; }
        public int SpecializationCount { get; set; }
    }
}
