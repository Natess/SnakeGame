using System;
using UnityEngine;

namespace Snake
{
    public class SnakeView : MonoBehaviour
    {
        private SnakeViewModel snakeViewModel;

        #region events

        public event Action FoodEaten;
        private event Action RestartGame;
        private event Action<float> Move;

        #endregion

        public void Initialize(SnakeViewModel snakeViewModel)
        {
            this.snakeViewModel = snakeViewModel;
            Binding();
        }

        void Binding()
        {
            FoodEaten += snakeViewModel.AddNewBodyPart;
            RestartGame += snakeViewModel.RestartGame;
            Move += snakeViewModel.Move;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out FoodView foodView))
            {
                foodView.Destroy();
                FoodEaten.Invoke();
            }

            if (collision.CompareTag("Border"))
            {
                RestartGame?.Invoke();
            }
        }


        private void Update()
        {
            Move.Invoke(Input.GetAxis("Horizontal"));
        }
    }
}