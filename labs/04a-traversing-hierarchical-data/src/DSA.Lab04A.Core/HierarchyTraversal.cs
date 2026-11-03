using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            
            int count = 1;
        
            foreach (HierarchyNode<T> child in root.Children)
            {
                count += CountNodes(child);
            }

            return count;
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            bool result = EqualityComparer<T>.Default.Equals(root.Value, target);

            if (result) { return result; }

            foreach (HierarchyNode<T> child in root.Children)
            {
                result = Contains(child, target);
                
                if (result) { return result; }
            }

            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            List<T> orderList = new List<T>();

            orderList.Add(root.Value);

            foreach (HierarchyNode<T> child in root.Children)
            {
                orderList.AddRange(DepthFirstPreOrder(child));
            }

            return orderList;
        }
        
        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int maxDepth = 0;

            foreach (HierarchyNode<T> child in root.Children)
            {
                SearchDepthRecursive(ref maxDepth, child, 1);    
            }
            
            return maxDepth;
            
        }

        private static void SearchDepthRecursive<T>(ref int maxDepth, HierarchyNode<T> root, int depth)
        {
            maxDepth = Math.Max(maxDepth, depth);
            
            foreach (HierarchyNode<T> child in root.Children)
            {
                SearchDepthRecursive(ref maxDepth, child, depth + 1);
            }
        }
        
    }
}
