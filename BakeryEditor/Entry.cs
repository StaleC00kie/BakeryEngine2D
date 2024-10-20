using BakeryEngine.Graphics;

namespace BakeryEditor
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            using (MainWindow mainWindow = new MainWindow(800, 600, "Bakery Editor"))
            {
                mainWindow.Run();
            }

        }
    }
}
