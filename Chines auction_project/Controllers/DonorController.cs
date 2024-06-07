using AutoMapper;
using Chines_auction_project.BLL;
using Chines_auction_project.Modells;
using Chines_auction_project.Modells.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Chines_auction_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService donorService;
        private readonly IMapper mapper;

        public DonorController(IDonorService donorService, IMapper mapper)
        {
            this.donorService = donorService;
            this.mapper = mapper;
        }
        [HttpGet("GetDonors")]
        public async Task<ActionResult<Donor>> GetDonors()
        {
            var Donors = await donorService.GetDonors();
            return Donors==null?NotFound(): Ok(Donors);
        }
        [HttpPost("AddDonor")]

        public async Task<ActionResult<Donor>> AddDonor(DonorDto donor)
        {
            var d = mapper.Map<Donor>(donor);
            return Created($"http://localhost:3000/Customer/{d.Id}", await donorService.AddDonor(d));
        }
        [HttpDelete("RemoveDonor/{id}")]
        public async Task<ActionResult<Donor>> RemoveDonor(int id)
        {
            //var d = mapper.Map<Donor>(donor);
            return id == null ? NotFound() : Ok(await donorService.RemoveDonor(id));
        }
        [HttpPut("UpdateDonor/{id}")]
        public async Task<ActionResult<Donor>> UpdateDonor(DonorDto donor,int id)
        {
            var d = mapper.Map<Donor>(donor);
            return d == null ? NotFound() : Ok(await donorService.UpdateDonor(d,id));
        }
        //שם/ מייל/  מתנה
        [HttpGet("SearchByName/{Name}")]

        public async Task<ActionResult<Donor>> SearchByName(string Name)
        {
            return Name == null ? NotFound() : Ok(await donorService.SearchByName(Name));
        }
        [HttpGet("SearchByEmail/{email}")]

        public async Task<ActionResult<Donor>> SearchByEmail(string email)
        {
            return email == null ? NotFound() : Ok(await donorService.SearchByEmail(email));
        }
        //[HttpGet("SearchByPresent")]

        //public ActionResult<Donor> SearchByPresent(string present)
        //{
        //    return present == null ? NotFound() : Ok(donorService.SearchByPresent(present));
        //}


    }
}
