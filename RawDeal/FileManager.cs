namespace RawDeal;
using System.Collections.Generic; //Dictionary
using System.Text.Json;

public class FileManager
{
    public Dictionary<string, Card> CardsDict()
    {
        string cardsPath = Path.Combine("data", "cards.json");
        string cardsJson = File.ReadAllText(cardsPath);
        var cardsInfo = JsonSerializer.Deserialize<List<CardInfo>>(cardsJson);
        Dictionary<string, Card> cards = new Dictionary<string, Card>();
        
        foreach (var individualCardInfo in cardsInfo)
        {
            Card card = new Card(individualCardInfo);
            cards[card.Title] = card;
        }
        return cards;
    }

    public Dictionary<string, Superstar> SuperstarsDict()
    {
        string superstarsPath = Path.Combine("data", "superstar.json");
        string superstarsJson = File.ReadAllText(superstarsPath);
        var superstarsInfo = JsonSerializer.Deserialize<List<SuperstarInfo>>(superstarsJson);
        Dictionary<string, Superstar> superstars = new Dictionary<string, Superstar>();
        foreach (var individualSuperstarInfo in superstarsInfo)
        {
            Superstar superstar = new Superstar(individualSuperstarInfo);
            superstars[superstar.Name] = superstar;
        }
        return superstars;
    }

    public Deck DeckFile(string deckPath, Dictionary<string, Card> cards, Dictionary<string, Superstar> superstars)
    {
        string[] decksText = File.ReadAllLines(deckPath);
        Deck deck = new Deck(decksText, cards, superstars);
        return deck;
    }
    
}