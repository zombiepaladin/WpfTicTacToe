using System;
using System.Collections.Generic;
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
        char turn = 'X';

        public Board()
        {
            InitializeComponent();
        }

        void OnSquareClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Square;
            if (button.Mark != ' ') return;
            button.Mark = turn;
            if (turn == 'X') turn = 'O';
        }

        void CheckForWin()
        {
            ticTacToeGrid.Children
        }
    }
}
