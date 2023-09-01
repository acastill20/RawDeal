using RawDeal;
using RawDealView;
//En view no deberiamos cambiar nada -> Solo llamar a los metodos importanes
//Crea vista de tipo consola
View view = View.BuildConsoleView();
//Test cases de los casos validos
string deckFolder = Path.Combine("data", "02-InvalidDecks");
Game game = new Game(view, deckFolder);
game.Play();