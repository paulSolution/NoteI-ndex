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
    public partial class MainWnd : Window
    {
        private BlurEffect blurEffect;

        /// <summary>
        /// History View UserControl Instance
        /// </summary>
        private HstryList hstry;
        private ExitCnfrm exitWnd;
        private SettingsWnd settingsWnd;

        private SaveDataHstry saveData = new SaveDataHstry("DataHstry.xml");

        // List Of The Note Denominatio
        private List<int> noteIndexList = new List<int> { 0 };

        // Imports all Note Denominatio Index in a List
        private void CreateIndexList()
        {
            noteIndexList.Clear();
            noteIndexList = new List<int>
            {
                Calc.GetInt(tb2000.Text),
                Calc.GetInt(tb500.Text),
                Calc.GetInt(tb200.Text),
                Calc.GetInt(tb100.Text),
                Calc.GetInt(tb50.Text),
                Calc.GetInt(tb20.Text),
                Calc.GetInt(tb10.Text),
                Calc.GetInt(tbCoin.Text)
            };
        }

        // Clear All Local Values and Reset to the Initial Position
        private void ClearAll()
        {
            tb2000.Text = tb500.Text = tb200.Text
                = tb100.Text = tb50.Text = tb20.Text
                = tb10.Text = tbCoin.Text = "";

            Total_Sum.Text = "Result =  ";

            r_2000.Text = r_500.Text = r_200.Text
                = r_100.Text = r_50.Text = r_20.Text
                = r_10.Text = r_Coin.Text = "=  ";

            tb2000.Focus();
        }

        /// <summary>
        /// Transfer the focus to the next focusable item
        /// </summary>
        private void GoNext()
        {
            System.Windows.Controls.Control element = Keyboard.FocusedElement as System.Windows.Controls.Control;

            if (element.TabIndex == 7)
                Keyboard.Focus(tb2000);
            else
                element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        /// <summary>
        /// Transfer the focus to the previous focuasable item
        /// </summary>
        private void GoPrevious()
        {
            Control element = Keyboard.FocusedElement as Control;
            if (element.TabIndex == 0)
                Keyboard.Focus(tbCoin);
            else
                element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
        }

        /// <summary>
        /// Calculates The Total SUM Amount
        /// </summary>
        private void CalculateTotal()
        {
            CreateIndexList();
            Total_Sum.Text = "Result =  " + Calc.CalculateSum(noteIndexList).GetINRformat();
        }


        private UIElement LastFocusUI = null;

        private void ActivationBlurEffect(bool activate)
        {
            if (activate)
            {
                if (blurEffect != null)
                    blurEffect.Radius = 12;
                else
                {
                    blurEffect = WndBody.Effect as BlurEffect;
                    blurEffect.Radius = 12;
                }
            }
            else
            {
                if (blurEffect != null)
                    blurEffect.Radius = 0;
                else
                {
                    blurEffect = WndBody.Effect as BlurEffect;
                    blurEffect.Radius = 0;
                }
            }
        }

        private void Hstry_QuitMsgChanged(object sender, PropertyChangedEventArgs e)
        {
            if (hstry.QuitMsg == true)
            {
                WndContainer.Children.Remove(hstry);
                ActivationBlurEffect(false);
                WndBody.IsEnabled = true;
                LastFocus.Focus();
            }
        }


        private void ExitWnd_QuitMsgChanged(object sender, PropertyChangedEventArgs e)
        {
            if (exitWnd.QuitMsg)
            {
                WndContainer.Children.Remove(exitWnd);
                this.Close();
            }
            else
            {
                WndContainer.Children.Remove(exitWnd);
                ActivationBlurEffect(false);
                WndBody.IsEnabled = true;
                LastFocus.Focus();
            }
        }

        private void AddItemToHstryLisl()
        {
            var tmp = saveData.GetAllIndexList();

            for (int i = tmp.Count - 1; i >= 0; i--)
                hstry.hstryList.Items.Add(tmp[i]);
        }

        private IInputElement _lastFocus;

        private UIElement LastFocus
        {
            get { return (UIElement)_lastFocus; }
            set { _lastFocus = (IInputElement)value; }
        }

        private void ShowExitWnd()
        {
            exitWnd = new ExitCnfrm();
            exitWnd.QuitMsgChanged += ExitWnd_QuitMsgChanged;
            WndContainer.Children.Add(exitWnd);
            exitWnd.Focus();
        }

        private void ShowHstryList()
        {
            hstry = new HstryList();
            hstry.QuitMsgChanged += Hstry_QuitMsgChanged;
            AddItemToHstryLisl();
            WndContainer.Children.Add(hstry);
        }

        private void ShowSettingsWnd()
        {
            settingsWnd = new SettingsWnd();
            settingsWnd.QuitMsgChanged += SettingsWnd_QuitMsgChanged;
            WndContainer.Children.Add(settingsWnd);
            settingsWnd.Focus();

        }

        private void SettingsWnd_QuitMsgChanged(object sender, PropertyChangedEventArgs e)
        {
            if(settingsWnd.QuitMsg == true)
            {
                WndContainer.Children.Remove(settingsWnd);
                ActivationBlurEffect(false);
                WndBody.IsEnabled = true;
                LastFocus.Focus();
            }
        }
    }
}
