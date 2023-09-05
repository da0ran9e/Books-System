using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
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


            //Application.Run(new LoginForm());
            //Application.Run(new RegistForm());
            //Application.Run(new AdFeedForm());
            Application.Run(new LoadingForm("dricciardelloav"));
            //Application.Run(new UserForm(75, "Hughie", null, "hmacwilliam22", "f4Q,4O", "hmaccaddie22@macromedia.com", "418-655-2654", 1, new DateTime(1977,04,06), "http://dummyprofileImage.com/113x141.png/ff4444/ffffff", 46, "365 Annamark Alley", "Kiowa"));
            //Application.Run(new LoadingForm("dricciardelloav"));
            //Application.Run(new AddingData());
        }
    }
}