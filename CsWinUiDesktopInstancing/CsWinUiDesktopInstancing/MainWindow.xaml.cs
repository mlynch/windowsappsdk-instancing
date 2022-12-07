// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.UI.Xaml;
using System.Diagnostics;

namespace CsWinUiDesktopInstancing
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "CsWinUiDesktopInstancing";

            if (Program.OutputStack != null && Program.OutputStack.Count > 0)
            {
                foreach (string message in Program.OutputStack)
                {
                    OutputMessage(message);
                }
                Program.OutputStack.Clear();
            }
        }

        public void OutputMessage(string message)
        {
            DispatcherQueue.TryEnqueue(() =>
            {
                StatusListView.Items.Add(message);
                Debug.WriteLine($"\n\nMESSAGE: {message}");
            });
        }

        private void ActivationInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Program.GetActivationInfo();
        }
    }
}
