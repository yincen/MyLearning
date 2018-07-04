using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SocketServer
{
    class Program
    {
        private static AppServer appServer;

        static void Main(string[] args)
        {
            appServer = new AppServer();
            
            if (!appServer.Setup(8613))
            {
                Console.WriteLine("配置失败");
                Console.ReadKey();
                return;
            }

            if (!appServer.Start())
            {
                Console.WriteLine("启动失败");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("启动成功，按下q退出程序");

            //1.
            appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);
            appServer.SessionClosed += appServer_NewSessionClosed;

            //2.
            appServer.NewRequestReceived +=
                new RequestHandler<AppSession, StringRequestInfo>(appServer_NewRequestReceived);

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //Stop the appServer
            appServer.Stop();

            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }

        //1.
        static void appServer_NewSessionConnected(AppSession session)
        {
            Console.WriteLine($"服务端得到来自客户端的连接成功");

            var count = appServer.GetAllSessions().Count();
            Console.WriteLine("~~" + count);
            session.Send("Welcome to SuperSocket Telnet Server");
        }

        static void appServer_NewSessionClosed(AppSession session, CloseReason aaa)
        {
            Console.WriteLine($"服务端 失去 来自客户端的连接 " + session.SessionID + aaa);
            var count = appServer.GetAllSessions().Count();
            Console.WriteLine(count);
        }

        //2.
        static void appServer_NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine(requestInfo.Key);
            session.Send(requestInfo.Body);
        }
    }
}