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
        private readonly SqlSugarClient _db;
        public FlowerService(IMapper mapper, SqlSugarClient db)
        {
            _mapper = mapper;
            _db = db;
        }

        public List<FlowerRes> GetFlowers(FlowerReq req)
        {
            var res = _db.Queryable<Flower>()
                        .WhereIF(req.Id > 0, x => x.Id == req.Id)
                        .WhereIF(req.Type > 0, x => x.Type == req.Type)
                        .ToList();

            var flowerResList = _mapper.Map<List<FlowerRes>>(res);
            return flowerResList;
        }

        //public List<FlowerRes> GetFlowers(FlowerReq req)
        //  {
        //      var res = DbContext.db.Queryable<Flower>().WhereIF(req.Id > 0, x => x.Id == req.Id).WhereIF(req.Type > 0, x => x.Type == req.Type).ToList();
        //      return _mapper.Map<List<FlowerRes>>(res);
        //  }

        //public List<FlowerRes> GetFlowers(FlowerReq req)
        //{
        //    using (var db = new SqlSugarClient(new ConnectionConfig()
        //    {
        //        ConnectionString = "Server=LAPTOP-R3RDRRQ1;Database=FlowerWebsite;Integrated Security=True;",
        //        DbType = DbType.SqlServer,
        //        IsAutoCloseConnection = true,
        //    }))
        //    {
        //        var res = db.Queryable<Flower>()
        //                    .WhereIF(req.Id > 0, x => x.Id == req.Id)
        //                    .WhereIF(req.Type > 0, x => x.Type == req.Type)
        //                    .ToList();

        //        var flowerResList = _mapper.Map<List<FlowerRes>>(res);
        //        return flowerResList;
        //    }
        //}

    }
}
