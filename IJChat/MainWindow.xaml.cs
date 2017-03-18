using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows;
using System.Windows.Documents;
using Helper;

namespace IJChat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			new Thread(UpdateUsers).Start();
			new Thread(UpdateChat).Start();
		}

		private void UpdateUsers()
		{
			while (true)
			{
				var tcpClient = new TcpClient(@"192.168.2.94", 7777);
				var stream = tcpClient.GetStream();
				IFormatter formatter = new BinaryFormatter();
				var Users = formatter.Deserialize(stream) as Dictionary<string, string>;
				listView.Dispatcher.Invoke(() =>
				{
					listView.ItemsSource = Users?.Select((t) => t.Key);
					tcpClient.Close();
					Thread.Sleep(1000);

				});
			}
		}

		private void UpdateChat()
		{
			
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var text = new TextRange(rtb_two.Document.ContentStart, rtb_two.Document.ContentEnd).Text;
			var from = "Iura";
			var to = "Stepan";
			var msg= new Message(text,DateTime.Now, from,to);

			var tcpClient = new TcpClient(@"192.168.2.94",4444);
			IFormatter formater = new BinaryFormatter();
			var stream = tcpClient.GetStream();
			formater.Serialize(stream, msg);  
		}
	}
}
