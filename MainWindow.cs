// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThicknessConverter
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Transactions
        {

            public string BorderText()
            {
                string Text = "Border.BorderThickness =";
                return Text;
            }

            public string BorderText2()
            {
                string Text = "Border.Borderbrush =";
                return Text;
            }
        }


        public interface IStart
        {
            string Start();
        }

        public class ChangeThickness : IStart
        {
            private Transactions transactions;

            public ChangeThickness(Transactions transactions)
            {
                this.transactions = transactions;
            }

            public string Start()
            {
                return transactions.BorderText();
            }
        }

        public class ChangeColor : IStart
        {
            private Transactions transactions;

            public ChangeColor(Transactions transactions)
            {
                this.transactions = transactions;
            }

            public string Start()
            {
                return transactions.BorderText2();
            }

        }

        public class CommandReceiver
        {
            public string value { get; set; }
            public string Start(IStart start)
            {
                value = start.Start();
                return value;
            }

        }

        ChangeThickness chngThc = new ChangeThickness(new Transactions());

        ChangeColor chngclr = new ChangeColor(new Transactions());

        CommandReceiver cRcvr = new CommandReceiver();

        private void Change_Thickness(object sender, SelectionChangedEventArgs args)
        {
            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var myThicknessConverter = new System.Windows.ThicknessConverter();
            var th1 = (Thickness)myThicknessConverter.ConvertFromString(li.Content.ToString());
            border1.BorderThickness = th1;
            bThickness.Text = cRcvr.Start(chngThc) + li.Content;
        }

        private void ChangeColor_(object sender, SelectionChangedEventArgs args)
        {
            var li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            var myBrushConverter = new BrushConverter();
            border1.BorderBrush = (Brush)myBrushConverter.ConvertFromString((string)li2.Content);
            bColor.Text = cRcvr.Start(chngclr) + li2.Content;
        }

        #region OldCodes
        /*private void ChangeThickness(object sender, SelectionChangedEventArgs args)
        {
            var li = ((sender as ListBox).SelectedItem as ListBoxItem);
            var myThicknessConverter = new System.Windows.ThicknessConverter();
            var th1 = (Thickness) myThicknessConverter.ConvertFromString(li.Content.ToString());
            border1.BorderThickness = th1;
            bThickness.Text = "Border.BorderThickness =" + li.Content;
        }
        

        private void ChangeColor(object sender, SelectionChangedEventArgs args)
        {
            var li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            var myBrushConverter = new BrushConverter();
            border1.BorderBrush = (Brush) myBrushConverter.ConvertFromString((string) li2.Content);
            bColor.Text = "Border.Borderbrush =" + li2.Content;
        }
        */
        #endregion

    }
}