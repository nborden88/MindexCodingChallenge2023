using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services
{
    //created by nborden88 12/27/2023
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;

        }

        /// <summary>
        /// Returns ReportingStructure object that contains the Employee Object and numberOfReports field.
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns>ReportingStructure</returns>
        public ReportingStructure GetReportingStructureById(string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id))
                    return null;

                ReportingStructure reportingStructure = new ReportingStructure();
                _logger.LogInformation("Employee ID: " + id + "\n");
                reportingStructure.employee = _employeeRepository.GetById(id);
                _logger.LogInformation(reportingStructure.employee.FirstName + "\n");
                reportingStructure.numberOfReports = this.GetNumberOfReportsByEmployeeId(id);

                return reportingStructure;
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetReportingStructureById failed: {ex.Message}");
                return null;
            }
            
           
        }

        /// <summary>
        /// Returns numberOfReports field per given EmployeeId recursively.
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns>Integer of numberOfReports. If no record is found, returns value of 0.</returns>
        private int GetNumberOfReportsByEmployeeId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var employee = _employeeRepository.GetById(id);
                if (employee == null || employee.DirectReports == null)
                    return 0;

                int numberOfReports = employee.DirectReports.Count;
                foreach (Employee emp in employee.DirectReports)
                {
                    numberOfReports += GetNumberOfReportsByEmployeeId(emp.EmployeeId);
                }
                return numberOfReports;
            }

            return 0;
        }
    }
}
