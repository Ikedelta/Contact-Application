namespace Contact_Application
{
    internal static class Program
    {

        // Method to prompt for password
       

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.Run(new EditForm());
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());


        }
    }
}