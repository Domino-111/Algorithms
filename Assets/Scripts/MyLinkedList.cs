using UnityEngine;

namespace OurLinkedList
{
    public class Node
    {
        public string name = "Jeffery";
        public int age = 0;

        public Node next;
        public Node previous;

        public Node(string name, int age)
        {
            this.name = name;
            this.age = age;

            next = null;
            previous = null;
        }
    }


    public class MyLinkedList : MonoBehaviour
    {
        [ContextMenu("Test Linked List")]
        void Test()
        {
            Node Andrew = new Node("Andrew", 300);
            Node Steve = new Node("Steve", 56);
            Node Tom = new Node("Tom", 40);
            Node Alex = new Node("Alex", 14);
            Node Roger = new Node("Roger", 1);

            LinkedList linkedList = new LinkedList(Andrew);
            linkedList.InsertNext(Steve);
            linkedList.InsertNext(Tom);
            linkedList.ReturnToHeader();
            linkedList.DeleteNext();
            linkedList.InsertNext(Roger);
            linkedList.InsertNext(Alex);
            linkedList.ReturnToHeader();
            linkedList.Next();
            linkedList.Next();
            linkedList.DeleteNext();

            linkedList.PrintAll();
        }
    }

    public class LinkedList
    {
        private Node current;
        private Node header;
        private Node tail;

        public LinkedList(Node node)
        {
            header = node;
            tail = node;
            current = node;
            header.next = null;
            header.previous = null;
        }

        public void InsertNext(Node newNode)
        {
            if (current == null)
            {
                header = newNode;
                tail = newNode;
                newNode.next = null;
                newNode.previous = null;
            }

            else if (current.next == null)
            {
                current.next = newNode;
                newNode.next = null;
                newNode.previous = current;
                tail = newNode;
            }

            else
            {
                newNode.next = current.next;
                current.next = newNode;

                newNode.next.previous = newNode;
            }

            current = newNode; // Optional
        }

        public void InsertPrevious(Node newNode)
        {
            if (current == null)
            {
                header = newNode;
                tail = newNode;
            }

            else if (current.previous == null)
            {
                newNode.previous = current.previous;
                current.previous = newNode;
                newNode.previous.next = newNode;
                newNode.next = current;
            }

            current = newNode;
        }

        public bool Next()
        {
            if (current == null)
            {
                return false;
            }

            if (current.next != null)
            {
                current = current.next;
                return true;
            }

            return false;
        }

        public bool Previous()
        {
            if (current == null)
            {
                return false;
            }

            if (current.previous != null)
            {
                current = current.previous;
                return true;
            }

            return false;
        }

        public bool DeleteNext()
        {
            if (current.next == null)
            {
                return false;
            }

            current.next = current.next.next;

            if (current.next == null)
            {
                tail = current;
            }

            else
            {
                current.next.previous = current;
            }

            // if you're using C++ raw pointers, you would have delete() here
            return true;
        }

        public bool DeletePrevious()
        {
            if (current.previous == null)
            {
                return false;
            }

            current.previous = current.previous.previous;

            if (current.previous == null)
            {
                header = current;
            }

            else
            {
                current.previous.next = current;
            }

            // if you're using C++ raw pointers, you would have delete() here
            return true;
        }

        public void DeleteCurrent()
        {
            if (Previous())
            {
                DeleteNext();
            }

            else if (Next())
            {
                DeletePrevious();
            }

            else
            {
                header = null;
                tail = null;
                current = null;
            }
        }

        public void ReturnToHeader()
        {
            current = header;
        }

        public void PrintCurrent() => Debug.Log(current.name + " aged " + current.age);

        public void Print(Node node) => Debug.Log(node.name + " aged " + node.age);
        
        public void PrintAll()
        {
            if (header == null)
            {
                return;
            }

            Node currentPrint = header;

            do
            {
                Print(currentPrint);
                currentPrint = currentPrint.next;
            }
            while (currentPrint != null);
        }
    }
}
