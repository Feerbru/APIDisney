using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.Entities;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Disney.Api.Controllers
{
    public class ExtendedBaseController<TCreation, TEntity, TDTO> : Controller
        where TEntity : BaseEntity
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;
        private readonly string _controllerName;

        public ExtendedBaseController(ICharacterService service, IMapper mapper, string controllerName)
        {
            _service = service;
            _mapper = mapper;
            _controllerName = controllerName;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TDTO>>> Get([FromQuery]CharacterQueryFilter filter)
        {
            var entity = await _service.GetAll(filter);
            var entityDto = _mapper.Map<IEnumerable<TDTO>>(entity);
            return Ok(entityDto);
        }

        [HttpGet("{id}", Name = "get")]
        
        public virtual async Task<ActionResult<TDTO>> Get(int id)
        {
            var entity = await _service.GetById(id);
            var entityDto = _mapper.Map<TDTO>(entity);
            return entityDto;
        }
        
    }
}