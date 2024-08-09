using AutoMapper;
using ComexAPI.Data.Dtos;
using ComexLibrary;

namespace ComexAPI.Profiles
{
    public class ComexProfile : Profile
    {
        public ComexProfile()
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<UpdateCategoriaDto, Categoria>();
            CreateMap<Categoria, UpdateCategoriaDto>();
            CreateMap<Categoria, ReadCategoriaDto>();

        }
    }
}
