using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFListViewSamples.Models
{
    public class ChatMessageModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("message_date")]
        public DateTime MessageDate { get; set; }
        [JsonProperty("message_type")]
        public MessageType MessageType { get; set; } //Text, Image
        [JsonProperty("is_incoming_message")]
        public bool IsIncomingMessage { get; set; }
        [JsonProperty("attachment_url")]
        public string AttachmentURL { get; set; }
        [JsonProperty("profile_pic")]
        public string ProfilePic { get; set; }
    }

    public enum MessageType
    {
        Text,
        Image
    }
}
