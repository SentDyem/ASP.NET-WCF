using System.Data.Entity;

namespace WcfService
{
    public class ContactContext : DbContext
    {
        public DbSet<Contacts> Contact { get; set; }
    }
}