using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Snake
{
    public class BodyPartView : MonoBehaviour
    {
        BodyPartViewModel bodyPartViewModel;

        internal void Initialize(BodyPartViewModel vm)
        {
            bodyPartViewModel = vm;
        }
        
        void Update()
        {
            bodyPartViewModel.Transform.LookAt(bodyPartViewModel.Transform);
            transform.position = Vector3.Lerp(transform.position, bodyPartViewModel.Transform.position, Time.deltaTime * 3.0f * bodyPartViewModel.Speed);
        }
    }
}
