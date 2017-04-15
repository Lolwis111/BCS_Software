namespace BCS_Software.Types
{
    internal sealed class CustomImages
    {
        public CustomImages()
        {
 
        }

        public string SoldierImagePath
        {
            get { return soldierPath; }
            set { soldierPath = value; }
        }
        private string soldierPath = string.Empty;

        public string TankImagePath
        {
            get { return tankPath; }
            set { tankPath = value; }
        }
        private string tankPath = string.Empty;

        public string JetImagePath
        {
            get { return jetPath; }
            set { jetPath = value; }
        }
        private string jetPath = string.Empty;
    }
}
