using SharpGL;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem2.OpenGl
{
    public partial class Form1 : Form
    {
        private double posX = 0.0f;
        private double posZ = 0.0f;
        private float prevMouseX = 0.0f;
        private float sensitivityX = 0.1f;
        private float cameraAngley = 0.0f;
        private List<MyCube> cubeList = new List<MyCube>();
        private OpenGL gl;
        public Form1()

        {
            
            InitializeComponent();
            openGLControl1.OpenGLInitialized += openGLControl1_OpenGLInitialized;
            openGLControl1.OpenGLDraw += openGLControl1_OpenGLDraw;
            openGLControl1.MouseMove += openGLControl1_MouseMove;
            openGLControl1.KeyDown += openGLControl1_KeyDown;


        }
        private void drawFloor()
        {
            float floorSize = 10.0f;

            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(0.5f, 0.5f, 0.5f); 

            gl.Vertex(-floorSize, -1.0f, -floorSize);
            gl.Vertex(floorSize, -1.0f, -floorSize);
            gl.Vertex(floorSize, -1.0f, floorSize);
            gl.Vertex(-floorSize, -1.0f, floorSize);

            gl.End();

        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            prevMouseX = MousePosition.X;

            posX = 0.0f;
            posZ = -5.0f;
            cameraAngley = 0.0f;

            sensitivityX = 0.1f;

        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) posZ += 0.1; 
            if (e.KeyCode == Keys.S) posZ -= 0.1; 
            if (e.KeyCode == Keys.A) posX += 0.1; 
            if (e.KeyCode == Keys.D) posX -= 0.1; 


        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            
            gl.LoadIdentity();
            gl.Rotate(cameraAngley, 0.0f, 1.0f, 0.0f);
            gl.Translate(posX, 0.0f, posZ); 
           

            
            drawFloor();
            foreach (var cube in cubeList)
            {
                cube.Draw(gl);
            }

            gl.Flush();
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            gl = openGLControl1.OpenGL;

            gl.ClearColor(0, 0, 0, 1);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            Random rand = new Random();
            for (int i = 0; i < 6; i++) // Add 2 cubes
            {
                double x = rand.Next(-5, 6); 
                double z = rand.Next(-5, 6); 
                cubeList.Add(new MyCube(x, z));
            }
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float deltaX = e.X - prevMouseX;

            
            cameraAngley += deltaX * sensitivityX;

            if (cameraAngley >= 360)
            {
                cameraAngley %= 360;
            }
            else if (cameraAngley < 0)
            {
                cameraAngley += 360;
            }

            
            prevMouseX = e.X;

            openGLControl1.Invalidate();
        }
    }
}
