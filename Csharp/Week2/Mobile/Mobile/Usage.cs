using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile
{

    class Usage
    {
        private double Battery_per;
        private List<Call> calls;

        public List<Call> Calls
        {
            get { return calls; }
        }

        public Usage()
        {
            Battery_per = 100;
            calls = new List<Call>();
        }

        public void NewCall(Calltype t)
        {
            calls.Add(new Call(t));
        }

        public void EndCall()
        {
            calls[calls.Count - 1].End();
        }

        public override string ToString()
        {
            string result = "";
            result += "Call History:\n";
            foreach (Call call in calls)
            {
               result += String.Format("Start: {0} | Duration {1} seconds\n", call.start.ToString("MM/dd/yyyy HH:mm:ss"), call.Duration);
            }
            return result;

        }

    }
}