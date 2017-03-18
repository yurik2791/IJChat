using System;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
