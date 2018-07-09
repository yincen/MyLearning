using System;
using SuperSocket.SocketBase;

namespace MySocketServer.HL
{
    public class HLProtocolSession : AppSession<HLProtocolSession, HLProtocolRequestInfo>
    {
        protected override void HandleException(Exception e)
        {

        }

    }
}