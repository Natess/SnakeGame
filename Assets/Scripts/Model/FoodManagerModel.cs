namespace Snake
{
    public class FoodManagerModel
    {
        public float BorderHeight;
        public float BorderWidth;
        public int FoodCount;

        public FoodManagerModel(float borderHeight, float borderWidth, int foodCount)
        {
            this.BorderHeight = borderHeight;
            this.BorderWidth = borderWidth;
            this.FoodCount = foodCount;
        }
    }
}