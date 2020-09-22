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
    /// Interaction logic for Square.xaml
    /// </summary>
    public partial class Square : Button
    {
        private char mark = ' ';
        /// <summary>
        /// Gets or sets the mark of this square (an X or O)
        /// </summary>
        public char Mark 
        { 
            get { return mark; }
            set { 
                mark = value;
                textBlock.Text = mark.ToString();
            }
        }

        /// <summary>
        /// Creates a new Square
        /// </summary>
        public Square()
        {
            InitializeComponent();
        }

    }
}
