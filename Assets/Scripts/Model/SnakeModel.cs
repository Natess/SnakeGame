using System;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class SnakeModel
    {
        public float Speed;
        public readonly float SpeedRotation;
        public Vector3 StartPosition;
        public float CurrentRotation = 0.0f;
        public BodyPartView BodyPart;
        public int PartsCount { get => parts.Count; }

        List<GameObject> parts;

        public SnakeModel(GameObject head, float speed, float speedRotation, Vector3 startPosition)
        {
            parts = new List<GameObject>() { head };
            Speed = speed;
            SpeedRotation = speedRotation;
            StartPosition = startPosition;
            BodyPart = Resources.Load<BodyPartView>("BodyPart");
        }

        internal GameObject GetLastBodyPart() => parts[parts.Count - 1];

        internal void AddBodyPart(GameObject bodyPartObj) => parts.Add(bodyPartObj);

        internal GameObject GetPart(int i) => parts[i];

        internal void RemoveAtPart(int i) => parts.RemoveAt(i);

        internal void PartsForeach(Action<GameObject> p) => parts.ForEach(x => p(x));
    }
}
