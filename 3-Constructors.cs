using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvableCode.Patterns
{
    public static class Example3
    {
        /*
        * You must call Bind before you can call Listen.
        * You may call Bind only once.
        */
        public class Socket
        {
            public Socket() { }

            public void Bind(EndPoint localEP) { }
            public void Listen(int backlog) { }
        }

        public static void Right()
        {
            var socket = new Socket();
            socket.Bind(new EndPoint());
            socket.Listen(1000);
        }

        public static void Wrong1()
        {
            var socket = new Socket();
            // Forgot to call Bind.
            socket.Listen(1000);
        }

        public static void Wrong2()
        {
            var socket = new Socket();
            socket.Bind(new EndPoint());
            socket.Listen(1000);
            socket.Bind(new EndPoint());
            // Called Bind more than once.
        }

        public class EndPoint
        {
        }
    }
}
