internal class Game
{
    private Map _map = null!;
    private Player _player = null!;
    public Game()
    {
    }

    internal void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true; 
        do
        {
            //DrawMap

            //GetCommand

            //Act

            //DrawMap

            //EnemyAction

            //DrawMap


        } while (gameInProgress);
    }

    private void Init()
    {
        _map = new Map(height:10, width: 10);
        _player = new Player(); 
    }
}