using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            Loaded += MainPage_Loaded;
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
                ReservationInfo new_reservation;
                if (control_calendar.Date != null)
                {

                    new_reservation = new ReservationInfo()
                    {
                        AppointmentDay = control_calendar.Date.Value.Date,
                        AppointmentTime = control_time.Time,
                    };

                    _reservations.Add(new_reservation);
                    MessageDialog md =
                    new MessageDialog(successMessage(new_reservation));
                    await md.ShowAsync();
                    control_calendar.Date = null;                     
                }
                else
                {
                    MessageDialog md =
                        new MessageDialog("Select a day first");
                    await md.ShowAsync();
                }
            }

        }

        string successMessage(ReservationInfo new_reservation)
        {
            DateTime date = new_reservation.AppointmentDay;
            return $"{_reservations.Count} massages reserved. " + Environment.NewLine + 
                $"Newest is on {date.Month}/{date.Day}/{date.Year} at { new_reservation.AppointmentTime}";

            
        }

    } // class
}
