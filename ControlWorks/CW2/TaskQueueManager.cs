using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2
{
    class TaskQueueManager
    {
        Thread Producer;

        Thread Consumer;

        int producerCount;

        int consumerCount;

        object locker = new object();

        Queue<Action> queue = new Queue<Action>();

        public void Start()
        {
            Producer = new Thread(ProducerActions);

            Consumer = new Thread(ConsumerActions);


            Producer.Start();
            Consumer.Start();
        }
        private void ProducerActions()
        {
            while (true)
            {
                producerCount = 0;
                lock (locker)
                {
                    while(producerCount < 20)
                    {
                        Action value = () => { };
                        queue.Enqueue(value);
                        producerCount++;
                    }
                }
            }
        }
        private void ConsumerActions()
        {
            while (true)
            {
                consumerCount = 0;
                lock (locker)
                {
                    while (consumerCount < 20)
                    {
                        queue.Dequeue().Invoke();
                        consumerCount++;
                    }
                }
            }
        }
    }
}
