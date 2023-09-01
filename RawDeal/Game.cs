using System.Text.Json;
using RawDealView;
using System.Collections.Generic; //Dictionary

namespace RawDeal;

public class  Game
{
    private View _view;
    private string _deckFolder;
    
    public Game(View view, string deckFolder)
    {
        _view = view;
        _deckFolder = deckFolder;
    }

    public void Play()
    {
        //Datos Cartas
        string cardsPath = Path.Combine("data", "cards.json");
        string cardsJson = File.ReadAllText(cardsPath);
        var cardsInfo = JsonSerializer.Deserialize<List<CardInfo>>(cardsJson);
        
        Dictionary<string, Card> cards = new Dictionary<string, Card>();
        
        foreach (var individualCardInfo in cardsInfo)
        {
            Card card = new Card(individualCardInfo);
            cards[card.Title] = card;
        }
        
        //Datos Superstars
        string superstarsPath = Path.Combine("data", "superstar.json");
        string superstarsJson = File.ReadAllText(superstarsPath);
        var superstarsInfo = JsonSerializer.Deserialize<List<SuperstarInfo>>(superstarsJson);
        Dictionary<string, Superstar> superstars = new Dictionary<string, Superstar>();
        foreach (var individualSuperstarInfo in superstarsInfo)
        {
            Superstar superstar = new Superstar(individualSuperstarInfo);
            superstars[superstar.Name] = superstar;
        }
        
        //Datos Decks 1
        string deckPath = _view.AskUserToSelectDeck(_deckFolder);
        string[] decksText = File.ReadAllLines(deckPath);
        Deck deck = new Deck(decksText, cards, superstars);
        if (deck.CheckValidity(cards) == false)
        {
            _view.SayThatDeckIsInvalid();
            return;
        }
        
        //Datos Decks 2
        string deckPath2 = _view.AskUserToSelectDeck(_deckFolder);
        string[] decksText2 = File.ReadAllLines(deckPath2);
        Deck deck2 = new Deck(decksText2, cards, superstars);
        if (deck2.CheckValidity(cards) == false)
        {
            _view.SayThatDeckIsInvalid();
            return;
        }
    }
}