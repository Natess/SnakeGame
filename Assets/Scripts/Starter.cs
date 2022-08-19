using UnityEngine;

namespace Snake
{
    internal class Starter : MonoBehaviour
    {
        [SerializeField] private SnakeView head;
        [SerializeField] private float speed = 0.8f;
        [SerializeField] private float speedRotation = 100;
        [SerializeField] private Vector3 startPosition = new Vector3(-5.0f, -3.0f, 0);


        [SerializeField] private float borderWidth = 8.0f;
        [SerializeField] private float borderHeight = 4.0f;
        [SerializeField] private int foodCount = 7;

        private void Start()
        {
            var snakeModel = new SnakeModel(head.gameObject, speed, speedRotation, startPosition);
            var snakeViewModel = new SnakeViewModel(snakeModel);
            head.Initialize(snakeViewModel);

            var foodManagerModel = new FoodManagerModel(borderHeight, borderWidth, foodCount);
            var foodManager = new FoodManager(foodManagerModel);
            head.FoodEaten += foodManager.Add;
        }

    }
}
