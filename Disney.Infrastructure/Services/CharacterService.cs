using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Services.Interfaces;
using Disney.Infrastructure.utils;
using Microsoft.AspNetCore.Http;

namespace Disney.Infrastructure.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _repository;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;

        public CharacterService(ICharacterRepository repository ,IStorage storage, IMapper mapper)
        {
            _repository = repository;
            _storage = storage;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CharacterDTO>> GetAll(CharacterQueryFilter filter)
        {
            var entity = await _repository.GetAll();
            if (filter.Name != null)
            {
                entity = entity.Where(x => string.Equals(x.Name, filter.Name, StringComparison.CurrentCultureIgnoreCase));
            }

            if (filter.Age != null)
            {
                entity = entity.Where(x => x.Age == filter.Age);
            }

            if (filter.Weight != null)
            {
                entity = entity.Where(x => Equals(x.Weight, filter.Weight));
            }

            if (filter.IdMovie != null)
            {
                //entity = entity.Where(x => x.Movies.Select(m => m.Id == filter.IdMovie) == filter);
            }
            
            return _mapper.Map<IEnumerable<CharacterDTO>>(entity);
        }
        
        public async Task<CharacterOutDTO> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CharacterOutDTO>(entity);
        }
        
        public async Task<CharacterOutDTO> Add(CreationCharacterDto characterDto)
        {
            var entity = _mapper.Map<Character>(characterDto);
            if (entity.Image != null)
            {
                var imageUrl = await ImageSave(characterDto.Image);
                entity.Image = imageUrl; 
            }

            var newEntity = await _repository.Add(entity);
            return _mapper.Map<CharacterOutDTO>(newEntity);
        }
        
        public async Task Update(int id, CreationCharacterDto dto)
        {
            try
            {
                var entity = await _repository.GetById(id);
                _mapper.Map(dto, entity);

                if (dto.Image != null)
                {
                    if (!string.IsNullOrEmpty(entity.Image))
                    {
                        await _storage.Delete(entity.Image, ApplicationConstants.FileConstants.ImageContainer);
                    }

                    var imageUrl = await ImageSave(dto.Image);
                    entity.Image = imageUrl;
                }

                await _repository.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
        
        private async Task<string> ImageSave(IFormFile image)
        {
             var stream = new MemoryStream();

            await image.CopyToAsync(stream);

            var fileBytes = stream.ToArray();

            return await _storage
                .ToCreate(fileBytes, image.ContentType, Path.GetExtension(image.FileName),
                    ApplicationConstants.FileConstants.ImageContainer, Guid.NewGuid().ToString());
        }
    }
}