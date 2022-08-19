using System;
using UnityEngine;

namespace Snake
{
    internal class BodyPartViewModel
    {
        internal Transform Transform { get => model.Parent.transform; }
        public float Speed { get => model.Speed; }

        private BodyPartModel model;

        public BodyPartViewModel(BodyPartModel model)
        {
            this.model = model;
        }


    }
}