using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS
{
    public static class SubSequence
    {
        public static string Get(string strInput)
        {
            var arrInput = Array.ConvertAll(strInput.Split(' '), int.Parse);

            var lstValue = new List<int>();
            var lstIndex = new List<int>();

            var subsequenceList = new List<Tuple<int, int>>();

            for (var i = 0; i < arrInput.Length; i++)
            {
                if (i < arrInput.Length - 1)
                {
                    if (arrInput[i] < arrInput[i + 1])
                    {
                        lstIndex.Add(i);
                        lstValue.Add(arrInput[i]);
                    }
                    else if (lstValue.Count > 0)
                    {
                        lstValue.Add(arrInput[i]);
                        lstIndex.Add(i);
                        subsequenceList.Add(new Tuple<int, int>(lstValue.Count, lstIndex.Min()));
                        lstValue.Clear();
                        lstIndex.Clear();
                    }
                }

                if (i + 1 == arrInput.Length)
                {
                    if (arrInput[i - 1] < arrInput[i])
                    {
                        lstIndex.Add(i);
                        lstValue.Add(arrInput[i]);
                        subsequenceList.Add(new Tuple<int, int>(lstValue.Count, lstIndex.Min()));
                        lstValue.Clear();
                        lstIndex.Clear();
                    }
                }
            }

            var subsequenceIndex = subsequenceList.Aggregate((s, a) => s.Item1 >= a.Item1 ? s : a);

            var finalLis = new List<int>();

            for (var i = subsequenceIndex.Item2; i < arrInput.Length; i++)
            {
                if (i < arrInput.Length - 1)
                {

                    if (arrInput[i] < arrInput[i + 1])
                    {
                        finalLis.Add(arrInput[i]);
                    }
                    else if (finalLis.Count > 0)
                    {
                        finalLis.Add(arrInput[i]);
                        break;
                    }
                }

                if (i + 1 != arrInput.Length) continue;

                if (arrInput[i - 1] < arrInput[i])
                    finalLis.Add(arrInput[i]);
                break;
            }
            return string.Join(" ", finalLis);
        }
    }
}