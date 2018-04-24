using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblerFormsApp
{
    class State
    {
        private double _value;

        public double Value { get => _value; set => _value = value; }

        public int bestBet;

        public State()
        {
            _value = 0;
        }
    
    }
}
