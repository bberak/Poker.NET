using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BB.Poker.Logic
{
    public class TinyConnectionRecord
    {
        public string GameServerId { get; set; }

        public string TableId { get; set; }

        public TinyConnectionRecord()
        {

        }

        public TinyConnectionRecord(string gameServerId, string tableId)
        {
            GameServerId = gameServerId;

            TableId = tableId;
        }

        public bool IsSittingAtTable()
        {
            if (string.IsNullOrEmpty(GameServerId) || string.IsNullOrEmpty(TableId))
                return false;

            return true;
        }

        public TinyConnectionRecord Clone()
        {
            TinyConnectionRecord newRecord = new TinyConnectionRecord();
            newRecord.GameServerId = GameServerId;
            newRecord.TableId = TableId;
            return newRecord;
        }
    }
}
