using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hackaton.Domain.Entities;

namespace Hackaton.Domain.Interfaces
{
    public interface IQuizTrailRepository : IRepository<QuizTrail>, ITrailRulesRepository<QuizTrail>
    {
    }
}