using AmanaTechnology.Dto;
using AmanaTechnology.IAppService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmanaTechnology.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly IBlogAppService _blogAppService;

        public BlogController(IBlogAppService blogAppService)
        {

            _blogAppService = blogAppService;
        }
        [HttpGet("GetAll")]
        public async Task< IList<GetAllBlogsDto>> GetAll()
        {
           return await _blogAppService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task <CreateOrEditeDto> GetForEdit(int id)
        {
            return await _blogAppService.GetForEdit(id);
        }

        // POST api/<BlogController>
        [HttpPost("Post")]
        public void Post(CreateOrEditeDto input)
        {
           _blogAppService.CreateOrEdite(input);
        }
        [HttpPost("Update")]
        public  async Task Update(CreateOrEditeDto input)
        {
            await _blogAppService.CreateOrEdite(input);
        }
        [HttpPost("Delete")]
        public void Delete(int id)
       {
            _blogAppService.Delete(id);
        }
    }
}
