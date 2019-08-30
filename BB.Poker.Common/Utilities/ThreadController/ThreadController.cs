using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BB.Poker.Common
{
    public class ThreadController
    {
        private ManualResetEvent[] syncEvents;
        private ManualResetEvent mainEvent;
        private Timer timer;
        private string expectedMessageId;

        public ThreadController(bool initialState)
        {
            expectedMessageId = string.Empty;
            syncEvents = new ManualResetEvent[1];
            syncEvents[0] = new ManualResetEvent(initialState);
            mainEvent = syncEvents[0];
            timer = new Timer(new TimerCallback(timeLimitReached));
        }

        public void WaitHere()
        {
            mainEvent.Reset();
            WaitHandle.WaitAny(syncEvents);
        }

        public void WaitHereFor(string msgId)
        {
            expectedMessageId = msgId;
            WaitHere();
        }

        public void WaitHereFor(int milliseconds)
        {
            timer.Change(milliseconds, milliseconds);
            WaitHere();  
        }

        public void WaitHereFor(string msgId, int orTimeLimitInMilliseconds)
        {
            expectedMessageId = msgId;
            timer.Change(orTimeLimitInMilliseconds, orTimeLimitInMilliseconds);
            WaitHere();
        }

        public void ContinueIf(bool condition)
        {
            if (condition)
                Continue();
        }

        public void ContinueIfExpected(string msgid)
        {
            if (string.IsNullOrEmpty(expectedMessageId) == false && expectedMessageId.Equals(msgid))
                Continue();
        }

        public void Continue()
        {
            mainEvent.Set();
        }

        private void timeLimitReached(object stateinfo)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Continue();
        }

        public string ExpectedMessageId
        {
            get { return expectedMessageId; }
        }
    }
}
