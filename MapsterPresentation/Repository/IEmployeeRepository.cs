using MapsterPresentation.Models;

namespace MapsterPresentation.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
    }
}
