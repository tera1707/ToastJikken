using Microsoft.Toolkit.Uwp.Notifications;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;
using Windows.Foundation.Collections;

namespace ToastJp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Obtain the arguments from the notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);

                // Obtain any user input (text boxes, menu selections) from the notification
                ValueSet userInput = toastArgs.UserInput;

                // Need to dispatch to UI thread if performing UI operations
                Application.Current.Dispatcher.Invoke(delegate
                {
                    // TODO: Show the corresponding content
                    MessageBox.Show("日本語トースト押されました");
                });
            };

            new ToastContentBuilder()
                .AddText("日本語のトーストです。.")
                .AddText("AssemblyName を分けたら、一応できます。")
                .Show();

            Debug.WriteLine("終わり");

            this.Shutdown();
        }
    }

}
