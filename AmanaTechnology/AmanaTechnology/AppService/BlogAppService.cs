using AmanaTechnology.Dto;
using AmanaTechnology.IAppService;
using AmanaTechnology.Model;
using AmanaTechnology.Reposatory;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace AmanaTechnology.AppService
{
    public class BlogAppService : IBlogAppService
    {
        private readonly IReposatory<Blogs> _blogReposatory;
        private readonly IMapper _mapper;
        public BlogAppService(IReposatory<Blogs> blogReposatory, IMapper mapper)
        {
            _blogReposatory = blogReposatory;
            _mapper = mapper;
        }

        public async Task CreateOrEdite(CreateOrEditeDto input)
        {
            if (input.Id == null || input.Id == default(int))
            {
                await Create(input);
            }
            else
            {
                await update(input);
            }
        }
        public async Task Create(CreateOrEditeDto input)
        {
            var blog = _mapper.Map<Blogs>(input);
            await _blogReposatory.Add(blog);
        }
        public async Task update(CreateOrEditeDto input)
        {
            var blog = await _blogReposatory.Get((int)input.Id);
            blog.Body = input.Body;
            blog.Title = input.Title;
            await _blogReposatory.Update(blog);
        }
        public async Task Delete(int id)
        {
            var blog = await _blogReposatory.Get(id);
            await _blogReposatory.remove(blog);
        }
        public async Task<List<GetAllBlogsDto>> GetAll()
        {

            var result = await _blogReposatory.GetAll();
            var blogList = _mapper.Map<List<GetAllBlogsDto>>(result);
            return blogList;
        }
        public async Task<CreateOrEditeDto> GetForEdit(int id)
        {
            var blog = await _blogReposatory.Get(id);
            var blogDto = _mapper.Map<CreateOrEditeDto>(blog);
            return blogDto;
        }
    }
}
