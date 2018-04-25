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

        public double[] ComputeStateValues()
        {
            double[] newStateValue = new double[stateCount];

            for (int j = 1; j < stateCount; j++)
            {

                int maxbet = Math.Min(j, 100 - j);
                double[] outcome = new double[maxbet];
                //for all bets lower than the total capital and which dont conclude the game
                for (int i = 1; i < Math.Min(j, 100 - j); i++)
                {
                    outcome[i] = 0.4 * (States[i + j].Value) + 0.6 * (States[j - i].Value);
                }

                //for the critical bet which can conclude the game
                if (maxbet + j == 100)//if the gambler have the chance to reach 100$ with this bet
                {
                    outcome[0] = 0.4 + 0.6 * States[j - maxbet].Value;
                }
                else//if the capital is less than 50 and the gambler cannot reach 100$ with this bet if he wins, but he will lose all his money if he wins
                {
                    outcome[0] = 0.4 * States[j + maxbet].Value;
                }
                newStateValue[j] = outcome.Max();
                States[j].Value = newStateValue[j];
            }
            newStateValue[0] = 0;
            return newStateValue;

        }

        public void ComputeOptimalValues(double eps)
        {
            double variance = 2 * eps;
            int itr = 0;
            while (variance > eps)
            {
                variance = 0;
                double[] newState = ComputeStateValues();
                for (int i = 0; i < stateCount; i++)
                {
                    variance = Math.Max(variance, Math.Abs(newState[i] - States[i].Value));
                }
                itr++;
            }
        }

        public double[] getvalues()
        {
            double[] Values = new double[100];
            for (int i = 0; i < 100; i++)
            {
                Values[i] = States[i].Value;
            }
            return Values;
        }

        public Game(int a)
        {
            stateCount = a;
        }

    }
}
