using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum_Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TravelCard> ltcDB = new List<TravelCard>();
            ltcDB.Add(new TravelCard("d", "e"));
            ltcDB.Add(new TravelCard("a", "b"));
            ltcDB.Add(new TravelCard("c", "d"));
            ltcDB.Add(new TravelCard("b", "c"));
            ltcDB.Add(new TravelCard("e", "f"));
            ltcDB.Add(new TravelCard("h", "g"));

            Console.WriteLine("Input:");
            foreach (var Tmp in ltcDB)
            {
                Console.WriteLine(Tmp.From + " - " + Tmp.To);
            }

            Console.WriteLine("\nSorted:");
            foreach (var Tmp in SortTravelCard(ltcDB))
            {
                Console.WriteLine(Tmp.From + " - " + Tmp.To);
            }
            Console.ReadLine();

        }

        public static List<TravelCard> SortTravelCard(List<TravelCard> ltcInput)
        {
            List<TravelCard> ltcResult = new List<TravelCard>();
            
            //----определяем место старта. В него не приезжаем ниоткуда (сложность N факториал)----
            bool bStartFind = false;
            bool bFind = false;
            int iStartIndex = 0;
            while (!bStartFind)
            {
                var Start = ltcInput[iStartIndex].From;
                bFind = false;
                for (int i = iStartIndex; i < ltcInput.Count; i++)
                {
                    if (ltcInput[i].To == Start)
                    {
                        bFind = true;
                        break; //если в точку старта мы приезжаем откуда-то
                    }
                }
                if (!bFind) bStartFind = true;  //Если за цикл не нашли совпадения, то мы нашли место старта
                else iStartIndex += 1;   //проверяем следующую карточку
            }

            ltcResult.Add(ltcInput[iStartIndex]);//добавляем в результирующий список Точку Старта

            bFind = true;
            while (bFind)   //пока находим следующие точки маршрута (по условию циклов нет)
            {
                bFind = false;
                for (int iNextIndex=0; iNextIndex < ltcInput.Count; iNextIndex++)
                {
                    if (ltcInput[iNextIndex].From == ltcInput[iStartIndex].To)
                    {
                        ltcResult.Add(ltcInput[iNextIndex]);    //добавили следующую путевую точку
                        iStartIndex = iNextIndex;   //теперь будем искать для нее
                        bFind = true;
                        break; //если в точку старта мы приезжаем откуда-то
                    }
                }
            }
            return ltcResult;
        }

    }
}
