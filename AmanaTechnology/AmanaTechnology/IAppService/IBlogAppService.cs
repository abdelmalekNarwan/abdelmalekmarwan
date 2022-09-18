using AmanaTechnology.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology.IAppService
{
    public interface IBlogAppService
    {
        public Task<List<GetAllBlogsDto>> GetAll();
        public Task<CreateOrEditeDto> GetForEdit( int id);
        public Task CreateOrEdite(CreateOrEditeDto input);
        public Task Delete(int id);
     
    }
}
