using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Note_Index
{
    /// <summary>
    /// Interaction logic for ExitCnfrm.xaml
    /// </summary>
    public partial class ExitCnfrm : UserControl
    {
        public ExitCnfrm()
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

        private void ExitWnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Y)
            {
                QuitMsg = true;
            }
            if (e.Key == Key.Escape)
            {
                QuitMsg = false;
            }
            if(e.Key == Key.N)
            {
                QuitMsg = false;
            }
        }

        private void ExitWnd_Loaded(object sender, RoutedEventArgs e)
        {
            mnGrid.Focus();
        }
    }
}
