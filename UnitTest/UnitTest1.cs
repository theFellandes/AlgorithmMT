using System;
using System.Linq;
using AlgorithmMidterm.Heap;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        
        [Test]
        public void BuildMaxHeapTestSlide()
        {
            int[] intArray = new[] {4, 1, 3, 2, 16, 9, 10, 14, 8, 7};
            int[] result = new[] {16, 14, 10, 8, 7, 9, 3, 2, 4, 1};
            Heap heap = new Heap(intArray.ToList());
            heap.BuildMaxHeap();

            for (int i = 0; i < heap.GetSize(); i++)
            {
                Assert.AreEqual(heap.PeekAtIndexedValue(i), result[i]);
            }
        }
        
        [Test]
        public void HeapsortTest()
        {
            int[] intArray = new int[2000];
            Random random = new Random();
            for (int i = 0; i < 2000; i++)
            {
                intArray[i] = random.Next(0, 1000);
            }

            Heap heap = new Heap(intArray.ToList());
            heap.Heapsort();

            Sort.QuickSort.Sort(intArray);
            
            Assert.AreEqual(heap.ReturnArray(), intArray);
        }
    }
}