namespace JogoCorridaWinFormsApp
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
            using (Inicio inicio = new Inicio())
            {
                if (inicio.ShowDialog() == DialogResult.OK)
                {
                    string nivel = inicio.getDificuldade();

                    if (nivel == "easy" || nivel == "medium" || nivel == "hard")
                    {
                        Application.Run(new FormJogo(nivel));
                    }
                }
            }
        }
    }
}