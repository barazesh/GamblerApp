using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamblerFormsApp
{
    class Game
    {
        public State[] States = new State[2];
        private int stateCount;

        public void Initiate()
        {
            Array.Resize(ref States, stateCount);
            for (int i = 0; i < stateCount; i++)
            {
                States[i] = new State();
            }
        }

        private void ComputeStateValues()
        {
            foreach (var item in States)
            {
                if (item.Value <= 50)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        double outcome = 0.4 * (i + States[i + item.Value].Value) + 0.6 * (-i + States[item.Value - i].Value);
                        item.Value = (outcome > item.Value) ? outcome : item.Value;
                    }

                }


            }
        }

        public Game(int a)
        {
            stateCount = a;
        }

    }
}
