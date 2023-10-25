using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public interface IFlowerService
    {
        List<FlowerRes>GetFlowers(FlowerReq req);
    }
}
