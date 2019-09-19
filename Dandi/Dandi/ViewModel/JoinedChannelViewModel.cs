﻿using Dandi.Model;
using Dandi.Service.Response;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TNetwork;
using TNetwork.Data;

namespace Dandi.ViewModel
{
    public class JoinedChannelViewModel : BindableBase
    {
        private List<JoinedChannel> _joinedChannelItems = new List<JoinedChannel>();

        public List<JoinedChannel> JoinedChannelItems
        {
            get => _joinedChannelItems;
            set
            {
                SetProperty(ref _joinedChannelItems, value);
            }
        }


        private ObservableCollection<ChannelEvent> _channelEventItems = new ObservableCollection<ChannelEvent>();
        public ObservableCollection<ChannelEvent> ChannelEventItems
        {
            get => _channelEventItems;
            set => SetProperty(ref _channelEventItems, value);
        }


        public NetworkManager networkManager = new NetworkManager();

        public async Task SetJoinedChannelList()
        {
            TResponse<JoinedChannelResponse> resp;

            resp = await networkManager.GetResponse<JoinedChannelResponse>("channel", Method.GET, null);

            if (resp != null && resp.Status == 200 && resp.Data != null)
            {
                try
                {
                    foreach (var item in resp.Data.JoinedChannel)
                    {
                        JoinedChannelItems.Add((JoinedChannel)item.Clone());
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("JoinedChannelEvent LoadDataAsync ERROR : " + e.Message);
                }
            }

            for(int i = 0; i < JoinedChannelItems.Count; i++)
            {
                var res = await networkManager.GetResponse<ChannelEventResponse>("channel-event?channel_id=" + JoinedChannelItems[i].Id, Method.GET, null);
            }

            //JoinedChannelItems.ForEach(async x =>
            //{
            //    await networkManager.GetResponse<JoinedChannelResponse>("channel-event?" + x.Id, Method.GET, null);
            //});
        }
    }
}