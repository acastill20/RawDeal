using System.Data;

namespace RawDeal;

public enum Logo
{
    StoneCold,
    Undertaker,
    Mankind,
    HHH,
    TheRock,
    Kane,
    Jericho,
}
public class Deck
{
    private List<Card> _cards;
    private Superstar _superstar;
    private bool _valid = true;

    public Deck(string [] deckText, Dictionary<string, Card> cards, Dictionary<string, Superstar> superstars)
    {
        this._cards = new List<Card>();
        bool name = true;
        foreach (var line in deckText)
        {
            if (name)
            {
                int openingParenthesisIndex = line.IndexOf('(');
                string superStarName = line.Substring(0, openingParenthesisIndex).Trim();
                this._superstar = superstars[superStarName];
                name = false;
            }
            else
            {
                this._cards.Add(cards[line]);
            }
        }
    }

    public bool CheckValidity(Dictionary<string, Card> cardsDict)
    {
        bool heel = false;
        bool face = false;

        //Ver la existencia de una o más superestrellas
        if (_valid == false)
        {
            return false;
        }
        
        //Primera Regla
        if (_cards.Count != 60)
        {
            return false;
        }
        
        foreach (var card in _cards)
        {
            //Tercera Regla
            if (card.SubTypes.Contains("Heel"))
            {
                heel = true;

            }
            else if (card.SubTypes.Contains("Face"))
            {
                face = true;
            }
            if (heel && face)
            {
                return false;
            }
            
            //Segunda Regla
            List<Card> repeatedCards = _cards.FindAll(x => x.Title == card.Title);
            int numberRepeatedCards = repeatedCards.Count();
            bool repeatedValid = true;

            if (numberRepeatedCards > 3)
            {
                repeatedValid = false;
            }
            
            foreach (string subType in card.SubTypes)
            {
                //Segunda Regla
                if (subType == "Unique" && numberRepeatedCards > 1)
                {
                    return false;
                }

                if (subType == "SetUp")
                {
                    repeatedValid = true;
                }
                
                //Cuarta Regla
                if (Enum.IsDefined(typeof(Logo), subType) && _superstar.Logo != subType)
                {
                    return false;
                }
            }

            if (repeatedValid == false)
            {
                return false;
            }
        }
        return true;
    }

    public List<Card> Cards
    {
        get { return _cards; }
    }

    public Superstar Superstar
    {
        get { return _superstar; }
    }
    
}