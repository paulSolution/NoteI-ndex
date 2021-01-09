using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using DataHistory;
using System.Windows.Media.Effects;
using System.Linq;
using System;

namespace Note_Index
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWnd : Window
    {
        public MainWnd()
        {
            InitializeComponent();
        }

        private void WndTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimizBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CreateIndexList();
            if (!noteIndexList.TrueForAll(S => S == 0))
            {
                saveData.SaveIndexInfo(noteIndexList);
                ClearAll();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }


        private void TxtChanged2000(object sender, TextChangedEventArgs e)
        {
            if ((tb2000.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb2000.Text);
                r_2000.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv2000).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged500(object sender, TextChangedEventArgs e)
        {
            if ((tb500.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb500.Text);
                r_500.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv500).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged200(object sender, TextChangedEventArgs e)
        {
            if ((tb200.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb200.Text);
                r_200.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv200).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged100(object sender, TextChangedEventArgs e)
        {
            if ((tb100.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb100.Text);
                r_100.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv100).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged50(object sender, TextChangedEventArgs e)
        {
            if ((tb50.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb50.Text);
                r_50.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv50).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged20(object sender, TextChangedEventArgs e)
        {
            if ((tb20.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb20.Text);
                r_20.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv20).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged10(object sender, TextChangedEventArgs e)
        {
            if ((tb10.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tb10.Text);
                r_10.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.nv10).GetINRformat();
                CalculateTotal();
            }
        }

        private void TxtChanged_Coin(object sender, TextChangedEventArgs e)
        {
            if ((tbCoin.Text).All(char.IsDigit))
            {
                var tmp = Calc.GetInt(tbCoin.Text);
                r_Coin.Text = "=  " + Calc.MultipliedValue(tmp, NoteValue.Coin).GetINRformat();
                CalculateTotal();
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateIndexList();
            if (!noteIndexList.TrueForAll(S => S == 0))
            {
                saveData.SaveIndexInfo(noteIndexList);
                ClearAll();
            }
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WndContainer.Children.Count < 1)
            {
                ActivationBlurEffect(true);
                WndBody.IsEnabled = false;
                LastFocus = (UIElement)FocusManager.GetFocusedElement(this);

                ShowHstryList();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && WndContainer.Children.Count < 1)
            {
                ActivationBlurEffect(true);
                WndBody.IsEnabled = false;
                LastFocus = (UIElement)FocusManager.GetFocusedElement(this);

                // Add Exit Window to this
                ShowExitWnd();               
            }
            if(e.Key == Key.C)
            {
                CreateIndexList();
                if (!noteIndexList.TrueForAll(S => S == 0))
                {
                    saveData.SaveIndexInfo(noteIndexList);
                    ClearAll();
                }
            }
            if(e.Key == Key.M)
            {
                if (WndContainer.Children.Count < 1)
                {
                    ActivationBlurEffect(true);
                    WndBody.IsEnabled = false;
                    LastFocus = (UIElement)FocusManager.GetFocusedElement(this);

                    //Add Histry Window To this
                    ShowHstryList();                   
                }
            }
        }

       

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
                GoNext();

            if (e.Key == Key.Up)
                GoPrevious();

            if (e.Key == Key.Enter)
                GoNext();
        }

        private void PreviewTextInputValidate(object sender, TextCompositionEventArgs e)
        {
           if(!e.Text.All(char.IsDigit))
            {
                e.Handled = true;
            }
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {
            ActivationBlurEffect(true);
            WndBody.IsEnabled = false;
            LastFocus = (UIElement)FocusManager.GetFocusedElement(this);

            ShowSettingsWnd();
        }
    }
}
