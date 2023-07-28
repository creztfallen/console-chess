using Chess;
using console_chess;
using Table;

GameTable tab = new GameTable(8, 8);

tab.PlaceThePiece(new Position(0, 0), new Knight(tab, Color.Black));
tab.PlaceThePiece(new Position(1, 2), new Queen(tab, Color.Black));
tab.PlaceThePiece(new Position(2, 3), new Rook(tab, Color.Black));

Screen.PrintTable(tab);
