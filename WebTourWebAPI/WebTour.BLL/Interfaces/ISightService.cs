using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebTour.BLL.DTO;

namespace WebTour.BLL.Interfaces
{
    public interface ISightService
    {
        public Task<OperationDetailDTO<List<SightDTO>>> GetSightsFromDBAsync(FilterDefinitionDTO filter = null);
        public Task<OperationDetailDTO<SightDTO>> GetSightByIDAsync(int id);
        public Task<OperationDetailDTO<List<SightDTO>>> GetTop3Sights();
    }
}
