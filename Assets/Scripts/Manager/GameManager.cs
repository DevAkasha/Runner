public class GameManager : Manager<GameManager>
{
    //DontDestroyOnLoad setting
    protected override bool isPersistent => true;

    int score;
    public int Score { get; private set; }

    public void AddScore(int score)
    {
        Score += score;
    }

}
