using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        /// <summary>
        /// If the game is in progress
        /// </summary>
        bool inProgress = true;

        /// <summary>
        /// Keeps track of the current turn
        /// </summary> 
        char turn = 'X';

        /// <summary>
        /// Counts the number of moves 
        /// </summary>
        int moves = 0;

        /// <summary>
        /// Constructs a new game board
        /// </summary>
        public Board()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a click on a TicTacToe square
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSquareClick(object sender, RoutedEventArgs e)
        {
            // Only accept clicks if the game is in progress
            if (!inProgress) return;
            // Cast the sender (the clicked button) to be a Square
            var button = sender as Square;            
            // Make sure the square isn't already marked
            if (button.Mark != ' ') return;
            // Mark the button
            button.Mark = turn;
            // Switch the current turn
            if (turn == 'X') turn = 'O';
            else turn = 'X';
            // Check for a win 
            CheckForWin();
        }

        /// <summary>
        /// Check for a possible win
        /// </summary>
        void CheckForWin()
        {
            int i = 0;
            char[] squares = new char[9];
            foreach(var child in ticTacToeGrid.Children)
            {
                var square = child as Square;
                squares[i] = square.Mark;
                i++;
            }

            for(i = 0; i < 3; i++)
            {
                // check verticals
                if(squares[3*i] == squares[3*i+1] && squares[3*i+1] == squares[3*i+2])
                {
                    if (squares[3*i] != ' ') DeclareWinner(squares[i]);
                }
                // check horizontals 
                if(squares[i] == squares[i+3] && squares[i+3] == squares[i+6])
                {
                    if (squares[i] != ' ') DeclareWinner(squares[i]);
                }
            }

            // check diagonals 
            if(squares[0] == squares[4] && squares[4] == squares[8])
            {
                if (squares[0] != ' ') DeclareWinner(squares[0]);
            }
            // check diagonals 
            if (squares[2] == squares[4] && squares[4] == squares[6])
            {
                if (squares[2] != ' ') DeclareWinner(squares[2]);
            }
        }

        /// <summary>
        /// Declare the winner by displaying a message
        /// </summary>
        /// <param name="mark">the mark of the winner, either an X or O</param>
        void DeclareWinner(char mark)
        {
            inProgress = false;
            // Display the winner
            var winnerTextBlock = new TextBlock();
            winnerTextBlock.Text = $"{mark} Wins!";
            winnerTextBlock.TextAlignment = TextAlignment.Center;
            winnerTextBlock.FontSize = 40;
            ticTacToeGrid.Children.Add(winnerTextBlock);
            winnerTextBlock.SetValue(Grid.RowProperty, 1);
            winnerTextBlock.SetValue(Grid.ColumnSpanProperty, 3);
        }
    }
}
