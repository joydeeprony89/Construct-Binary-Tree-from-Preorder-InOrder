using System;
using System.Collections.Generic;
using System.Linq;

namespace Construct_Binary_Tree_from_Pre_In
{
  class Program
  {
    static void Main(string[] args)
    {
      var inorder = new int[] { 9, 3, 15, 20, 7 };
      var preorder = new int[] { 3, 9, 20, 15, 7 };
      Solution s = new Solution();
      s.BuildTree(preorder, inorder);
    }
  }


  public class TreeNode
  {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
      this.val = val;
      this.left = left;
      this.right = right;
    }
  }
  public class Solution
  {
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
      var result = Helper(preorder.ToList(), inorder.ToList(), new TreeNode());
      return result;
    }

    private TreeNode Helper(List<int> preorder, List<int> inorder, TreeNode root)
    {
      if (preorder == null || inorder == null || preorder.Count == 0 || inorder.Count == 0) return null;

      // preorder is r->l->ri, so always the first element is root
      root.val = preorder[0];
      // find the root no in inorder, found index left side is left subtree and right side is right subtree
      int mid = inorder.IndexOf(root.val);
      root.left = Helper(preorder.GetRange(1, mid), inorder.GetRange(0, mid), new TreeNode());
      root.right = Helper(preorder.GetRange(mid + 1, preorder.Count - (mid + 1)), inorder.GetRange(mid + 1, preorder.Count - (mid + 1)), new TreeNode());

      return root;
    }
  }
}
