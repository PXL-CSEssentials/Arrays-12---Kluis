using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arrays_12___Kluis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] _code = { 2, 3, 8, 8, 9, 0 };
        private char[] _inputCode = { '*', '*', '*', '*', '*', '*' };
        private const int NumberOfAttempts = 3;
        private int _restAttempts = NumberOfAttempts;
        private int _index = 0;

        public MainWindow()
        {
            InitializeComponent();
            codeTextBox.Text = new string(_inputCode); // char array omzetten naar een string
        }

        private void Restart()
        {
            _restAttempts = NumberOfAttempts;
            _index = 0;
            /*
            for (int i = 0; i < _inputCode.Length; i++)
            {
                _inputCode[i] = '*';
            }
            */
            //Array.Fill(_inputCode, '*');
            Array.ForEach(_inputCode, e => e = '*');
            codeTextBox.Text = new string(_inputCode);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Lees het cijfer uit overeenkomstige button
            string numberString = ((Button)sender).Content.ToString();
            int number = int.Parse(numberString);

            // Toon resultaat

            _inputCode[_index] = char.Parse(numberString); // String omzetten naar character
            //ingaveCode[index] = cijferStr[0]; // eerste char is genoeg
            codeTextBox.Text = new string(_inputCode); // char omzetten naar string

            if (number != _code[_index])
            {
                // Gegeven cijfer is fout
                _restAttempts--;
                if (_restAttempts != 0)
                {
                    MessageBox.Show($"Foute ingave, nog {_restAttempts} resterende pogingen");
                }
                else
                {
                    MessageBox.Show($"U heeft {NumberOfAttempts} fouten gemaakt, opnieuw beginnen");
                    Restart();
                }
            }
            else if (_index == _code.Length - 1)
            {
                // Cijfer is juist en laatste cijfer is bereikt, dus herstarten
                MessageBox.Show("Proficiat, u hebt de kluis geopend");
                Restart();
            }
            else
            {
                // Cijfer is juist, op naar volgende cijfer
                _index++;
            }
        }
    }
}
