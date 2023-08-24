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
            Application.Run(new MainForm("smarnes71"));
            //Application.Run(new LoadingForm(100));

        }
    }
}