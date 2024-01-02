using CodeChallenge.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        // Added by nborden88 12/29/2023
        List<Compensation> GetCompensationByEmployeeId(String id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}
