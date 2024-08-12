using AutoMapper;
using BusinessObject;
using ArtworkDTO;

namespace ProductManagementAPI.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Artist, ArtistDTO>();
            CreateMap<Artwork, ArtworksDTO>();
            CreateMap<Discount, DiscountDTO>();
            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<News, NewsDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDetail, UserDetailDTO>();
            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
