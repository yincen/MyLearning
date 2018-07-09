using System;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;

namespace MySocketServer.HL
{
    public class HLBeginEndMarkReceiveFilter : BeginEndMarkReceiveFilter<HLProtocolRequestInfo>
    {
        private readonly static char strBegin = '&';

        private readonly static char strEnd = '#';

        //开始和结束标记也可以是两个或两个以上的字节
        private readonly static byte[] BeginMark = new byte[] {(byte) strBegin};
        private readonly static byte[] EndMark = new byte[] {(byte) strEnd};

        public HLBeginEndMarkReceiveFilter() : base(BeginMark, EndMark)
        {

        }

        /// <summary>
        /// 这里解析的到的数据是会把头和尾部都给去掉的
        /// </summary>
        /// <param name="readBuffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override HLProtocolRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            var HLData = new HLData();
            HLData.Head = (char) readBuffer[offset]; //自己定义开始符号
            offset += 1;
            HLData.Ping = readBuffer[offset]; //数据，从第1位起，只有1个字节
            HLData.Lenght = BitConverter.ToUInt16(readBuffer, offset + 1); //数据长度，从第2位开始，2个字节
            HLData.FID = BitConverter.ToUInt32(readBuffer, offset + 3); //本终端ID，从第4位开始，5个字节
            HLData.Type = readBuffer[offset + 8]; //目标类型，从第9位开始，1个字节
            HLData.SID = BitConverter.ToUInt32(readBuffer, offset + 9); //转发终端ID，从第10位开始，5个字节
            HLData.SendCount = BitConverter.ToUInt16(readBuffer, offset + 14); //发送包计数，从第15位开始，2个字节
            HLData.Retain = readBuffer.CloneRange(offset + 16, 6); //保留字段，从17位开始，6个字节
            HLData.Check = readBuffer[offset + 22]; //异或校验，从23位开始，1个字节
            HLData.End = (char) readBuffer[readBuffer.Length - 1]; //结束符号，自己定义
            return new HLProtocolRequestInfo(HLData);
        }
    }
}