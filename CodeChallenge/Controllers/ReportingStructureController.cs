// Created by nborden88 12/27/2023
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    /// <summary>
    /// Controller object for ReportingStructure
    /// </summary>
    [ApiController]
    [Route("api/reportingstructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }

        [HttpGet("{id}", Name = "GetReportingStructureByEmployeeId")]
        public IActionResult GetReportingStructureByEmployeeId(String id)
        {
            _logger.LogInformation($"Received ReportingStructure get request for EmployeeId '{id}'");

            if(string.IsNullOrEmpty(id)) 
                return NotFound();

            var reportingStructure = _reportingStructureService.GetReportingStructureById(id);

            if (reportingStructure != null)
                return Ok(reportingStructure);
            else
                return NotFound();
        }
    }
}
