using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using BB.Poker.WinFormsClient.Properties;
using BB.Poker.Common;

namespace BB.Poker.WinFormsClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            //-- An alternative method for catching unhandled exceptions (also rather flakey)..
            //AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            //Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Control.CheckForIllegalCrossThreadCalls = true;
            Application.DoEvents();

            ApplicationManager applicationManager = new ApplicationManager();
            applicationManager.Run(args);
        }

        //-- This is terrible..
        //-- I don't think this is correct at all, the UnhandledException doesn't get fired
        //-- when the exception occurs on threads not beloning to the MainForm or some shit like that..
        internal class ApplicationManager : WindowsFormsApplicationBase
        {
            private Logger AppLog;
            private GameClientModuleHost App;

            public ApplicationManager()
            {
                base.IsSingleInstance = true;
            }

            protected override bool OnStartup(StartupEventArgs eventArgs)
            {
                AppLog = new Logger(System.IO.Path.Combine(Application.StartupPath, "ClientLog.txt"));
                App = new GameClientModuleHost(new MetroClientForm(), AppLog);
                MetroMessageBox.SetOwner(App.UI.GetForm());
                Application.Run();

                return false;
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                base.OnStartupNextInstance(eventArgs);
                try
                {
                    if (!App.UI.Visible)
                    {
                        App.UI.Visible = true;
                    }
                    if (App.UI.WindowState == FormWindowState.Minimized)
                    {
                        App.UI.WindowState = FormWindowState.Normal;
                    }

                    App.UI.Activate();
                    App.UI.Focus();
                }
                catch
                {
                }
            }

            protected override bool OnUnhandledException(Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
            {
                AppLog.WriteLine(e.Exception);

                MetroMessageBox.Show(e.Exception.Message); 
               
                return true;
            }
        }
    }
}
