using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemPro.Api.Responses;
using SystemPro.Core.DTOs;
using SystemPro.Core.Interfaces;

namespace SystemPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeIdentificationController : ControllerBase
    {
        private readonly ITypeIdentificationService _typeIdentificationService;
        private readonly IMapper _mapper;

        public TypeIdentificationController(ITypeIdentificationService typeIdentificationService, IMapper mapper)
        {
            _typeIdentificationService = typeIdentificationService;
            _mapper = mapper;
        }


        /// <summary>
        /// get types Identification 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTypesIdentification()
        {
            var types = await _typeIdentificationService.GetTypesIdentification();
            //var typesDtos = _mapper.Map<IEnumerable<TypeIdentificationDto>>(types);
            //var response = new ApiResponse<IEnumerable<UserDto>>(usersDtos);
            return Ok(types);
        }
    }
}