using AutoMapper;
using InalandBooking.Data;
using InalandBooking.DTO;


public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<User, UserPatchDTO>().ReverseMap();
        CreateMap<User, UserSignupDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
