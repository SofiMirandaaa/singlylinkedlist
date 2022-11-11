using System;

namespace singly_linked_list
{
    //each node consist of the information part and lik to the next mode

    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void  addNote() //add node in the list
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number o the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            //if the node to be inserted is the first node
            if (START == null || nim <= START.rollNumber)
            {
                if ((START != null) && (nim == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            //locate the position of the new node in the list
            Node previous, current;
            previous = START;   
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }

            /*once the above for loop is executed, prev, and current are positioned in such a  manner that the position for the new node*/
            newnode = current;
            previous.next = newnode;

        }
        public void traverse()
        {
            if (ListEmpty())
            {
                Console.WriteLine("\nList is empt.\n");
            }
            else
            {
                Console.WriteLine("\nthe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)

                        Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");

                Console.WriteLine();
            }

        }
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //check if the spesified node is present in the list or not
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if(current ==START)
                START = START.next;
            return true;  
        }
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            
            while ((current != null) && (nim != current.rollNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }

    }
}