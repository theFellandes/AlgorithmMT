using System;

namespace AlgorithmMidterm.Heap
{
    public class MaxHeap
    {
        private int[] heap;
        private int _size;

        public MaxHeap(int capacity)
        {
            heap = new int[capacity];
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new IndexOutOfRangeException("Heap is empty");
            return heap[0];
        }

        public void Insert(int value)
        {
            if (IsFull())
                throw new IndexOutOfRangeException("Heap is full.");

            heap[_size] = value;
            
            //Heapify for max heap
            FixHeapAbove(_size++);
        }

        public int Delete(int index)
        {
            //Here we take the index of the value that we are going to delete because if we take the value
            //then we need to do a linear search to find the location of the value.
            if (IsEmpty())
                throw new IndexOutOfRangeException("Heap is empty.");
            int parent = GetParent(index);
            int deletedValue = heap[index];

            //Replacing the deletedValue with the rightmost value which is size-1'th indexed value
            heap[index] = heap[_size - 1];

            if (index == 0 || heap[index] < heap[parent])
            {
                FixHeapBelow(index, _size - 1);
            }
            
            else
            {
                FixHeapAbove(index);
            }
            
            _size--;
            return deletedValue;
        }

        public void Sort()
        {
            int lastHeapIndex = _size - 1;
            for (int i = 0; i < lastHeapIndex; i++)
            {
                //lastHeapIndex - i is the location of the lastUnsortedIndex
                (heap[0], heap[lastHeapIndex - i]) = (heap[lastHeapIndex - i], heap[0]);

                FixHeapBelow(0, lastHeapIndex - i - 1);
            }
        }

        public void PrintHeap()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.Write(heap[i] + ", ");
            }

            Console.WriteLine();
        }

        //lastHeapIndex is for Heapsort.
        private void FixHeapBelow(int index, int lastHeapIndex)
        {
            int childToSwap;

            while (index <= lastHeapIndex)
            {
                int leftChild = GetChild(index, true);
                int rightChild = GetChild(index, false);
                //this means the node has left child
                if (leftChild <= lastHeapIndex)
                {
                    //doesn't have a rightChild
                    if (rightChild > lastHeapIndex)
                    {
                        childToSwap = leftChild;
                    }
                    //if the rightChild if fails, means it has rightChild
                    else
                    {
                        childToSwap = heap[leftChild] > heap[rightChild] ? leftChild : rightChild;
                    }
                    
                    if (heap[index] < heap[childToSwap])
                    {
                        (heap[index], heap[childToSwap]) = (heap[childToSwap], heap[index]);
                    }

                    else
                    {
                        break;
                    }

                    index = childToSwap;
                }
                
                else
                {
                    break;
                }
            }
        }

        private void FixHeapAbove(int index)
        {
            int newValue = heap[index];
            while (index > 0 && newValue > heap[GetParent(index)])
            {
                heap[index] = heap[GetParent(index)];
                index = GetParent(index);
            }

            heap[index] = newValue;
        }

        private bool IsFull()
        {
            return _size == heap.Length;
        }

        private bool IsEmpty()
        {
            return _size == 0;
        }

        public int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        //bool left is there because it indicates whether we want the left child or the right child
        public int GetChild(int index, bool left)
        {
            return 2 * index + (left ? 1 : 2);
        }
    }
}