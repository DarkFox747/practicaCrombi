namespace TestEntityFrameworkProyecto1.Models
{
    // Entidades base
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public UserRole Role { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }

    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<WishListItem> WishListItems { get; set; }
    }

    public class WishList : BaseEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<WishListItem> Items { get; set; }
    }

    public class WishListItem : BaseEntity
    {
        public int WishListId { get; set; }
        public int ProductId { get; set; }
        public virtual WishList WishList { get; set; }
        public virtual Product Product { get; set; }
    }

    public enum UserRole
    {
        Regular,
        Admin
    }
}
