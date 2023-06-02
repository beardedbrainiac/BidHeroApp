namespace BidHeroApp.InputModels
{
    public class BaseInputModel
    {
        private string _userId = string.Empty;

        public void SetUserId(string userId)
        {
            this._userId = userId;
        }

        public string GetUserId()
        {
            return this._userId;
        }
    }
}
