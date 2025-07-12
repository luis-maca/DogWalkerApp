using Microsoft.EntityFrameworkCore;
using DogWalkerApp.Infrastructure.Data;
using System.Windows.Forms;


namespace DogWalkerApp.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Db Configuration
            var options = new DbContextOptionsBuilder<DogWalkerDbContext>()
                                .UseSqlite("Data Source=dogwalker.db")
                                .Options;

            using var context = new DogWalkerDbContext(options);
            context.Database.Migrate();

            //Seed the database for initial setup
            DbInitializer.Seed(context);

            System.Windows.Forms.Application.Run(new MainMenuForm(context));
        }
    }
}