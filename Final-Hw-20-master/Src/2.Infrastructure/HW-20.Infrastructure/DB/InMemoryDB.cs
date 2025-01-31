

using HW_20.Domain.Entites.User;

namespace HW_20.Infrastructure.DB
{
    public class InMemoryDB
    {
        public static User? OnlineUser { get; set; }
    }
}
