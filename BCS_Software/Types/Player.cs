namespace BCS_Software.Types
{
    internal sealed class Player
    {
        public bool IsReady 
        {
            get { return _isReady; }
            set { _isReady = value; }
        }
        private bool _isReady = false;

        public float Jets 
        {
            get { return _jets; }
            set { _jets = value; }
        }
        private float _jets = 0.0f;

        public float Tanks 
        {
            get { return _tanks; }
            set { _tanks = value; }
        }
        private float _tanks = 0.0f;

        public float Soldiers 
        {
            get { return _soldiers; }
            set { _soldiers = value; }
        }
        private float _soldiers = 0.0f;

        public float LivePoints 
        {
            get { return _livePoints; }
            set { _livePoints = value; }
        }
        private float _livePoints = 0.0f;

        public int StartPoints
        {
            get { return _startPoints; }
            set { _startPoints = value; }
        }
        private int _startPoints = 0;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name;

        public int ObjectSum
        {
            get { return _objectSum; }
            set { _objectSum = value; }
        }
        private int _objectSum = 0;

        public Player()
        {
            _jets = 0.0f;
            _tanks = 0.0f;
            _soldiers = 0.0f;
            _livePoints = 0.0f;
            _isReady = false;
        }
    }
}
