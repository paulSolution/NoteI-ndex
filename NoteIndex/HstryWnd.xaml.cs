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

namespace Note_Index
{
    /// <summary>
    /// Interaction logic for HstryWnd.xaml
    /// </summary>
    public partial class HstryWnd : UserControl
    {
        public HstryWnd()
        {
            InitializeComponent();
        }

        private List<int> _info = new List<int>() { 0 };

        public List<int> Info { get { return _info; } set { _info.Clear(); _info = value; SetAllValue(); } }

        private void SetAllValue()
        {
            t2000.Text = _info[0].GetString();
            t500.Text = _info[1].GetString();
            t200.Text = _info[2].GetString();
            t100.Text = _info[3].GetString();
            t50.Text = _info[4].GetString();
            t20.Text = _info[5].GetString();
            t10.Text = _info[6].GetString();
            tCoin.Text = _info[7].GetString();

            r2000.Text = "= " + Calc.MultipliedValue(_info[0], NoteValue.nv2000).GetINRformat();
            r500.Text = "= " + Calc.MultipliedValue(_info[1], NoteValue.nv500).GetINRformat();
            r200.Text = "= " + Calc.MultipliedValue(_info[2], NoteValue.nv200).GetINRformat();
            r100.Text = "= " + Calc.MultipliedValue(_info[3], NoteValue.nv100).GetINRformat();
            r50.Text = "= " + Calc.MultipliedValue(_info[4], NoteValue.nv50).GetINRformat();
            r20.Text = "= " + Calc.MultipliedValue(_info[5], NoteValue.nv20).GetINRformat();
            r10.Text = "= " + Calc.MultipliedValue(_info[6], NoteValue.nv10).GetINRformat();
            rCoin.Text = "= " + Calc.MultipliedValue(_info[7], NoteValue.Coin).GetINRformat();

            ResultTB.Text = "Result = " + Calc.CalculateSum(_info).GetINRformat();
        }
    }
}
