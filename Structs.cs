using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DProjection
{
    internal class Structs
    {
    }

    public struct Vec3D
    {
        public float x, y, z;


        public Vec3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetPoint(float x, float y , float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct FaceVertices
    {
        public Vec3D[] p {  get; set; } //p for Points

        public FaceVertices()
        {
            p = new Vec3D[4];
        }

        public FaceVertices(Vec3D v1, Vec3D v2, Vec3D v3, Vec3D v4)
        {
            p = new Vec3D[4];
            p[0] = v1;
            p[1] = v2;
            p[2] = v3;
            p[3] = v4;
        }
    }
}
