using System;
using System.Collections.Generic;
using UnityEngine;

namespace RollABall.Data
{
    public class LevelPositionsData
    {
        public string type;
        public List<Vector3_Serializable> positions;
    }
    
    [Serializable]
    public struct Vector3_Serializable
    {
        public float x;
        public float y;
        public float z;

        public Vector3_Serializable(float valueX, float valueY, float valueZ)
        {
            x = valueX;
            y = valueY;
            z = valueZ;
        }
        public static implicit operator Vector3(Vector3_Serializable value)
        {
            return new Vector3(value.x, value.y, value.z);
        }
        public static implicit operator Vector3_Serializable(Vector3 value)
        {
            return new Vector3_Serializable(value.x, value.y, value.z);
        }
        public override string ToString() => $" ({x}, {y}, {z})";
    }
}
