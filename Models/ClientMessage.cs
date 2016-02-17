using System;

namespace WinChat
{
    public class ClientMessage
    {
        public string Token { get; set; }
        public string Text { get; set; }
        public DateTime DT { get; set; }
        public int LastMessageID { get; set; }
    }
}
