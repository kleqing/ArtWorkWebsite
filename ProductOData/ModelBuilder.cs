using BusinessObject;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ProductOData
{
    public class ModelBuilder
    {
        public static IEdmModel GetEDMModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Artist>("Artists");
            modelBuilder.EntitySet<Artwork>("Artworks");
            modelBuilder.EntitySet<Discount>("Discounts");
            modelBuilder.EntitySet<Feedback>("Feedbacks");
            modelBuilder.EntitySet<News>("News"); 
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntitySet<OrderDetail>("OrderDetails");
            modelBuilder.EntitySet<Role>("Roles");
            modelBuilder.EntitySet<User>("Users");
            modelBuilder.EntitySet<UserRole>("UserRoles");
            modelBuilder.EntitySet<UserDetail>("UserDetails");

            /*
            // Define entity types and relationships
            modelBuilder.EntityType<OrderDetail>()
                    .HasRequired(s => s.Order, (orderDetail, order) => orderDetail.OrderID == order.OrderId);
            modelBuilder.EntityType<OrderDetail>().HasRequired(c => c.Product, (orderDetail, product) => orderDetail.ProductID == product.ProductId);*/

            return modelBuilder.GetEdmModel();
        }
    }
}
