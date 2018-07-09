using System.Net;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServer.HL
{
    public class HLReceiveFilterFactory : IReceiveFilterFactory<HLProtocolRequestInfo>
    {
        public IReceiveFilter<HLProtocolRequestInfo> CreateFilter(IAppServer appServer, IAppSession appSession,
            IPEndPoint remoteEndPoint)
        {
            return new HLBeginEndMarkReceiveFilter();
            //return new HLProtocolReceiveFilter();
        }
    }
}