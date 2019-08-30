using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BB.Poker.Common
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this T me)
        {
            List<T> result = new List<T>();

            result.Add(me);

            return result;
        }

        public static T[] ToArray<T>(this T me)
        {
            return new T[] { me };
        }

        public static IEnumerable<T> AsLocked<T>(this IEnumerable<T> ie, object @lock)
        {
            return new ThreadSafeEnumerable<T>(ie, @lock);
        }

        //-- Extensions for firing specialized events..
        public static void Fire<T, U>(this MessageReceivedEventHandler<T, U> me, object sender, MessageReceivedEventArgs<T, U> eventArgs)
        {
            var myEvent = me;

            if (myEvent != null)
                myEvent(sender, eventArgs);
        }

        public static void Fire<T>(this GameMessageReceivedEventHandler<T> me, object sender, GameMessageReceivedEventArgs<T> eventArgs)
        {
            var myEvent = me;

            if (myEvent != null)
                myEvent(sender, eventArgs);
        }
    }
}
