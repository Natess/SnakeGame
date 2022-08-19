using UnityEngine;

namespace Snake
{
    public class SnakeViewModel
    {
        SnakeModel SnakeModel { get; }
        GameObject Head { get => SnakeModel.GetPart(0); }

        public SnakeViewModel(SnakeModel snakeModel)
        {
            SnakeModel = snakeModel;
        }

        internal void AddNewBodyPart()
        {
            GameObject parent = SnakeModel.GetLastBodyPart();
            BodyPartView bodyPartObj = Object.Instantiate(SnakeModel.BodyPart, parent.transform.position, Quaternion.identity);
            var model = new BodyPartModel(parent, SnakeModel.Speed);
            var vm = new BodyPartViewModel(model);
            bodyPartObj.Initialize(vm);

            SnakeModel.AddBodyPart(bodyPartObj.gameObject);

            SnakeModel.Speed += 0.1f;
        }

        internal void RestartGame()
        {
            ClearPosition();

            var newCount = SnakeModel.PartsCount / 2;
            if(newCount == 0)
                Application.Quit();
            for (int i = SnakeModel.PartsCount - 1; i >= newCount; i--)
            {
                var deletingParts = SnakeModel.GetPart(i);
                SnakeModel.RemoveAtPart(i); 
                GameObject.Destroy(deletingParts);
            }
            SnakeModel.PartsForeach(x => x.gameObject.transform.SetPositionAndRotation(SnakeModel.StartPosition, new Quaternion(0, 1, 0, 0)));
        }

        private void ClearPosition()
        {
            Head.gameObject.transform.position = SnakeModel.StartPosition;
            Head.transform.rotation.eulerAngles.Set(0, 0, 0);
            SnakeModel.CurrentRotation = 0f;
        }

        internal void Move(float inpHorizontal)
        {
            SnakeModel.CurrentRotation -= inpHorizontal * SnakeModel.SpeedRotation * Time.deltaTime;
            Head.transform.rotation = Quaternion.Euler(0, 0, SnakeModel.CurrentRotation);
            Head.transform.Translate(Vector3.up * SnakeModel.Speed * Time.deltaTime);
        }
    }
}
