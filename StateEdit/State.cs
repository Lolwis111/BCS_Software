public class State
{
    public string DataString { get; set; }
    public int Points { get; set; }

    public State()
    {

    }

    public State(string dataString, int points)
    {
        this.DataString = dataString;
        this.Points = points;
    }
}