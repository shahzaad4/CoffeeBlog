using AutoMapper;
using Coffee.Web.DTOs;
using Coffee.Web.Models;

namespace Coffee.Web.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<UpdatePostDto, Post>().ReverseMap();

        }
    }
}
