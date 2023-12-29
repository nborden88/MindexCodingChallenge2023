using CodeChallenge.Models;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        List<Compensation> GetCompensationByEmployeeId(String id);
        Compensation Create(Compensation compensation);
    }
}
