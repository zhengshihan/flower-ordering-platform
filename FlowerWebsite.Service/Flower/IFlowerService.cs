using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public interface IFlowerService
    {
        Task<List<FlowerRes>> GetFlowersAsync(FlowerReq req);
    }
}
