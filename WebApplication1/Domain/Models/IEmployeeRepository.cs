namespace WebApplication1.Domain.Models
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> Get(int pageNumber, int pageQuantity);

        Employee? PegaUnico(int id);
    }
}
