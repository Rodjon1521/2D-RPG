using System;
using Unity.Burst.Intrinsics;
using UnityEngine;

namespace _Scripts.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(initialLevel);
        }
    }
}