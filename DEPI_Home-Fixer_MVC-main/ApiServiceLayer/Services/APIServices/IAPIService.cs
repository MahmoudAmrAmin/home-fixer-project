namespace ApiServiceLayer.Services.APIServices
{
    public interface IAPIService
    {

        Task<T> GetAsync<T>(string url);
        public Task<IEnumerable<T>> GetAllAsync<T>(string endPoint);

        Task<T> PostAsync<T>(string url, object data);
        Task<T> PutAsync<T>(string url, object data);  
        Task DeleteAsync(string url);                 
        public Task<T> GetPageAsync<T>(string endPoint);
        public Task PutWithOutBodyAsync(string endPoint, object data);

        public Task PostWithOutBodyAsync(string endPoint, object data);

        public Task PutWithOutBodyAsync(string endPoint);
    }
}
