using BakeryEngine.Graphics;
using BakeryEngine.Graphics.OpenGL;
using Silk.NET.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shader = BakeryEngine.Graphics.Shader;
using Texture = BakeryEngine.Graphics.Texture;

namespace BakeryEngine.Core
{
    internal class Test : EngineObject
    {

        private static GLBufferObject<float> _vbo;
        private static GLBufferObject<uint> _ebo;
        private static GLVertexArrayObject<float, uint> _vao;

        public static Texture Texture;
        private static Shader _shader;


        private static readonly float[] Vertices =
{
            //X    Y      Z     S    T
             0.5f,  0.5f, 0.0f, 1.0f, 0.0f,
             0.5f, -0.5f, 0.0f, 1.0f, 1.0f,
            -0.5f, -0.5f, 0.0f, 0.0f, 1.0f,
            -0.5f,  0.5f, 0.5f, 0.0f, 0.0f
        };

        private static readonly uint[] Indices =
        {
            0, 1, 3,
            1, 2, 3
        };

        public void Awake()
        {
            Console.WriteLine("Test Awake");

            _ebo = new GLBufferObject<uint>(Window.GL, Indices, BufferTargetARB.ElementArrayBuffer);
            _vbo = new GLBufferObject<float>(Window.GL, Vertices, BufferTargetARB.ArrayBuffer);
            _vao = new GLVertexArrayObject<float, uint>(Window.GL, _vbo, _ebo);

            _vao.VertexAttributePointer(0, 3, VertexAttribPointerType.Float, 5, 0);
            _vao.VertexAttributePointer(1, 2, VertexAttribPointerType.Float, 5, 3);

            _shader = new Shader(Window.GL, "shader.vert", "shader.frag");

            Texture = new Texture(Window.GL, "silk.png");
        }

        public unsafe void Draw()
        {
            _vao.Bind();
            _shader.Use();

            Texture.Bind(TextureUnit.Texture0);


            _shader.SetUniform("uTexture", 0);

            Window.GL.DrawElements(PrimitiveType.Triangles, (uint)Indices.Length, DrawElementsType.UnsignedInt, null);


        }

        public void Shutdown()
        {
            _vbo.Dispose();
            _ebo.Dispose();
            _vao.Dispose();
            _shader.Dispose();
            Texture.Dispose();
        }
    }
}
