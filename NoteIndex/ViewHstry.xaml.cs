using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace Note_Index
{
    /// <summary>
    /// Interaction logic for ViewHstry.xaml
    /// </summary>
    public partial class ViewHstry : UserControl
    {
        public ViewHstry()
        {
            InitializeComponent();
        }

        private bool _quitMsg = false;

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

        private void HstryView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                QuitMsg = true;
            }
            if(e.Key == Key.Enter)
            {

            }
        }

        private void hstryList_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            hstryList.Focus();
            hstryList.SelectedIndex = 0;
        }
    }
}
