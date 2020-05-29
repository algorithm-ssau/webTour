using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTour.BLL.DTO;
using WebTour.BLL.Interfaces;
using WebTour.DAL.Data;

namespace WebTour.BLL.Services
{
    public class SightService : ISightService
    {
        private readonly DataContext _context;
        private const string _serverErrorMessage = "Произошла ошибка на сервере. Подробнее: ";
        private const string _apiBaseImageURLstring = "https://localhost:44356/images/";

        public SightService(DataContext context)
        {
            _context = context;
        }

        public async Task<OperationDetailDTO<SightDTO>> GetSightByIDAsync(int id)
        {
            try
            {
                var entity = await _context.Sights.Include(s => s.Images).Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
                if (entity == null)
                    return new OperationDetailDTO<SightDTO> 
                    { Succeeded = false, ErrorMessages = { "Достопремичательность не найдена" } };
                var dto = SightDTO.Map(entity);
                return new OperationDetailDTO<SightDTO> { Succeeded = true, Data = dto };
            }
            catch (Exception e)
            {
                return new OperationDetailDTO<SightDTO> { Succeeded = false, ErrorMessages = { _serverErrorMessage + e.Message } };
            }
        }

        public async Task<OperationDetailDTO<List<SightDTO>>> GetSightsFromDBAsync(FilterDefinitionDTO filter = null)
        {
            var resList = new List<SightDTO>();
            try
            {
                var sights = from s in _context.Sights.Include(s => s.Category).Include(s => s.Images) select s;

                if(filter != null)
                {
                    if(filter.Name == "category" && !String.IsNullOrEmpty(filter.Value))
                    {
                        sights = sights.Where(s => s.Category.Name.ToLower() == filter.Value);
                    }
                }

                var sightEntities = await sights.AsNoTracking().ToListAsync();

                foreach(var entity in sightEntities)
                {
                    resList.Add(SightDTO.Map(entity));
                }

                return new OperationDetailDTO<List<SightDTO>> { Succeeded = true, Data = resList };
            }

            catch (Exception e)
            {
                return new OperationDetailDTO<List<SightDTO>> { Succeeded = false, ErrorMessages = { _serverErrorMessage + e.Message } };
            }
        }

        public async Task<OperationDetailDTO<List<SightDTO>>> GetTop3Sights()
        {
            var resList = new List<SightDTO>();
            try 
            {
                var sights = from s in _context.Sights.Include(s => s.Category).Include(s => s.Images) select s;
                sights = sights.OrderByDescending(s => s.LikeCount);
                var entities = await sights.ToArrayAsync();

                if(entities.Length > 3)
                {
                    for (int i = 0; i == 2; i++)
                        resList.Add(SightDTO.Map(entities[i]));
                }
                else
                {
                    foreach(var entity in entities)
                        resList.Add(SightDTO.Map(entity));
                }
                    
                return new OperationDetailDTO<List<SightDTO>> { Succeeded = true, Data = resList };
            }

            catch (Exception e)
            {
                return new OperationDetailDTO<List<SightDTO>> { Succeeded = false, ErrorMessages = { _serverErrorMessage + e.Message } };
            }
        }
    }
}
