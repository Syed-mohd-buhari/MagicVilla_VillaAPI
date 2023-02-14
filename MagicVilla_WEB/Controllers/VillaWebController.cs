﻿using AutoMapper;
using MagicVilla_WEB.Models;
using MagicVilla_WEB.Models.DTO;
using MagicVilla_WEB.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_WEB.Controllers
{
    public class VillaWebController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaWebController(IVillaService villaService, IMapper mapper) 
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexWebVilla()
        {
            List<VillaDTO> list = new List<VillaDTO>();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess) 
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
