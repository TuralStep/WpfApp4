using System;

namespace WpfApp4;


public class Message
{

    public string Text { get; set; }
    public string SentTimeStr { get; set; }
    private DateTime SentTime { get; set; }

    public Message(string text, DateTime sentTime)
    {
        Text = text;
        SentTime = sentTime;
        SentTimeStr = $"   {SentTime.ToShortTimeString()}";
    }
}