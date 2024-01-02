using CodeChallenge.Models;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        // Added by nborden88 12/29/2023
        List<Compensation> GetCompensationByEmployeeId(String id);
        Compensation Create(Compensation compensation);
    }
}
