using System;
using Bitfinex.Client.Websocket.Validations;

namespace Bitfinex.Client.Websocket.Requests.Orders
{
    /// <summary>
    /// Unique client order identification - id + date
    /// </summary>
    public class CidPair
    {
        public CidPair()
        {
            
        }
        /// <summary>
        /// Create a new unique order identification
        /// </summary>
        public CidPair(long cid, DateTime cidDate)
        {
            BfxValidations.ValidateInput(cid, nameof(cid), 0);
            BfxValidations.ValidateInput(cidDate, nameof(cidDate));

            Cid = cid;
            CidDate = cidDate;
        }

        /// <summary>
        /// Client id, unique per day
        /// </summary>
        public long Cid { get; }

        /// <summary>
        /// Order creation date to make Cid unique
        /// </summary>
        public DateTime CidDate { get; }

        /// <summary>
        /// Generate Cid from Unix Ms.
        /// </summary>
        /// <returns></returns>
        public static long GenerateCid()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}