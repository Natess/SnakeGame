using UnityEngine;

namespace Snake
{
    public class FoodManager
    {
        public FoodView foodItem;
        private FoodManagerModel foodManagerModel;

        public FoodManager(FoodManagerModel foodManagerModel)
        {
            this.foodManagerModel = foodManagerModel;
            foodItem = Resources.Load<FoodView>("Food");
            Start();
        }

        void Start()
        {
            for (int i = 0; i < foodManagerModel.FoodCount; ++i)
            {
                Add();
            }
        }

        public void Add()
        {
            Vector3 pos = new Vector3(Random.Range(foodManagerModel.BorderWidth * -1, foodManagerModel.BorderWidth), 
                Random.Range(foodManagerModel.BorderHeight * -1, foodManagerModel.BorderHeight), 0);
            GameObject.Instantiate(foodItem, pos, Quaternion.identity);
        }
    }
}
