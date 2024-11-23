using HomeService_front.Models.Paging;

namespace HomeService_front.Models.Request
{
    public class RequestIndexVM
    {
      public  PageData<RequestVM> Data { get; set; }
      public  int SpecializationId { get; set; }
      public string SpecializationName { get; set; }
    }
}
