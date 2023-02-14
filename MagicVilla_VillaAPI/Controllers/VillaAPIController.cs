
//using MagicVilla_VillaAPI.CustomeLogging;
using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model;
using MagicVilla_VillaAPI.Model.DTO;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/APIController")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        //private readonly ILogging _logger;
        //public VillaAPIController(/*ILogging logger*/)
        // {
        //     //_logger = logger;
        // }
        //private readonly ApplicationDbContext _db;

        protected APIResponse _response;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaAPIController(IVillaRepository dbVilla, IMapper Mapper)
        {
            _dbVilla = dbVilla;
            _mapper = Mapper;
            this._response = new APIResponse();
        }

        //GET VILLA

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> Getvillas()
        {
            ///*_logger.Log*/("Getting all villas",""); 
            //return Ok(VillaStore.VillaList);  
            try
            {

                IEnumerable<Villa> villaList = await _dbVilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }

        //GETPARTICULAR VILLA

        [HttpGet("{id:int}", Name = "GetVilla")]
        //[ProducesResponseType(200,  Type=typeof( VillaDTO ))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //(* Both are Response key are same)
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<APIResponse>> GetVill(int id)
        {
            try
            {
                if (id == 0)
                {
					//_logger.Log("Get villa Error with Id = " +id,"error")
					_response.StatusCode = HttpStatusCode.BadRequest;
					return BadRequest(_response);
                }
                //var villa = VillaStore.VillaList.FirstOrDefault(get => get.Id == id)
                var villa = await _dbVilla.GetAsync(get => get.Id == id);

                if (villa == null)
                {
					_response.StatusCode = HttpStatusCode.BadRequest;
					return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }

            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }

        //POST VILLA

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO createDTO)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return BadRequest(ModelState);
                //}
                //this condition is used to check existing data if we put same data is throw error
                if (await _dbVilla.GetAsync(get => get.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Name", "Villa already exist");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
				{
					_response.StatusCode = HttpStatusCode.BadRequest;

					return BadRequest(createDTO);
                }
                //if(villaDTO.Id > 0)
                //{
                //    return StatusCode(StatusCodes.Status500InternalServerError);
                //}
                Villa villa = _mapper.Map<Villa>(createDTO);
                //both or same
                //Villa model = new Villa()
                //{
                //    Amenity = createDTO.Amenity,
                //    Details = createDTO.Details,
                //    //Id=villaDTO.Id,
                //    ImageUrl= createDTO.ImageUrl,
                //    Name= createDTO.Name,
                //    Occupancy= createDTO.Occupancy,
                //    Rate= createDTO.Rate,
                //    Sqft= createDTO.Sqft
                //};
                //await _db.SaveChangesAsync();

                //villaDTO.Id = VillaStore.VillaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
                //VillaStore.VillaList.Add(villaDTO);

                await _dbVilla.CreateAsync(villa);
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("Getvilla", new { id = villa.Id }, _response);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }

        //DELETE VILLA

        [HttpDelete("{id=string}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
                var villa = await _dbVilla.GetAsync(u => u.Id == id);
                //Console.WriteLine(villa);
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                //VillaStore.VillaList.Remove(villa);
                // _db.VillaDb.Remove(villa);
                //await _db.SaveChangesAsync();

                await _dbVilla.RemoveAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
                //return NoContent();
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }

        //UPDATE VILLA

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVila(int id, [FromBody] VillaUpdateDTO UpdateDTO)
        {
            try
            {
                if (UpdateDTO == null || id != UpdateDTO.Id)
                {
                    return BadRequest();
                }
                //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
                //villa.Name = villaDTO.Name;
                //villa.Sqft = villaDTO.Sqft;
                //villa.Occupation = villaDTO.Occupation;

                Villa model = _mapper.Map<Villa>(UpdateDTO);

                //both or same

                //Villa model = new Villa()
                //{
                //    Amenity = UpdateDTO.Amenity,
                //    Details = UpdateDTO.Details,
                //    Id = UpdateDTO.Id,
                //    ImageUrl = UpdateDTO.ImageUrl,
                //    Name = UpdateDTO.Name,
                //    Occupancy = UpdateDTO.Occupancy,
                //    Rate = UpdateDTO.Rate,
                //    Sqft = UpdateDTO.Sqft
                //};
                //await _db.SaveChangesAsync();

                await _dbVilla.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);

                //return NoContent();
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { e.ToString() };
            }
            return _response;
        }

        //PATCH VILLA

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> PatchDTO)
        {
            if (id == 0 || PatchDTO == null)
            {
                return BadRequest();
            }
            //var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
            var villa = await _dbVilla.GetAsync(get => get.Id == id, Tracked: false);

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            //both or same

            //VillaUpdateDTO villaDTO = new VillaUpdateDTO()
            //{
            //    Amenity = villa.Amenity,
            //    Details = villa.Details,
            //    Id = villa.Id,
            //    ImageUrl = villa.ImageUrl,
            //    Name = villa.Name,
            //    Occupancy = villa.Occupancy,
            //    Rate = villa.Rate,
            //    Sqft = villa.Sqft
            //};

            if (villa == null)
            {
                return BadRequest();
            }

            PatchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = _mapper.Map<Villa>(villaDTO);

            //Villa model = new Villa()
            //{
            //    Amenity = partialDTO.Amenity,
            //    Details = partialDTO.Details,
            //    Id = partialDTO.Id,
            //    ImageUrl = partialDTO.ImageUrl,
            //    Name = partialDTO.Name,
            //    Occupancy = partialDTO.Occupancy,
            //    Rate = partialDTO.Rate,
            //    Sqft = partialDTO.Sqft
            //};

            //_db.VillaDb.Update(model);
           await _dbVilla.UpdateAsync(model);
            //await _db.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

    }
}
