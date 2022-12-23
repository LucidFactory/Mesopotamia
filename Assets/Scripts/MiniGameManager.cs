
public class MiniGameManager
{
    public string GroupeEpreuve { get; private set; }
    public string Epreuve { get; private set; }

    public MiniGameManager(string groupeEpreuve)
    {
        string[] SplitEpreuve = groupeEpreuve.Split(";");
        GroupeEpreuve = SplitEpreuve[0]; 
        Epreuve = SplitEpreuve[1]; 
    }
}
