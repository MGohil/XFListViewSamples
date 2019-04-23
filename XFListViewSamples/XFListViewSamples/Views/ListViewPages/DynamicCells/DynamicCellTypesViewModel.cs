using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.DynamicCells
{
    public class DynamicCellTypesViewModel : BaseViewModel
    {
        public Action ScrollToBottomAction;
        public Command SendMessageCommand { get; }

        public ObservableCollection<ChatMessageModel> messages = new ObservableCollection<ChatMessageModel>();
        public ObservableCollection<ChatMessageModel> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }

        string textMessage = string.Empty;
        public string TextMessage
        {
            get { return textMessage; }
            set { SetProperty(ref textMessage, value); }
        }

        public DynamicCellTypesViewModel()
        {
            SendMessageCommand = new Command(() => { SendMessageCommandExecute(); });

            Task.Run(async () =>
            {
                var chatData = new ChatDataService();
                Messages = new ObservableCollection<ChatMessageModel>((await chatData.GetItemsAsync(1, 50)).ToList());
                ScrollToBottomAction?.Invoke();
            });
        }

        private void SendMessageCommandExecute()
        {
            Messages.Add(new ChatMessageModel()
            {
                Text = TextMessage,
                IsIncomingMessage = false,
                MessageDate = DateTime.Now,
                MessageType = 0,
                ProfilePic = "https://robohash.org/idquipariatur.png?size=100x100&set=set1"
            });

            ScrollToBottomAction?.Invoke();

            TextMessage = null;
        }
    }
}
