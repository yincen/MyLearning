using SuperSocket.SocketBase.Protocol;

namespace MySocketServer.HL
{
    public class HLProtocolRequestInfo : RequestInfo<HLData>
    {
        public HLProtocolRequestInfo(HLData hlData)
        {
            //如果需要使用命令行协议的话，那么命令类名称HLData相同
            Initialize("HLData", hlData);
        }
    }
}