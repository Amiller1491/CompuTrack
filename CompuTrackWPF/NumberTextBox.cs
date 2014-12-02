using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CompuTrackWPF
{
    class NumberTextBox : TextBox
    {

        public NumberTextBox()
        {   
            
        }

        protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
        {
            e.Handled = true;
            base.OnPreviewMouseRightButtonUp(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            e.Handled = !NoTomFoolery(e.Key);
            base.OnPreviewKeyDown(e);
        }

        private bool NoTomFoolery(Key k)
        {
            if (k == Key.NumPad0 || k == Key.NumPad0 || k == Key.NumPad1 || k == Key.NumPad2 || k == Key.NumPad3 || k == Key.NumPad4 || k == Key.Tab
                || k == Key.NumPad5 || k == Key.NumPad6 || k == Key.NumPad7 || k == Key.NumPad8 || k == Key.NumPad0 || k == Key.D0
                || k == Key.D1 || k == Key.D2 || k == Key.D3 || k == Key.D4 || k == Key.D5 || k == Key.D6 || k == Key.D7 || k == Key.Return
                || k == Key.D8 || k == Key.D9 || k == Key.Back || k == Key.Delete || k == Key.Right || k == Key.Left || k == Key.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
