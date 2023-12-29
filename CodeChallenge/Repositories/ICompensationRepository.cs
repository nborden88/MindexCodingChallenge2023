using CodeChallenge.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        List<Compensation> GetCompensationByEmployeeId(String id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}
