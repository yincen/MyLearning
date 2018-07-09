using System;
using System.Linq;
using MySocketServer.HL;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;

namespace MySocketServer
{
    class Program
    {
        /// <summary>
        /// SuperSocket服务启动或停止
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("请按任何键进行启动SuperSocket服务!");
            Console.ReadKey();
            Console.WriteLine();

            var HLProtocolServer = new HLProtocolServer();
            // 设置端口号
            int port = 2017;
            //启动应用服务端口
            if (!HLProtocolServer.Setup(port)) //启动时监听端口2017
            {
                Console.WriteLine("服务端口启动失败!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            //注册连接事件
            HLProtocolServer.NewSessionConnected += HLProtocolServer_NewSessionConnected;
            //注册请求事件
            HLProtocolServer.NewRequestReceived += HLProtocolServer_NewRequestReceived;
            //注册Session关闭事件
            HLProtocolServer.SessionClosed += HLProtocolServer_SessionClosed;
            //尝试启动应用服务
            if (!HLProtocolServer.Start())
            {
                Console.WriteLine("服务启动失败!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("服务器状态:" + HLProtocolServer.State.ToString());

            Console.WriteLine("服务启动成功，请按'E'停止服务!");

            while (Console.ReadKey().KeyChar != 'E')
            {
                Console.WriteLine();
                continue;
            }

            //停止服务
            HLProtocolServer.Stop();
            Console.WriteLine("服务已停止!");
            Console.ReadKey();
        }


        static void HLProtocolServer_SessionClosed(HLProtocolSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine(session.RemoteEndPoint + "连接断开. 断开原因:" + value);
        }

        static void HLProtocolServer_NewSessionConnected(HLProtocolSession session)
        {
            Console.WriteLine(session.RemoteEndPoint.ToString() + " 已连接.");
        }

        /// <summary>
        /// 协议并没有什么太多复杂逻辑，不需要用到命令模式，直接用这种方式就可以了
        /// </summary>
        /// <param name="session"></param>
        /// <param name="requestInfo"></param>
        private static void HLProtocolServer_NewRequestReceived(HLProtocolSession session,
            HLProtocolRequestInfo requestInfo)
        {
            Console.WriteLine();
            Console.WriteLine("数据来源: " + session.RemoteEndPoint);
            Console.WriteLine("接收数据内容：" + requestInfo.Body);
        }
    }
}