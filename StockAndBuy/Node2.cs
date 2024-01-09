using System;
using System.Collections.Generic;
using System.Text;

namespace StockAndBuy
{
    public class Node2<T>
    {
        public T data { get; private set; }
        public Node2<T> parent { get; private set; }
        public List<Node2<T>> children { get; private set; }
        public Node2(T data)
        {
            this.data = data;
            this.children = new List<Node2<T>>();
        }
        public override string ToString()
        {
            return data.ToString();
        }
        public void AddChild(Node2<T> data)
        {
            data.parent = this;
            this.children.Add(data);
        }
        public void AddAllChildren(List<Node2<T>> children)
        {
            foreach (Node2<T> child in children)
                child.parent = this;
            this.children.AddRange(children);
        }
        public bool IsLeaf()
        {
            return this.children == null || this.children.Count == 0;
        }
        public List<T> PreOrder()
        {
            List<T> list = new List<T>();
            list.Add(data);
            foreach (Node2<T> child in children)
                list.AddRange(child.PreOrder());
            return list;
        }
        public List<T> PostOrder()
        {
            List<T> list = new List<T>();
            foreach (Node2<T> child in children)
                list.AddRange(child.PreOrder());
            list.Add(data);
            return list;
        }
        public List<T> LevelOrder()
        {
            List<T> list = new List<T>();
            Queue<Node2<T>> queue = new Queue<Node2<T>>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Node2<T> temp = queue.Dequeue();
                foreach (Node2<T> child in temp.children)
                    queue.Enqueue(child);
                list.Add(temp.data);
            }
            return list;
        }
        public int Depth()
        {
            int deepest = 0;
            foreach (Node2<T> child in children)
            {
                int depth = 1 + child.Depth();
                if (deepest < depth)
                    deepest = depth;
            }
            return deepest;
        }
    }
}
