using System;
using System.Collections.Generic;
using System.Linq;
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
using altnet.codingdojo.fizzbuzz.contract;

namespace altnet.codingdojo.fizzbuzz.gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            lbxResult.Items.Clear();

            IFizzBuzzService fizzBuzzService=App.Container.Resolve<IFizzBuzzService>();
            uint maxValue;
            if (!uint.TryParse(txtMaxValue.Text, out maxValue) || maxValue > 100)
            {
                MessageBox.Show("Nur ganze Zahlen von 0 bis 100 erlaubt");
                return;
            }

            var resultList = fizzBuzzService.GetFizzBuzzEnumBy(maxValue);
            resultList.ToList().ForEach(i => lbxResult.Items.Add(i));
        }
    }
}
