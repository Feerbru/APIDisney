using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Disney.Core.DTOs.MovieDtos;
using Disney.Core.Entities;
using Disney.Core.Interfaces.Repository;
using Disney.Core.QueryFilters;
using Disney.Infrastructure.Services.Interfaces;
using Disney.Infrastructure.utils;
using Microsoft.AspNetCore.Http;

namespace Disney.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IStorage _storage;
        private readonly IMapper _mapper;
        
        public MovieService(IMovieRepository repository, IStorage storage, IMapper mapper)
        {
            _repository = repository;
            _storage = storage;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieOutDto>> GetAll(MovieQueryFilters filters)
        {
            var entity = await _repository.GetAll();

            if (filters.Title != null)
            {
                entity = entity.Where(x => string.Equals(x.Title,filters.Title, StringComparison.CurrentCultureIgnoreCase));
            }

            if (filters.Order != null)
            {
                if (string.Equals(filters.Order, "ASC", StringComparison.CurrentCultureIgnoreCase))
                {
                    entity = entity.OrderBy(x => x.CreatingDate);
                }
                else
                {                
                    if (filters.Order.ToUpper().Equals("DESC") )
                    {
                        entity = entity.OrderByDescending(x => x.CreatingDate);
                    }
                }
            }
            
            
            return _mapper.Map<IEnumerable<MovieOutDto>>(entity);
        }

        public async Task<MovieDto> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<MovieDto>(entity);
        }

        public async Task<MovieDto> Add(CreationMovieDto dto)
        {
            var entity = _mapper.Map<Movie>(dto);
            if (entity.Image != null)
            {
                var imageUrl = await ImageSave(dto.Image);
                entity.Image = imageUrl;
            }

            var newEntity = await _repository.Add(entity);
            return _mapper.Map<MovieDto>(newEntity);

        }

        public async Task Update(int id, CreationMovieDto dto)
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