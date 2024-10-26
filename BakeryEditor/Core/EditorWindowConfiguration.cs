using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Silk.NET.Maths;
using Silk.NET.Windowing;

namespace BakeryEditor.Core
{
    internal class EditorWindowConfiguration
    {
        public Vector2D<int> WindowPosition { get; set; }
        public Vector2D<int> Size { get; set; }
        public string Title { get; set; }
        public GraphicsAPI GraphicsAPI { get; private set; }

        public EditorWindowConfiguration(int posX, int posY, int width, int height, string title, GraphicsAPI graphicsAPI = default)
        {
            if(width <= 0 || height <= 0)
            {
                throw new ArgumentException($"{nameof(width)} and/or {nameof(height)} in the {nameof(EditorWindowConfiguration)} constructor both need to be positive.");
            }

            if (posX < 0 || posY < 0)
            {
                throw new ArgumentException($"{nameof(posX)} and/or {nameof(posY)} in the {nameof(EditorWindowConfiguration)} constructor both need to be positive.");
            }

            WindowPosition = new Vector2D<int>(posX, posY);
            Size = new Vector2D<int>(width, height);
            Title = title;
            GraphicsAPI = graphicsAPI;
        }
    }
}
