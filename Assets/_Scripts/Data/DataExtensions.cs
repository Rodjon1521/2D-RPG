﻿using UnityEngine;

namespace _Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector)
        {
            return new Vector3Data(vector.x, vector.y, vector.z);
        }

        public static Vector3 AsUnityVector(this Vector3Data vector3Data)
        {
            return new Vector3(vector3Data.X, vector3Data.Y, vector3Data.Z);
        }
    }
}