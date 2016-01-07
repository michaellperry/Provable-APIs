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
        * You must call Listen before Accept.
        */
        public class ListeningSocket
        {
            public void Accept() { }
        }

        public class BoundSocket
        {
            public BoundSocket(EndPoint localEP) { }

            public ListeningSocket Listen(int backlog) { return new ListeningSocket(); }
        }

        public static void Right()
        {
            var socket = new BoundSocket(new EndPoint());
            socket.Listen(1000)
                .Accept();
        }

        //public static void Wrong1()
        //{
        //    var socket = new BoundSocket();
        //    // Forgot to call Bind.
        //    socket.Listen(1000);
        //}

        //public static void Wrong2()
        //{
        //    var socket = new BoundSocket();
        //    socket.Bind(new EndPoint());
        //    socket.Listen(1000);
        //    socket.Bind(new EndPoint());
        //    // Called Bind more than once.
        //}

        public class EndPoint
        {
        }
    }
}
