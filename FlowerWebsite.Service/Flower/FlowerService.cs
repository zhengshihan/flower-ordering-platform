using AutoMapper;
using FlowerWebsite.Common;
using FlowerWebsite.Model.Entitys;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public class FlowerService : IFlowerService
    {
        private readonly IMapper _mapper;

        public FlowerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        /*        public List<FlowerRes> GetFlowers(FlowerReq req)
                {
                    var res = DbContext.db.Queryable<Flower>().WhereIF(req.Id > 0, x => x.Id == req.Id).WhereIF(req.Type > 0, x => x.Type == req.Type).ToList();
                    return _mapper.Map<List<FlowerRes>>(res);
                }*/

        public List<FlowerRes> GetFlowers(FlowerReq req)
        {
            using (var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=localhost;Database=FlowerWebSite;Trusted_Connection=True;MultipleActiveResultSets=True",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
            }))
            {
                var res = db.Queryable<Flower>()
                            .WhereIF(req.Id > 0, x => x.Id == req.Id)
                            .WhereIF(req.Type > 0, x => x.Type == req.Type)
                            .ToList();

                var flowerResList = _mapper.Map<List<FlowerRes>>(res);
                return flowerResList;
            }
        }
    }
}
