using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;
using Hackaton.Domain.Interfaces;
using Hackaton.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Infra.Data.Repository
{
    public class TrailTypeRepository : BaseRepository<TrailTypeEntity>, ITrailTypeRepository
    {
        protected readonly MyContext _context;
        private DbSet<TrailTypeEntity> _dataset;

        public TrailTypeRepository(MyContext context) : base(context)
        {
            _context = context;
            _dataset = _context.Set<TrailTypeEntity>();
        }
    }
}