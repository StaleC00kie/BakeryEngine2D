using BakeryEngine.Graphics;

namespace BakeryEditor
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            using (Window mainWindow = new Window(800, 600, "Bakery Editor"))
            {
                mainWindow.Run();
            }

        }
    }
}
