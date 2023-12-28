using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application.ViewModel;
using WebApplication1.Domain.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController>  logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeModel modelo)
        {
            var filePath = Path.Combine("Storage", modelo.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            modelo.Photo.CopyTo(fileStream);
            var employee = new Employee(modelo.Name, modelo.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok(employee);
        }

        
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantiy)
        {
            _logger.Log(LogLevel.Error, "teve um erro");

            var todos = _employeeRepository.Get(pageNumber, pageQuantiy);

            _logger.LogInformation("SegundoErro");

            return Ok(todos);
        }

        [Authorize]
        [HttpGet]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.PegaUnico(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataBytes, "image/png");
        }
    }
}
