using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace Note_Index
{
    /// <summary>
    /// Interaction logic for ViewHstry.xaml
    /// </summary>
    public partial class HstryList : UserControl
    {
        public HstryList()
        {
            InitializeComponent();
        }

        private bool _quitMsg = false;
        private string _uid = "";

        /// <summary>
        /// Rais on QuitMsg changed manualy
        /// </summary>
        public event PropertyChangedEventHandler QuitMsgChanged;

        private protected void OnQuitMsgChanged(PropertyChangedEventArgs e)
        {
            QuitMsgChanged?.Invoke(this, e);
        }

        /// <summary>
        /// A Message sent to the base Window to Close this UserCntrol
        /// if Msg is true UserCntrol will be Close
        /// </summary>
        public bool QuitMsg
        {
            get { return _quitMsg; }
            set
            {
                _quitMsg = value;
                OnQuitMsgChanged(new PropertyChangedEventArgs("QuitMsg"));
            }
        }

        /// <summary>
        /// Returns the Note index Unique ID to find the IndexInformation
        /// </summary>
        public string IndexUniqueID { get { return _uid; } }

        HstryWnd hstryWnd;

        private void HstryView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CntnrGrid.Children.Count == 0)
            {
                if (e.Key == Key.Escape)
                {
                    QuitMsg = true;
                }
                if (e.Key == Key.Enter)
                {
                    hstryWnd = new HstryWnd();
                    hstryWnd.Info = DataHistory.SaveDataHstry.GetIndexInformation(hstryList.SelectedIndex);
                    hstryWnd.WndTitle.Text = this.hstryList.SelectedItem.ToString();
                    CntnrGrid.Children.Add(hstryWnd);
                    hstryWnd.Focus();
                }
            }
            else
            {
                CntnrGrid.Children.Clear();
                hstryList.SelectedIndex = hstryList.SelectedIndex;
                hstryList.Focus();
            }
        }

        private void hstryList_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            hstryList.SelectedIndex = 0;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            QuitMsg = true;
        }

        private void HstryListView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            hstryList.Focus();
            SendKeys.Send(Key.Space);
        }
    }
}
