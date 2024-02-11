using API.Utility;
using Application.Interface;
using AutoMapper;
using Core.Specification;
using Domain.Entities;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-customers")]
        public async Task<AppResponse<List<CustomerDto>>> GetAllCustomers()
        {
            var spec = new CustomersWithServiceCategoryAndToken();
            List<Customer> list = await _unitOfWork.GetRepository<Customer>().ListAsync(spec);
            List<CustomerDto> data = _mapper.Map<List<Customer>, List<CustomerDto>>(list);
            return ResponseMaker.MakeResponse(data);
        }


    }
}
