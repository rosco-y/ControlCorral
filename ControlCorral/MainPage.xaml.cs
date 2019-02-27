using System;
using System.Collections.Generic;
using System.Linq;
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
        List<string> _usuals = new List<string>();

        #region CONSTRUCTION

        public MainPage()
        {
            this.InitializeComponent();
            _reservations = new List<ReservationInfo>();
            _command = new GenericCommand();
            Loaded += MainPage_Loaded;
            _command.DoSomething += _command_DoSomething;
            control_name.QuerySubmitted += Control_name_QuerySubmitted;
            control_name.TextChanged += Control_name_TextChanged;
            control_name.SuggestionChosen += Control_name_SuggestionChosen;
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _command;
            _usuals = new List<string> { "alex", "azuka", "elizabeth", "ahmed", "josh", "allan",
            "john", "david", "chris", "jack", "bobby", "ike", "emeka", "tobe", "chidi", "mason",
            "andrew" };

        }

        #endregion

        async void _command_DoSomething(string command)
        {
            MessageDialog md = null;
            if (control_calendar.Date == null)
            {
                // calendar is null
                md = new MessageDialog("Select a day first.");
                await md.ShowAsync();
                return;
            }
            else
            {
                if (control_time.Time > TimeSpan.MinValue)
                {
                    md = new MessageDialog("Must set a time first.");
                    await md.ShowAsync();
                    return;
                }
                else
                {

                    ReservationInfo new_reservation;
                    new_reservation = new ReservationInfo()
                    {
                        AppointmentDay = control_calendar.Date.Value.Date,
                        AppointmentTime = control_time.Time,
                        CustomerName = control_name.Text,
                        DOB = control_dob.Date.Date,
                        HasPaid = false,
                    };
                    _reservations.Add(new_reservation);
                    if (command.ToLower() == "make a reservation")
                    {

                        md = new MessageDialog(successMessage(new_reservation, "confirmed"));
                    }
                    else
                    {
                        if (command.ToLower() == "hold my spot")
                        {
                            md = new MessageDialog(successMessage(new_reservation, "tentative"));
                        }
                    }
                    if (md != null)
                    {
                        await md.ShowAsync();
                        clearControls();
                    }
                }
            }
        } //DoSomething

        void clearControls()
        {
            control_calendar.Date = null;
            control_time.Time = TimeSpan.MinValue;

        }

        string successMessage(ReservationInfo new_reservation, string reservation_tag = "")
        {
            DateTime date = new_reservation.AppointmentDay;
            return $"{_reservations.Count} massages reserved. " + Environment.NewLine +
                $"Newest is {reservation_tag} on {date.Month}/{date.Day}/{date.Year} at { new_reservation.AppointmentTime}" +
                $" For {new_reservation.CustomerName}";
        }

        #region AutoSuggestBox

        void Control_name_SuggestionChosen(AutoSuggestBox sender,
            AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            control_name.Text = args.SelectedItem as string;
        }

        void Control_name_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.CheckCurrent())
            {
                string search_term = control_name.Text.ToLower();
                List<string> results = _usuals.
                    Where(i => i.Contains(search_term.ToLower())).ToList();
                control_name.ItemsSource = results;
            }
        }

        void Control_name_QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string search_term = args.QueryText.ToLower();
            List<string> results = _usuals.
                Where(i => i.Contains(search_term.ToLower())).ToList();
            control_name.ItemsSource = results;
            control_name.IsSuggestionListOpen = true;
        }
        #endregion

    } //MainPage Class

}// ControlCorral Namespace
