using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Xml;
using Timer = System.Windows.Forms.Timer;

namespace _3DProjection
{
    public partial class Projection3D : Form
    {
        float ox;   //Origin on X-Axis
        float oy;   //Origin on Y-Axis

        List<FaceVertices> cube = new List<FaceVertices>();
        Matrix4x4 proMat = new Matrix4x4();                     // Projection Matrix


        float scale = 100;                  //The scaling of the objects
        float fTheta = 0f;                  //Rotation Angle 
        Matrix4x4 rotY = new Matrix4x4();
        Matrix4x4 rotX = new Matrix4x4();


        Timer timer;

        public Projection3D()
        {
            InitializeComponent();
            InitializeNec();


            //Adding all the Coordinates of the Faces of a normalized Cube
            cube.AddRange(new List<FaceVertices>
            {
                //South
                new FaceVertices(
                    new Vec3D(-1, -1, -1),
                    new Vec3D(1, -1, -1),
                    new Vec3D(-1, 1, -1),
                    new Vec3D(1, 1, -1)
                ),
                //North
                new FaceVertices(
                    new Vec3D(-1, -1, 1),
                    new Vec3D(1, -1, 1),
                    new Vec3D(-1, 1, 1),
                    new Vec3D(1, 1, 1)
                ),
               //West
                new FaceVertices(
                    new Vec3D(-1, 1, -1),
                    new Vec3D(-1, -1, -1),
                    new Vec3D(-1, 1, 1),
                    new Vec3D(-1, -1, 1)
                ),
                //East
                new FaceVertices(
                    new Vec3D(1, 1, -1),
                    new Vec3D(1, -1, -1),
                    new Vec3D(1, 1, 1),
                    new Vec3D(1, -1, 1)
                ),
                //Top
                new FaceVertices(
                    new Vec3D(-1, 1, -1),
                    new Vec3D(1, 1, -1),
                    new Vec3D(-1, 1, 1),
                    new Vec3D(1, 1, 1)
                ),
                //Bottom
                new FaceVertices(
                    new Vec3D(-1, -1, -1),
                    new Vec3D(1, -1, -1),
                    new Vec3D(-1, -1, 1),
                    new Vec3D(1, -1, 1)
                )
            });

            //Rotate on Y Axis

            proMat.M11 = 1;
            proMat.M22 = 1;
            proMat.M33 = 1;
            proMat.M44 = 1;



            timer = new System.Windows.Forms.Timer();
            timer.Interval = 80;
            timer.Tick += new EventHandler(OnTick);
            timer.Start();

        }

        private void InitializeNec()
        {
            ox = 0.5f * canvas.Width;
            oy = 0.5f * canvas.Height;
        }

        private void OnTick(object sender, EventArgs e)
        {
            fTheta += 0.01f;
            canvas.Invalidate();
        }

        private void updRotation()
        {
            //RotationY
            rotY.M11 = (float)Math.Cos(fTheta);
            rotY.M13 = (float)Math.Sin(fTheta);
            rotY.M22 = 1;
            rotY.M31 = (float)-Math.Sin(fTheta);
            rotY.M33 = (float)Math.Cos(fTheta);
            rotY.M44 = 1;

            //Rotaion X

            rotX.M11 = 1;
            rotX.M22 = (float)Math.Cos(0.3);
            rotX.M23 = (float)Math.Sin(0.3);
            rotX.M32 = (float)-Math.Sin(0.3);
            rotX.M33 = (float)Math.Cos(0.3);
            rotX.M44 = 1;
        }

        public void DrawRectangle(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            updRotation();
            using (Graphics g = canvas.CreateGraphics())
            {
                Pen pen = new Pen(Color.White, 1);


                g.DrawLine(pen, new PointF(x1+ox, y1 + oy ), new PointF(x2 + ox , y2 + oy));
                g.DrawLine(pen, new PointF(x1+ox, y1 + oy), new PointF(x3 + ox , y3 + oy));
                g.DrawLine(pen, new PointF(x4+ox, y4 + oy), new PointF(x2 + ox , y2 + oy ));
                g.DrawLine(pen, new PointF(x4 + ox, y4 + oy), new PointF(x3 + ox, y3 + oy ));

                pen.Dispose();
            }
        }

        public void DrawCube()
        {
            foreach (var face in cube)
            {
                FaceVertices projFace = new FaceVertices();

                projFace.p[0] = MatrixVecMult(face.p[0], rotX);
                projFace.p[1] = MatrixVecMult(face.p[1], rotX);
                projFace.p[2] = MatrixVecMult(face.p[2], rotX);
                projFace.p[3] = MatrixVecMult(face.p[3], rotX);

                projFace.p[0] = MatrixVecMult(projFace.p[0], rotY);
                projFace.p[1] = MatrixVecMult(projFace.p[1], rotY);
                projFace.p[2] = MatrixVecMult(projFace.p[2], rotY);
                projFace.p[3] = MatrixVecMult(projFace.p[3], rotY);

                projFace.p[0] = MatrixVecMult(projFace.p[0], proMat);
                projFace.p[1] = MatrixVecMult(projFace.p[1], proMat);
                projFace.p[2] = MatrixVecMult(projFace.p[2], proMat);
                projFace.p[3] = MatrixVecMult(projFace.p[3], proMat);


                DrawRectangle(projFace.p[0].x * scale, projFace.p[0].y * scale, projFace.p[1].x * scale, projFace.p[1].y * scale, projFace.p[2].x * scale, projFace.p[2].y * scale, projFace.p[3].x * scale, projFace.p[3].y * scale);
            }

        }

        public Vec3D MatrixVecMult(Vec3D vi, Matrix4x4 matproj) //vi = Vector Input
        {
            Vec3D vOutput = new Vec3D();

            vOutput.x = (matproj.M11 * vi.x + matproj.M12 * vi.y + matproj.M13 * vi.z);
            vOutput.y = (matproj.M21 * vi.x + matproj.M22 * vi.y + matproj.M23 * vi.z);
            vOutput.z = (matproj.M31 * vi.x + matproj.M32 * vi.y + matproj.M33 * vi.z);

            return vOutput;
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White);
            //g.DrawLine(pen, new PointF(ox,oy), new Point(200,200));
            DrawCube();

        }
    }
}
