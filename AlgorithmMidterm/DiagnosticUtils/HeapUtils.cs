using System;
using System.IO;
using System.Linq;

namespace AlgorithmMidterm.DiagnosticUtils
{
    public class HeapUtils
    {
        public static void HeapSortTest(string fullPath)
        {
            Random random = new Random();
            int repetition = 1000;
            string[] lines = new string[102];
            var index = 0;
            lines[index++] = "HeapSort Estimated Times:";
            lines[index++] = "Size, Elapsed Time";
            while (repetition <= 100_000)
            {
                int[] intArray = new int[repetition];
                for (int i = 0; i < repetition; i++)
                {
                    intArray[i] = random.Next(0, 100_000);
                }
                var heap = new Heap.Heap(intArray.ToList());
                
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                heap.Heapsort();
                watch.Stop();
                
                lines[index++] = repetition + ", " + watch.ElapsedMilliseconds;
                repetition += 1000;
            }
            File.WriteAllLines(fullPath, lines);
            Console.WriteLine(File.ReadAllText(fullPath));
        }
        
        public static void QuickSortTest(string quickPath)
        {
            Random random = new Random();
            int repetition = 1000;
            string[] lines = new string[102];
            var index = 0;
            lines[index++] = "Quicksort Estimated Times:";
            lines[index++] = "Size, Elapsed Time";
            while (repetition <= 100_000)
            {
                int[] intArray = new int[repetition];
                for (int i = 0; i < repetition; i++)
                {
                    intArray[i] = random.Next(0, 100_000);
                }

                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                Sort.QuickSort.Sort(intArray);
                watch.Stop();
                
                lines[index++] = repetition + ", " + watch.ElapsedMilliseconds;
                repetition += 1000;
            }
            File.WriteAllLines(quickPath, lines);
            Console.WriteLine(File.ReadAllText(quickPath));
        }
        
        public static void BuildMaxHeapTest(string fullPath)
        {
            Random random = new Random();
            int repetition = 1000;
            string[] lines = new string[102];
            var index = 0;
            lines[index++] = "BuildMaxHeap Estimated Times:";
            lines[index++] = "Size, Elapsed Time";
            while (repetition <= 100_000)
            {
                int[] intArray = new int[repetition];
                for (int i = 0; i < repetition; i++)
                {
                    intArray[i] = random.Next(0, 100_000);
                }
                var heap = new Heap.Heap(intArray.ToList());
                
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                heap.BuildMaxHeap();
                watch.Stop();
                
                lines[index++] = repetition + ", " + watch.ElapsedMilliseconds;
                repetition += 1000;
            }
            File.WriteAllLines(fullPath, lines);
            Console.WriteLine(File.ReadAllText(fullPath));
        }
        
        public static void HeapMaximumTest(string fullPath)
        {
            Random random = new Random();
            int repetition = 1000;
            string[] lines = new string[102];
            var index = 0;
            lines[index++] = "HeapMaximumTest Estimated Times:";
            lines[index++] = "Size, Elapsed Time";
            while (repetition <= 100_000)
            {
                int[] intArray = new int[repetition];
                for (int i = 0; i < repetition; i++)
                {
                    intArray[i] = random.Next(0, 100_000);
                }
                var heap = new Heap.Heap(intArray.ToList());
                
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                heap.HeapMaximum();
                watch.Stop();
                
                lines[index++] = repetition + ", " + watch.ElapsedMilliseconds;
                repetition += 1000;
            }
            File.WriteAllLines(fullPath, lines);
            Console.WriteLine(File.ReadAllText(fullPath));
        }
    }
}