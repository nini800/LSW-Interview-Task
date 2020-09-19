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
    }