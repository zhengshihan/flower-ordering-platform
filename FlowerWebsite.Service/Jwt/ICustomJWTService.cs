using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public interface ICustomJwtService
    {
        string GetToken(UserRes user);
    }
}
