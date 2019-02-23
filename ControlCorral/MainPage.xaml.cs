using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ControlCorral
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<ReservationInfo> _reservations;
        GenericCommand _command;
        public MainPage()
        {
            this.InitializeComponent();
            _reservations = new List<ReservationInfo>();
            _command = new GenericCommand();
            _command.DoSomething += _command_DoSomething;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _command;
        }

        async private void _command_DoSomething(string command)
        {
            if (command.ToLower() == "make a reservation")
            {
                var new_reservation = new ReservationInfo();
                _reservations.Add(new_reservation);
                MessageDialog md =
                new MessageDialog($"{_reservations.Count} massages reserved");
                await md.ShowAsync();
            }
        }

        private void ReserveMassage(object sender, RoutedEventArgs e)
        {

        }
    }
}
