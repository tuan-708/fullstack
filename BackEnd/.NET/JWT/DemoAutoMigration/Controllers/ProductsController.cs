using AutoMapper;
using DemoAutoMigration.Common;
using DemoAutoMigration.DTO;
using DemoAutoMigration.IService;
using DemoAutoMigration.Models;
using DemoAutoMigration.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DemoAutoMigration.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IJobService service;
        private readonly IMapper mapper;

        public ProductsController(IJobService service, IMapper mapper)
        {
            this.mapper = mapper;
            this.service = service;
        }

        [HttpGet]
        public ResponseBody<List<JobDTO>> getAllJob()
        {
            return new ResponseBody<List<JobDTO>>()
            {
                statusCode = HttpStatusCode.OK,
                data = mapper.Map<List<JobDTO>>(service.GetAll()),
                message = GlobalStrings.SUCCESSFULLY,
            };
        }

        [HttpPost]
        public ResponseBody<string> addNewJob(Job job)
        {
            try
            {
                service.Add(job);
                return new ResponseBody<string>()
                {
                    statusCode = HttpStatusCode.OK,
                    data = null,
                    message = GlobalStrings.SUCCESSFULLY_SAVED,
                };
            }
            catch (Exception ex)
            {
                return new ResponseBody<string>()
                {
                    statusCode = HttpStatusCode.BadRequest,
                    data = null,
                    message = ex.Message,
                };
            }
        }
    }
}
