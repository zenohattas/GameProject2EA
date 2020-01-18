using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProjectCode.Models
{
    class Vector3D
    {
        public float x;                                    // the x value of this Vector3D
        public float y;                                    // the y value of this Vector3D
        public float z;                                    // the z value of this Vector3D

        public Vector3D()                                  // Constructor to set x = y = z = 0
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Vector3D(float x, float y, float z)         // Constructor that initializes this Vector3D to the intended values of x, y and z
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D Set(Vector3D v)         // operator= sets values of v to this Vector3D. example: v1 = v2 means that values of v2 are set onto v1
        {
            x = v.x;
            y = v.y;
            z = v.z;
            return this;
        }
        /// <summary>
        /// Returns the sum of this and the given parameter.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D v1, Vector3D v2)             // operator+ is used to add two Vector3D's. operator+ returns a new Vector3D
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        /// <summary>
        /// Returns the subtraction of this and the given parameter.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D v1, Vector3D v2)             // operator- is used to take difference of two Vector3D's. operator- returns a new Vector3D
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        /// <summary>
        /// Returns the multiplication of this and the given parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D v, float value)            // operator* is used to scale a Vector3D by a value. This value multiplies the Vector3D's x, y and z.
        {
            return new Vector3D(v.x * value, v.y * value, v.z * value);
        }
        /// <summary>
        /// Returns the division of this and the given parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator /(Vector3D v, float value)            // operator/ is used to scale a Vector3D by a value. This value divides the Vector3D's x, y and z.
        {
            return new Vector3D(v.x / value, v.y / value, v.z / value);
        }
        /// <summary>
        /// Return current Vector3D after adding the given parameter to it.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector3D Add(Vector3D v)         // operator+= is used to add another Vector3D to this Vector3D.
        {

            x += v.x;

            y += v.y;

            z += v.z;
            return this;

        }
        /// <summary>
        /// Return current Vector3D after subtracting the given parameter from it.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Vector3D Subtract(Vector3D v)           // operator-= is used to subtract another Vector3D from this Vector3D.
        {

            x -= v.x;

            y -= v.y;

            z -= v.z;
            return this;
        }
        /// <summary>
        /// Return current Vector3D after multiplying the given parameter to it.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
	    public Vector3D MultiplyWith(float value)           // operator*= is used to scale this Vector3D by a value.
        {

            x *= value;

            y *= value;

            z *= value;
            return this;
        }
        /// <summary>
        /// Return current Vector3D after dividing the given parameter from it.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
	    public Vector3D DivideBy(float value)           // operator/= is used to scale this Vector3D by a value.
        {

            x /= value;

            y /= value;

            z /= value;
            return this;
        }

        /// <summary>
        /// Inverts the values of x, y and z
        /// </summary>
        /// <returns></returns>
	    public Vector3D Invert()                       // operator- is used to set this Vector3D's x, y, and z to the negative of them.
        {
            return new Vector3D(-x, -y, -z);
        }
        public static Vector3D operator -(Vector3D v)                       // operator- is used to set this Vector3D's x, y, and z to the negative of them.
        {
            return new Vector3D(-v.x, -v.y, -v.z);
        }

        public float length()                              // length() returns the length of this Vector3D
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        /// <summary>
        /// unitize() normalizes this Vector3D that its direction remains the same but its length is 1.
        /// </summary>
        public void unitize()                              // unitize() normalizes this Vector3D that its direction remains the same but its length is 1.
        {
            float length = this.length();

            if (length == 0)
                return;

            x /= length;
            y /= length;
            z /= length;
        }
        /// <summary>
        /// Returns a new Vector3D. The returned value is a unitized version of this Vector3D.
        /// </summary>
        /// <returns></returns>
        public Vector3D unit()                             // unit() returns a new Vector3D. The returned value is a unitized version of this Vector3D.
        {
            float length = this.length();

            if (length == 0)
                return this;

            return new Vector3D(x / length, y / length, z / length);
        }
    }
}
