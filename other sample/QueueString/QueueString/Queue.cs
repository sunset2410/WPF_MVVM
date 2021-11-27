using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueString
{

    public class Queue
    {
        private const int MAX_QUEUE = 5;
        private Queue<string> PBAQueue;
        private Queue<string> PINQueue;

        public Queue()
        {
            PBAQueue = new Queue<string>();
            PINQueue = new Queue<string>();
        }

        public void Clear()
        {
            PBAQueue.Clear();
            PINQueue.Clear();
        }

        public void insertPIN(string PIN)
        {
            if (PINQueue.Count >= MAX_QUEUE)
            {
                PINQueue.Dequeue();
            }
            PINQueue.Enqueue(PIN);
        }

        public void insertPBA(string PBA)
        {
            if (PBAQueue.Count >= MAX_QUEUE)
            {
                PBAQueue.Dequeue();
            }
            PBAQueue.Enqueue(PBA);
        }

        public bool ContainsPIN(string PIN)
        {
            if (PINQueue.Contains(PIN))
                return true;
            else
                return false;
        }

        public bool ContainsPBA(string PBA)
        {
            if (PBAQueue.Contains(PBA))
                return true;
            else
                return false;
        }

    }
}
