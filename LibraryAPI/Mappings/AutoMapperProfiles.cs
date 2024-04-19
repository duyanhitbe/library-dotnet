using AutoMapper;
using LibraryAPI.DTO.Book;
using LibraryAPI.DTO.Category;
using LibraryAPI.Models;

namespace LibraryAPI.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CreateCategoryDto, CategoryEntity>();
        CreateMap<UpdateCategoryDto, CategoryEntity>();
        CreateMap<UpdateUserDto, UserEntity>();
    }
}