using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface IReportingStructureService
    {
        //Added by nborden88 12/27/2023
        ReportingStructure GetReportingStructureById(string id);
    }
}
