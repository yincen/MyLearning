using SuperSocket.SocketBase;

namespace MySocketServer.HL
{
    public class HLProtocolServer : AppServer<HLProtocolSession, HLProtocolRequestInfo>
    {
        /// <summary>
        /// 使用自定义协议工厂
        /// </summary>
        public HLProtocolServer()
            : base(new HLReceiveFilterFactory())
        {

        }
    }
}