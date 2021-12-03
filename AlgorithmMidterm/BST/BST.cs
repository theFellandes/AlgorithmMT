using System.Collections.Generic;

namespace AlgorithmMidterm.BST
{
    public class BST
    {
        private List<int> tree;
        private int _n;
        public BST(List<int> treeArray)
        {
            tree = treeArray;
            _n = treeArray.Count;
        }
    }
}