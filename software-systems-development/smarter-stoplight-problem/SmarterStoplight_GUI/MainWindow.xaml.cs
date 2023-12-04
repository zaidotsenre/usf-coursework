//
// COP 4365 – Fall 2022
//
// Homework #2: A Smarter Stoplight Problem
//
// Description: Entry point and logic of the GUI version of the program. Code behind for Main WIndow
//
// File name: MainWindow.xaml.cs
//
// By: Ernesto Diaz
//
//

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using SmarterStoplight_ClassLibrary;

namespace SmarterStoplight_GUI
{
    public partial class MainWindow : Window
    {

        StoplightController controller = new StoplightController();
        int threeSecondCounter = 0;
        int timeElapsed = 0;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        List<Canvas[]> lights = new List<Canvas[]>();

        public MainWindow()
        {
            InitializeComponent();

            lights.Add(new Canvas[] { northRedBulb, northYellowBulb, northGreenBulb });
            lights.Add(new Canvas[] { southRedBulb, southYellowBulb, southGreenBulb });
            lights.Add(new Canvas[] { eastRedBulb, eastYellowBulb, eastGreenBulb });
            lights.Add(new Canvas[] { westRedBulb, westYellowBulb, westGreenBulb });

            UpdateLightGUI();

            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += UpdateController;
            dispatcherTimer.Start();
        }

        //
        // Method Name: UpdateController
        // Description: Updates the StoplightController when it's time to
        private void UpdateController(object sender, EventArgs e)
        {
            // Update timers and counters
            timeElapsed++;
            if (timeElapsed % 3 == 0 && !controller.Emergency)
            {
                threeSecondCounter++;
                if (threeSecondCounter > 5)
                {
                    threeSecondCounter = 0;
                }

                // dont update controller, gotta let this light go longer
                if (threeSecondCounter == 1)
                {
                    return;
                }
                controller.NextState();
            }

            TimeSpan ts = TimeSpan.FromSeconds(timeElapsed);
            timerLBL.Content = ts.ToString();
            UpdateLightGUI();
        }

        //
        // Method Name: UpdateLightGUI
        // Description: Code behind for the lights GUI (sets the GUI to the right colors)
        private void UpdateLightGUI()
        {
            for(int i = 0; i < 4; i++)
            {
                switch (controller.Stoplights[i].State)
                {
                    case StoplightState.Red:
                        lights[i][0].Background = Brushes.Red;
                        lights[i][1].Background = Brushes.Gray;
                        lights[i][2].Background = Brushes.Gray;
                        break;
                    case StoplightState.Yellow:
                        lights[i][0].Background = Brushes.Gray;
                        lights[i][1].Background = Brushes.Yellow;
                        lights[i][2].Background = Brushes.Gray;
                        break;
                    case StoplightState.Green:
                        lights[i][0].Background = Brushes.Gray;
                        lights[i][1].Background = Brushes.Gray;
                        lights[i][2].Background = Brushes.Green;
                        break;
                }
            }
        }

        //
        // Method Name: StartEmergency
        // Description: Code behind for the start emergency button
        private void StartEmergency(object sender, RoutedEventArgs e)
        {
            controller.StartEmergencyAlert("East");
            UpdateLightGUI();
            stopEmergencyBtn.IsEnabled = true;
            startEmergencyBtn.IsEnabled = false;
        }

        //
        // Method Name: StopEmergency
        // Description: Code behind for the stop emergency button
        private void StopEmergency(object sender, RoutedEventArgs e)
        {
            controller.StopEmergencyAlert();
            UpdateLightGUI();
            stopEmergencyBtn.IsEnabled = false;
            startEmergencyBtn.IsEnabled = true;
        }
    }
}
