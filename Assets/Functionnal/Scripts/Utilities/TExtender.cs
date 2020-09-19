using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterviewTask
{
    public static class TExtender
    {
        #region Vector3
        public static Vector3 SetX(this Vector3 v, float x)
        {
            v.x = x;
            return v;
        }
        public static Vector3 SetY(this Vector3 v, float y)
        {
            v.y = y;
            return v;
        }
        public static Vector3 SetZ(this Vector3 v, float z)
        {
            v.z = z;
            return v;
        }
        public static Vector3 AddX(this Vector3 v, float x)
        {
            v.x += x;
            return v;
        }
        public static Vector3 AddY(this Vector3 v, float y)
        {
            v.y += y;
            return v;
        }
        public static Vector3 AddZ(this Vector3 v, float z)
        {
            v.z += z;
            return v;
        }
        public static Vector2 ToV2(this Vector3 v, bool Z_AxisIs_Y_Axis = false)
        {
            return new Vector2(v.x, Z_AxisIs_Y_Axis ? v.z : v.y);
        }
        #endregion

        #region Vector2
        public static Vector2 SetX(this Vector2 v, float x)
        {
            v.x = x;
            return v;
        }
        public static Vector2 SetY(this Vector2 v, float y)
        {
            v.y = y;
            return v;
        }
        public static Vector2 AddX(this Vector2 v, float x)
        {
            v.x += x;
            return v;
        }
        public static Vector2 AddY(this Vector2 v, float y)
        {
            v.y += y;
            return v;
        }
        public static Vector3 ToV3(this Vector2 v, float zValue = 0)
        {
            return new Vector3(v.x, v.y, zValue);
        }
        public static Vector3 ToV3_YisZ(this Vector2 v)
        {
            return new Vector3(v.x, 0, v.y);
        }
        #endregion

        #region Colors
        public static Color SetA(this Color c, float a)
        {
            c.a = a;
            return c;
        }
        public static Color SetR(this Color c, float r)
        {
            c.r = r;
            return c;
        }
        public static Color SetG(this Color c, float g)
        {
            c.g = g;
            return c;
        }
        public static Color SetB(this Color c, float b)
        {
            c.b = b;
            return c;
        }
        public static Color AddA(this Color c, float a)
        {
            c.a += a;
            return c;
        }
        public static Color AddR(this Color c, float r)
        {
            c.r += r;
            return c;
        }
        public static Color AddG(this Color c, float g)
        {
            c.g += g;
            return c;
        }
        public static Color AddB(this Color c, float b)
        {
            c.b += b;
            return c;
        }
        public static Color MoveTowards(this Color current, Color target, float amount)
        {
            float rDist = target.r - current.r;
            float gDist = target.g - current.g;
            float bDist = target.b - current.b;
            float aDist = target.a - current.a;
            float sqrMagn = rDist * rDist + gDist * gDist + bDist * bDist + aDist * aDist;
            if (sqrMagn != 0 && (amount < 0 || sqrMagn > amount * amount))
            {
                float magn = Mathf.Sqrt(sqrMagn);
                return new Vector4(
                    current.r + ((rDist / magn) * amount),
                    current.g + ((gDist / magn) * amount),
                    current.b + ((bDist / magn) * amount),
                    current.a + ((aDist / magn) * amount));
            }
            else
            {
                return target;
            }
        }
        #endregion
    }
}