using System;

namespace IJChat
{
	[Serializable]
	public class Message
	{
		public string Text;
		public string From;
		public string To;
		public DateTime TimeStamp;

		public Message(string text, string from, string to)
		{
			Text = text;
			From = from;
			To = to;
		}
	}
}
