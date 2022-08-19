using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Snake
{
    internal class BodyPartModel
    {
        public GameObject Parent;
        public float Speed { get; internal set; }

        public BodyPartModel(GameObject parent, float speed)
        {
            Parent = parent;
            Speed = speed;
        }

    }
}
