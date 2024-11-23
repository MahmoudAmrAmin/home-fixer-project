namespace HomeService_front.Models.Paging
{
    public class PageData<T>
    {
        public ICollection<T> Data { get; set; }
        public int? TotalRecords { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
