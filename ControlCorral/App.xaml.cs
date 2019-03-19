using System;
using System.Collections.Generic;
using System.Linq;
using ControlCorral.Model;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ControlCorral
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /public static ControlCorralModel Model { get; set; }
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /*
        /// <summary>
        /// Alternate OnLaunched() method, examplifying that the Window.Current.Content can
        /// be set to an aribtrary control, although this is very discouraged and it's highly
        /// recommended that the Content of the Window object be set to a frame object, as this
        /// allows the default Navigation system to work.  Frames can only contain Pages and 
        /// are designed this way to so that they can maintain a History of Pages visited, and 
        /// then can use thier GoBack() and GoForward() and related properties and events 
        /// (to see if it is possible to go back or go forward.) See Pg 63-64 for related information 
        /// on the Frame.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Window.Current.Content = new Button()
            {
                Content = "This button is the root content for this application's Window.",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            Window.Current.Activate();
        }


        //*/
        //*
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            createModelAndData();

            if (!(Window.Current.Content is Frame rootFrame))
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);

                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }
        //*/

        void createModelAndData()
        {
            Model = new ControlCorralModel();
            Model.MassageTypes.AddRange(
            new List<string>
            {
            "Swedish","Hot Stone",
            "Shiatsu","Deep Tissue",
            "Trigger Point","Thai",
            }.Select(i => new MassageTypes
            {
                Name = i,
            }).ToList());

            Model.Customers.AddRange(
                new List<string>
                {
                   "Emma",
                    "Jon",
                    "Julia",
                    "Margaret",
                    "Mary",
                    "Pat",
                }.Select(i=> new CustomerInfo
                {
                    CustomerName = i,
                }).ToList());
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            SuspendingDeferral deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
