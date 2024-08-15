using AutoMapper;
using FlowerWebsite.Common;
using FlowerWebsite.Model.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerWebsite.Service
{
    public class FlowerService : IFlowerService
    {
        private readonly IMapper _mapper;
        private readonly EFDbContext _context;

        public FlowerService(IMapper mapper, EFDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<FlowerRes>> GetFlowersAsync(FlowerReq req)
        {
            // Query the database using EF Core
            var query = _context.Flowers.AsQueryable();

            // Apply filters based on request parameters
            if (req.Id > 0)
            {
                query = query.Where(x => x.Id == req.Id);
            }

            if (req.Type > 0)
            {
                query = query.Where(x => x.Type == req.Type);
            }

            // Execute the query and map results to DTOs
            var flowers = await query.ToListAsync();
            var flowerResList = _mapper.Map<List<FlowerRes>>(flowers);

            return flowerResList;
        }
    }
}
