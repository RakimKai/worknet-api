using Microsoft.EntityFrameworkCore;
using worknet_api.Models;

namespace worknet_api.Helpers
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Location)
                .WithMany()
                .HasForeignKey(p => p.PostLocationId)
                .IsRequired(false);

            modelBuilder.Entity<EmploymentType>().HasData(
                new EmploymentType
                {
                    Id = 1,
                    Title= "Full-time",
                },
                new EmploymentType
                {
                    Id = 2,
                    Title = "Part-time",
                },
                new EmploymentType
                {
                    Id = 3,
                    Title = "Remote"
                }
            );

            modelBuilder.Entity<Industry>().HasData(
                    new Industry { Id = 1, Name = "Business" },
                    new Industry { Id = 2, Name = "Real Estate" },
                    new Industry { Id = 3, Name = "Technology" },
                    new Industry { Id = 4, Name = "Healthcare" },
                    new Industry { Id = 5, Name = "Finance" },
                    new Industry { Id = 6, Name = "Education" },
                    new Industry { Id = 7, Name = "Hospitality" },
                    new Industry { Id = 8, Name = "Manufacturing" },
                    new Industry { Id = 9, Name = "Retail" },
                    new Industry { Id = 10, Name = "Transportation" },
                    new Industry { Id = 11, Name = "Marketing" },
                    new Industry { Id = 12, Name = "Construction" },
                    new Industry { Id = 13, Name = "Agriculture" },
                    new Industry { Id = 14, Name = "Media and Entertainment" },
                    new Industry { Id = 15, Name = "Energy" },
                    new Industry { Id = 16, Name = "Telecommunications" },
                    new Industry { Id = 17, Name = "Automotive" },
                    new Industry { Id = 18, Name = "Legal" },
                    new Industry { Id = 19, Name = "Environmental" },
                    new Industry { Id = 20, Name = "Architecture" },
                    new Industry { Id = 21, Name = "Pharmaceuticals" },
                    new Industry { Id = 22, Name = "Nonprofit" },
                    new Industry { Id = 23, Name = "Research and Development" },
                    new Industry { Id = 24, Name = "Information Technology" },
                    new Industry { Id = 25, Name = "Human Resources" }
                );

            modelBuilder.Entity<Location>().HasData(
               new Location { Id = 1, City = "" },
                new Location { Id = 2, City = "Banja Luka" },
                new Location { Id = 3, City = "Bijeljina" },
                new Location { Id = 4, City = "Bihać" },
                new Location { Id = 5, City = "Bosanska Krupa" },
                new Location { Id = 6, City = "Cazin" },
                new Location { Id = 7, City = "Čapljina" },
                new Location { Id = 8, City = "Derventa" },
                new Location { Id = 9, City = "Doboj" },
                new Location { Id = 10, City = "Goražde" },
                new Location { Id = 11, City = "Gračanica" },
                new Location { Id = 12, City = "Gradačac" },
                new Location { Id = 13, City = "Gradiška" },
                new Location { Id = 14, City = "Istočno Sarajevo" },
                new Location { Id = 15, City = "Konjic" },
                new Location { Id = 16, City = "Laktaši" },
                new Location { Id = 17, City = "Livno" },
                new Location { Id = 18, City = "Lukavac" },
                new Location { Id = 19, City = "Ljubuški" },
                new Location { Id = 20, City = "Mostar" },
                new Location { Id = 21, City = "Orašje" },
                new Location { Id = 22, City = "Prijedor" },
                new Location { Id = 23, City = "Sarajevo" },
                new Location { Id = 24, City = "Srebrenik" },
                new Location { Id = 25, City = "Stolac" },
                new Location { Id = 26, City = "Široki Brijeg" },
                new Location { Id = 27, City = "Trebinje" },
                new Location { Id = 28, City = "Tuzla" },
                new Location { Id = 29, City = "Visoko" },
                new Location { Id = 30, City = "Zavidovići" },
                new Location { Id = 31, City = "Zenica" },
                new Location { Id = 32, City = "Zvornik" },
                new Location { Id = 33, City = "Živinice" },
                new Location { Id = 34, City = "Travnik"}
            );

        }
    }
}
