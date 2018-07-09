using System;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;

namespace MySocketServer.HL
{
    /// <summary>
    /// 固定请求大小的协议,(帧格式为HLProtocolRequestInfo)
    /// </summary>
    public class HLProtocolReceiveFilter : FixedSizeReceiveFilter<HLProtocolRequestInfo>
    {
        public HLProtocolReceiveFilter() : base(25) //总的字节长度 1+1+2+5+1+5+2+6+1+1 = 25
        {
        }

        protected override HLProtocolRequestInfo ProcessMatchedRequest(byte[] buffer, int offset, int length,
            bool toBeCopied)
        {
            var HLData = new HLData();
            HLData.Head = (char) buffer[offset]; //开始标识的解析，1个字节
            HLData.Ping = buffer[offset + 1]; //数据，从第2位起，只有1个字节
            HLData.Lenght = BitConverter.ToUInt16(buffer, offset + 2); //数据长度，从第3位开始，2个字节
            HLData.FID = BitConverter.ToUInt32(buffer, offset + 4); //本终端ID，从第5位开始，5个字节
            HLData.Type = buffer[offset + 9]; //目标类型，从第10位开始，1个字节
            HLData.SID = BitConverter.ToUInt32(buffer, offset + 10); //转发终端ID，从第11位开始，5个字节
            HLData.SendCount = BitConverter.ToUInt16(buffer, offset + 15); //发送包计数，从第16位开始，2个字节
            HLData.Retain = buffer.CloneRange(offset + 17, 6); //保留字段，从18位开始，6个字节
            HLData.Check = buffer[offset + 23]; //异或校验，从24位开始，1个字节
            HLData.End = (char) buffer[offset + 24]; //结束符号，从第25位开始，一个字节
            return new HLProtocolRequestInfo(HLData);
        }
    }
}