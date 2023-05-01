using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinNode
{
    internal class BinNode<T>
    {
        private T value;
        private BinNode<T> right;
        private BinNode<T> left;

        public BinNode(T value)
        {
            this.value = value;
            this.right = this.left = null;
        }

        public BinNode(BinNode<T> left, T value, BinNode<T> right)
        {
            this.left = left;
            this.value = value;
            this.right = right;
        }

        public T GetValue()
        {
            return value;
        }

        public BinNode<T> GetLeft()
        {
            return left;
        }

        public BinNode<T> GetRight()
        {
            return right;
        }

        public bool HasLeft()
        {
            return left != null;
        }

        public bool HasRight()
        {
            return right != null;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetLeft(BinNode<T> left)
        {
            this.left = left;
        }

        public void SetRight(BinNode<T> right)
        {
            this.right = right;
        }

        public override string ToString()
        {
            if (this.HasRight())
            {
                return this.value + "-->" + this.right;
            }
            else
            {
                return this.value + "-->null";
            }
        }
    }
}
