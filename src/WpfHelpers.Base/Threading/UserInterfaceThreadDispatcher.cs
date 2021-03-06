﻿namespace WpfHelpers.Threading {
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;


    /// <summary>
    ///   Dispatches the specified delegates on the user interface thread after <see cref="Initialize" /> has been called from Application.Start
    /// </summary>
    public static class UserInterfaceThreadDispatcher {
#if NET45
        private static readonly bool IsDesignTime = DesignerProperties.GetIsInDesignMode(Application.Current.MainWindow);
#else
        private static readonly bool IsDesignTime = DesignerProperties.IsInDesignTool;
#endif
        private static Dispatcher UserInterfaceDispatcher;

        /// <summary>
        ///   Initializes the dispatcher helper - should be called in Application.Start
        /// </summary>
        public static void Initialize() {
            if (UserInterfaceDispatcher != null) {
                return;
            }

#if NET45
            UserInterfaceDispatcher = Application.Current.Dispatcher;
#else
            UserInterfaceDispatcher = Deployment.Current.Dispatcher;
#endif
        }


        /// <summary>
        ///   Checks whether an delegate can be executed directly
        /// </summary>
        /// <returns> </returns>
        public static bool CheckAccess() {
            if (IsDesignTime) {
                return true;
            }

            if (UserInterfaceDispatcher == null) {
                throw new InvalidOperationException("UI dispatcher has not been initialized - call Initialize method in Application.Start");
            }

            return UserInterfaceDispatcher.CheckAccess();
        }

        /// <summary>
        ///   Executes the specified delegate on the UI thread
        /// </summary>
        /// <param name="del"> </param>
        /// <param name="arguments"> </param>
        public static void ExecuteDelegate(Delegate del, params object[] arguments) {
            if (CheckAccess()) {
                del.DynamicInvoke(arguments);
            } else {
                UserInterfaceDispatcher.BeginInvoke(del, arguments);
            }
        }
    }
}