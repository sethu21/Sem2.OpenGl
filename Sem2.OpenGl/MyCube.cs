using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2.OpenGl
{
    public class MyCube
    {
        public double X { get; set; }
        public double Z { get; set; }

        public MyCube(double x, double z)
        {
            X = x;
            Z = z;
        }

        public void Draw(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(X, 0.0f, Z); // Position the cube
            gl.Color(1.0f, 2.0f, 0.0f); 

            gl.Begin(OpenGL.GL_QUADS);

            // Front face
            gl.Vertex(-0.5f, -0.5f, 0.5f);
            gl.Vertex(0.5f, -0.5f, 0.5f);
            gl.Vertex(0.5f, 0.5f, 0.5f);
            gl.Vertex(-0.5f, 0.5f, 0.5f);

            // Back face
            gl.Vertex(-0.5f, -0.5f, -0.5f);
            gl.Vertex(0.5f, -0.5f, -0.5f);
            gl.Vertex(0.5f, 0.5f, -0.5f);
            gl.Vertex(-0.5f, 0.5f, -0.5f);

            // Left face
            gl.Vertex(-0.5f, -0.5f, -0.5f);
            gl.Vertex(-0.5f, -0.5f, 0.5f);
            gl.Vertex(-0.5f, 0.5f, 0.5f);
            gl.Vertex(-0.5f, 0.5f, -0.5f);

            // Right face
            gl.Vertex(0.5f, -0.5f, -0.5f);
            gl.Vertex(0.5f, -0.5f, 0.5f);
            gl.Vertex(0.5f, 0.5f, 0.5f);
            gl.Vertex(0.5f, 0.5f, -0.5f);

            // Top face
            gl.Vertex(-0.5f, 0.5f, -0.5f);
            gl.Vertex(0.5f, 0.5f, -0.5f);
            gl.Vertex(0.5f, 0.5f, 0.5f);
            gl.Vertex(-0.5f, 0.5f, 0.5f);

            // Bottom face
            gl.Vertex(-0.5f, -0.5f, -0.5f);
            gl.Vertex(0.5f, -0.5f, -0.5f);
            gl.Vertex(0.5f, -0.5f, 0.5f);
            gl.Vertex(-0.5f, -0.5f, 0.5f);

            gl.End();

            gl.PopMatrix();
        }
    }
}
