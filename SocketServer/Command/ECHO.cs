﻿using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace MySocketServer.Command
{
    public class ECHO : CommandBase<TelnetSession, StringRequestInfo>
    {
        public override void ExecuteCommand(TelnetSession session, StringRequestInfo requestInfo)
        {
            session.Send(requestInfo.Body);
        }
    }
}