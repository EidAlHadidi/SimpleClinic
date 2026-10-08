using BL.Interfaces;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllPeople")]
        public ActionResult<IEnumerable<Person>> GetAllPeople()
        {
            return Ok(_unitOfWork.People.GetAll());
        }
    }
}
