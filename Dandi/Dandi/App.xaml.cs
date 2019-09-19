﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BIND.Core.Login;
using Dandi.Common;
using Dandi.ViewModel;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Login
        public static LoginData loginData = new LoginData();

        // AutoLogin
        public App()
        {
            Setting.Load();
        }

        // EventControl
        public static ChannelEventViewModel eventViewModel = new ChannelEventViewModel();

        // JoinedChannelViewModel
        public static JoinedChannelViewModel joinedChannelViewModel = new JoinedChannelViewModel();
    }
}