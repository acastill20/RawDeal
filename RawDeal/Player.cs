namespace RawDeal;

public class Player
{
    private string _name;
    private Deck _deck;
    private Superstar _superstar;

    public Player(Deck deck)
    {
        this._deck = deck;
        this._superstar = deck.Superstar;
        this._name = deck.Superstar.Name;
    }
    
    public Deck Deck
    {
        get { return _deck; }
    }

    public Superstar Superstar
    {
        get { return _superstar; }
    }
    
    public string Name
    {
        get { return _name; }
    }
    
}