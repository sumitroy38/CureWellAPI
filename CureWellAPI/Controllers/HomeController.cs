using Microsoft.AspNetCore.Mvc;
using CureWellAPI.Models;

namespace CureWellAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        CureWellRepository repo = new CureWellRepository();

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var result = repo.GetAllDoctors();
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetSpecializations()
        {
            var result = repo.GetAllSpecializations();
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAllSurgeryTypeForToday()
        {
            var result = repo.GetAllSurgeryTypeForToday();
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] Doctor dObj)
        {
            var result = repo.AddDoctor(dObj);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateDoctorDetails([FromBody] Doctor dObj)
        {
            var result = repo.UpdateDoctorDetails(dObj);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateSurgery([FromBody] Surgery sObj)
        {
            var result = repo.UpdateSurgery(sObj);
            return Ok(result);
        }

        [HttpDelete("{doctorID}")]
        public IActionResult DeleteDoctor(int doctorID)
        {
            var result = repo.DeleteDoctor(doctorID);
            return Ok(result);
        }
    }
}