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
        FileManager fileManager = new FileManager();
        //Datos Cartas
        Dictionary<string, Card> cards = fileManager.CardsDict();
        //Datos Superstars
        Dictionary<string, Superstar> superstars = fileManager.SuperstarsDict();

        List<Player> players = new List<Player>();

        for (int i = 0; i < 2; i++)
        {
            string deckPath = _view.AskUserToSelectDeck(_deckFolder);
            Deck deck = fileManager.DeckFile(deckPath, cards, superstars);
            players.Add(new Player(deck));
            if (players[i].Deck.CheckValidity(cards) == false)
            {
                _view.SayThatDeckIsInvalid();
                return;
            }
        }
        if (players[1].Superstar.SuperstarValue > players[0].Superstar.SuperstarValue)
        {
            players.Reverse();
        }
        
        _view.SayThatATurnBegins(players[0].Name);
        PlayerInfo player_info_0 = new PlayerInfo(players[0].Name, 0, players[0].Superstar.HandSize + 1,
            players[0].Deck.Cards.Count() - players[0].Superstar.HandSize - 1);
        PlayerInfo player_info_1 = new PlayerInfo(players[1].Name, 0, players[1].Superstar.HandSize,
            players[1].Deck.Cards.Count() - players[1].Superstar.HandSize);
        _view.ShowGameInfo(player_info_0, player_info_1);
        _view.AskUserWhatToDoWhenItIsNotPossibleToUseItsAbility();
        _view.CongratulateWinner(players[1].Name);
    }
}