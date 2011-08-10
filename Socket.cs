using System;

namespace QED2._02
{
	public class SocketInformation
	{
	}
	public enum AddressFamily
	{
		InterNetwork,
		InterNetworkV6,
		NetBios,
		Atm
	}
	public class SocketType
	{
	}
	public class ProtocolType
	{
	}
	public class EndPoint
	{
	}

	/*
	* You cannot use a Socket returned from Accept to accept any additional connections from the connection queue.
    * You cannot call Accept, Bind, Connect, Listen, Receive, or Send if the socket has been closed.
    * You must call Bind before you can call the Listen method.
    * You must call Listen before calling Accept.
    * Connect(string host, int port) can only be called if addressFamily is either InterNetwork or InterNetworkV6.
    * Connect cannot be called if Listen has been called.
    * You have to either call Connect or Accept before Sending and Receiving data.
    * If the socket has been previously disconnected, then you cannot use Connect to restore the connection.
	*/
    public class Socket : IDisposable
	{
		public Socket(SocketInformation socketInformation) { }
		public Socket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType) { }

		public Socket Accept() { return null; }
		public void Bind(EndPoint localEP) { }
		public void Connect(EndPoint remoteEP) { }
		public void Connect(string host, int port) { }
		public void Dispose() { }
		public void Listen(int backlog) { }
		public int Receive(byte[] buffer) { return 0; }
		public int Send(byte[] buffer) { return 0; }
	}
}
