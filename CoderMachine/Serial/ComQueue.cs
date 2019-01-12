using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderMachine.Serial
{
    public class ComQueue<T> : Queue<T>
    {
        private int limit = -1;

        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }

        public ComQueue(int limit)
            : base(limit)
        {
            this.Limit = limit;
        }

        private static object MyLock = new object();
        public new void Enqueue(T item)
        {
            lock (MyLock)
            {
                if (this.Count >= this.Limit)
                {
                    this.Dequeue();
                }
                base.Enqueue(item);
            }
        }

    }
}
