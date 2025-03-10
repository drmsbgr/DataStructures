using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Contracts;

namespace DesignPatterns
{
    public class SampleIterator : IIterator<int>
    {
        private int[] array;
        private int index;

        public SampleIterator(int[] array)
        {
            this.array = array;
            index = 0;
        }

        public int CurrentItem() => array[index];

        public void First()
        {
            index = 0;
        }

        public bool IsDone() => index == array.Length;

        public void Next()
        {
            index++;
        }
    }
}
