using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SuperPUBG.CS
{
    public class DiscordLoadViewModel : INotifyPropertyChanged
    {

        public DiscordLoadViewModel(ListView listview)
        {
            DiscordCommand = new AnotherCommandImplementation(_ =>
            {
                if (IsLoadComplete == true)
                {
                    IsLoadComplete = false;
                    return;
                }

                if (LoadProgress != 0) return;

                IsLoading = true;

                GetDiscord getDiscord = new GetDiscord();

                new DispatcherTimer(
                    TimeSpan.FromMilliseconds(50),
                    DispatcherPriority.Normal,
                    new EventHandler((o, e) =>
                    {
                        LoadProgress += 3;

                        if (LoadProgress >= 100)
                        {
                            listview.ItemsSource = getDiscord.GetDiscordList();

                            IsLoadComplete = true;

                            IsLoading = false;

                            LoadProgress = 0;

                            ((DispatcherTimer)o).Stop();

                        }

                    }), Dispatcher.CurrentDispatcher);
            });
        }

        #region Discord Floating

        public ICommand DiscordCommand { get; }

        private bool _isLoading;

        public bool IsLoading

        {

            get { return _isLoading; }

            private set { this.MutateVerbose(ref _isLoading, value, RaisePropertyChanged()); }

        }

        private bool _isLoadComplete;

        public bool IsLoadComplete

        {

            get { return _isLoadComplete; }

            private set { this.MutateVerbose(ref _isLoadComplete, value, RaisePropertyChanged()); }

        }



        private double _LoadProgress;

        public double LoadProgress

        {
            get { return _LoadProgress; }
            private set { this.MutateVerbose(ref _LoadProgress, value, RaisePropertyChanged()); }
        }

        #endregion

        private ObservableCollection<DiscordList> _discordlist;

        public ObservableCollection<DiscordList> DiscordLists
        {
            get { return _discordlist; }
            set { _discordlist = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}