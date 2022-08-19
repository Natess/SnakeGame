using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class FoodView : MonoBehaviour
    {
        internal void Destroy()
        {
            Destroy(gameObject);
        }
    }
}