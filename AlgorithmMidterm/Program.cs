using System.IO;

namespace AlgorithmMidterm
{
    class Program
    {
        static void Main(string[] args)
        {
            // HeapSortResult();
            // QuickSortResult();
            BuildMaxHeapResult();
            HeapMaximumResult();
        }

        static void HeapSortResult()
        {
            string fullPath = Path.GetFullPath(@"C:\Users\Fellandes\RiderProjects\AlgorithmMT\AlgorithmMidterm\Results\Heap\Heapsort.txt");
            DiagnosticUtils.HeapUtils.HeapSortTest(fullPath);
        }

        static void QuickSortResult()
        {
            string fullPath = Path.GetFullPath(@"C:\Users\Fellandes\RiderProjects\AlgorithmMT\AlgorithmMidterm\Results\Sort\Quicksort.txt");
            DiagnosticUtils.HeapUtils.QuickSortTest(fullPath);
        }
        
        static void BuildMaxHeapResult()
        {
            string fullPath = Path.GetFullPath(@"C:\Users\Fellandes\RiderProjects\AlgorithmMT\AlgorithmMidterm\Results\Heap\BuildMaxHeap.txt");
            DiagnosticUtils.HeapUtils.BuildMaxHeapTest(fullPath);
        }
        
        static void HeapMaximumResult()
        {
            string fullPath = Path.GetFullPath(@"C:\Users\Fellandes\RiderProjects\AlgorithmMT\AlgorithmMidterm\Results\Heap\HeapMaximum.txt");
            DiagnosticUtils.HeapUtils.HeapMaximumTest(fullPath);
        }
        
        
    }
}