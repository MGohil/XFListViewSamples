using Xamarin.Forms;
using XFListViewSamples.Models;

namespace XFListViewSamples.Views.ListViewPages.DynamicCells
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        public ChatDataTemplateSelector()
        {
            this._inTextMessageDataTemplate = new DataTemplate(typeof(InTextMessageViewCell));
            this._outTextMessageDataTemplate = new DataTemplate(typeof(OutTextMessageViewCell));
            this._inImageDataTemplate = new DataTemplate(typeof(InImageViewCell));
            this._outImageDataTemplate = new DataTemplate(typeof(OutImageViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as ChatMessageModel;
            if (message == null)
                return null;

            if (message.IsIncomingMessage)
            {
                if (message.MessageType == MessageType.Text) return this._inTextMessageDataTemplate;
                if (message.MessageType == MessageType.Image) return this._inImageDataTemplate;
            }
            else
            {
                if (message.MessageType == MessageType.Text) return this._outTextMessageDataTemplate;
                if (message.MessageType == MessageType.Image) return this._outImageDataTemplate;
            }
            return null;
        }

        private readonly DataTemplate _inTextMessageDataTemplate;
        private readonly DataTemplate _outTextMessageDataTemplate;

        private readonly DataTemplate _inImageDataTemplate;
        private readonly DataTemplate _outImageDataTemplate;
    }
}
