using FinalProjectClasses.GymMngmnt;
using FinalProjectClasses.UserMgment;
using System.Data.Entity;

namespace FinalProjectClasses
{
    public class Dbcontext : DbContext


    {
        public Dbcontext() : base("constr")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<AttandanceDDL> AttandanceDdls { get; set; }
        public DbSet<Attandance> Attandances { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Instructer> Instructers { get; set; }


    }
}
