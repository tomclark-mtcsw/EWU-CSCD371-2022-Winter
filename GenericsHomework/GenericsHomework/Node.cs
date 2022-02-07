namespace GenericsHomework
{
    public class Node<T> where T : notnull
    {
        public Node(T nodeValue)
        {
            NodeValue = nodeValue;
            Next = this;
        }

        private T NodeValue { get; set; }

        public Node<T> Next { get; private set; }

        public override string? ToString()
        {
            return NodeValue.ToString();
        }

        public void Append(T nodeValue)
        {
            if (Exists(nodeValue))
            {
                throw new ArgumentException("Value already exists!");
            }
            else
            {
                Node<T> newNode = new(nodeValue);

                Node<T> nextNode = Next;
                while (nextNode != this)
                {
                    if (nextNode.Next.Equals(this))
                    {
                        break;
                    }
                    nextNode = nextNode.Next;
                }

                newNode.Next = this;
                nextNode.Next = newNode;
            }
        }

        public void DeleteSingleNode(T value)
        {
            Node<T> nextNode = Next;
            Node<T> prevNode = this;
            while (nextNode != this)
            {
                if (nextNode.NodeValue.Equals(value))
                {
                    prevNode.Next = nextNode.Next;
                    break;
                }
                prevNode = nextNode;
                nextNode = nextNode.Next;

                /* NOTE: Garbage collection is not a concern due to
                 *       no objects referencing the removed Node.
                 */
            }
        }

        public void Clear()
        {
            Node<T> nextNode = Next;
            while (nextNode != this)
            {
                DeleteSingleNode(nextNode.NodeValue);
                if (nextNode.Next.Equals(this))
                {
                    break;
                }
                nextNode = nextNode.Next;
            }
        }

        public int Count()
        {
            int count = 1;

            Node<T> nextNode = Next;
            while (nextNode != this)
            {
                count++;
                nextNode = nextNode.Next;
            }

            return count;
        }

        public bool Exists(T nodeValue)
        {
            bool found = false;

            if (Count() > 1)
            {
                Node<T> nextNode = Next;
                while (nextNode != this)
                {
                    if (nextNode.NodeValue.Equals(nodeValue))
                    {
                        found = true;
                        break;
                    }
                    nextNode = nextNode.Next;
                }
            }
            else if (NodeValue.Equals(nodeValue))
            {
                found = true;
            }

            return found;
        }
    }
}