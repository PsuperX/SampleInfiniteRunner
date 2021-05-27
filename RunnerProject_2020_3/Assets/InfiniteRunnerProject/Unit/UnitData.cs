using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RB
{
    public class UnitData
    {
        public UnitData(Transform transform)
        {
            unitTransform = transform;
            listCollisionData.Clear();
        }

        public float horizontalVelocity = 0f;
        public float verticalVelocity = 0f;
        public uint health = 1;
        public Transform unitTransform = null;

        public bool destroy = false;

        public List<CollisionData> listCollisionData = new List<CollisionData>();
    }
}