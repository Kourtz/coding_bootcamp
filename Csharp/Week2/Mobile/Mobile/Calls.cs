using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{
    enum Calltype
    {
        Incoming,
        Outgoing
    }

    class Call
    {
        private DateTime Start_time;
        private DateTime End_time;
        private Calltype Type;

        public DateTime start
        {
            get { return Start_time; }
        }

        public DateTime end
        {
            get { return End_time; }
        }

        public double Duration
        {
            get
            {
                TimeSpan span = End_time.Subtract(Start_time);
                return span.Seconds;
            }
        }

        public Calltype type
        {
            get { return Type; }
        }

        
        public Call(Calltype t)
        {
            this.Start_time = DateTime.Now;
            this.Type = t;                   
        }

        public void End()
        {
            this.End_time = DateTime.Now;
        }

        }
    }

