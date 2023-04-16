using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    public class Counter
    {
        public delegate void Handler();
        public event Handler? Notify;
        public void counter()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 77)
                {
                    Notify.Invoke();
                }
            }
        }

    }
}