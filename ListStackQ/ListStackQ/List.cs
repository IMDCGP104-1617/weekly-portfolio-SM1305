using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQ
{
    class List<T> //CREATES THE CLASS LIST, MAKES IT A TEMPLATE.
    {
        public class Node
        {
            public T Data; //CREATES A TEMPLATE, DATA.

            public Node Next; //CREATES A POINTER, CONTAINS REFERENCE TO THE NEXT NODE.
        }

        private Node head; //THE START (HEAD) OF THE LIST.
        private int count = 0; //POSITION IN LIST AND LENGTH OF THE LIST.

        public T Head
        {
            get
            {
                return head.Data; //RETURNS DATA CONTAINED IN THE HEAD NODE.
            }
        }

        public int Count
        {
            get
            {
                return count;  //RETURNS LENGTH OF THE LIST.
            }
        }

        public void list()
        {
            head = null; //SETS HEAD DATA TO NULL.
        }

        #region Insert Beginning
        /// Creates a new node, stores data within the new node. 
        /// Checks to see if the current head contains data, if not then the newly created node becomes the head.
        ///                                                  if not then the newly created node becomes the head and points to the node which was previously the head. 
        /// A count is added to the list to represent the addition of the new head node.

        public void InsertBeginning(T data)
        {
            Node newNode = new Node(); //CREATES A NEW NODE.
            newNode.Data = data; //ASSIGNS THE DATA IN THE FUNCTION PARAMETER TO THE DATA IN THE NODE.
            if (head == null)
            {
                head = newNode; //IF HEAD DOES NOT COTNAIN DATA THEN A NEWLY CREATED NODE BECOMES THE HEAD.
            }
            else //IF THE HEAD DOES CONTAIN DATA...
            {
                newNode.Next = head; //SETS THE POINTER OF THE NEW NODE (THAT IS TO BE ADDED AT THE BEGINNING) TO POINT TO THE EXISTING HEAD.
                head = newNode; //THE NEW NODE BECOMES THE HEAD. ITS POINTER REFERENCES THE PREVIOUS HEAD (AS SPECIFIED IN THE ABOVE LINE) (WHICH IS NOW IN THE SECOND POSITION).
            }
            count++; //ADDS ONE TO COUNT (LENGTH OF THE LIST).
        }
        #endregion

        #region Insert After
        /// USING THE PARAMETERS count AND data: CALLING FUNCTION InsertAfter(10,5) WOULD INSERT AFTER POSITION 10, WITH DATA 5.
        /// Checks to see whether the current node contains data...
        ///     (if yes) checks whether the counter value is equal to the current list poistion OR whether following node does not contain data
        ///                 (if yes) creates a new node following the current node and inserts data into this newly created node
        ///                 +1 is added to the counter to represent the addition of the new node.

        public void InsertAfter(int count, T data)
        {
            Node newNode = new Node { Data = data }; // CREATES A NEW NODE (SETS DATA IN NEW NODE EQUAL TO DATA PARAMETER).
            Node current = head; //SETS THE HEAD NODE TO CURRENT (WE ARE NOW LOOKING AT THE HEAD NODE)
            int counter = 0; //CREATES A COUNTER.
            while (current != null) //CHECKS WHETHER CURRENT NODE CONTAINS DATA.
            {
                if (counter == count || current.Next == null) // CHECKS WHETHER COUNTER VALUE IS EQUAL TO THE CURRENT LIST POSITION or CHECKS WHETHER CURRENT NODES POINTER REFERENCES A NODE CONTAINING DATA.
                {
                    newNode.Next = current.Next; //INSERTS THE NEW NODE AFTER THE CURRENT NODE. (ASSIGNS THE NEW NODES POSITION TO THE REFERENCE OF THE CURRENT NODES POINTER).
                    current.Next = newNode; //CREATES THE NEW NODE.
                    counter++; //ADDS ONE COUNT TO COUNTER. 

                    break; //STEPS OUT OF THE WHILE LOOP (PREVENTS INFINITE LOOPING).
                }
            }
            current = current.Next; //NEXT NODE BECOMES THE CURRENT NODE
        }
        #endregion

        #region Insert End
        /// Checks to see whether the head contains data. 
        ///     (If it does not contain data) InsertBeginning is called to create a new node containing the new data at the start
        ///     
        ///     (If it does contain data) find the head
        ///         check to see whether the following node contains data - continue checking each subsequent node points to a following node which contains data
        ///             when a node is found which does not reference a following node containing data the end of the list has been found
        ///                 a new node is created containing the value of the data parameter, this is inserted after the final node in the list (it does not reference a following node as it is in the end position)
        ///                 the node previously at the end of the list (prior to adding the new node), is set to point to the newly created node

        public void InsertEnd(T data)
        {
            if (head == null) //CHECKS TO SEE WHETHER THE HEAD CONTAINS DATA
            {
                InsertBeginning(data); //IF THE HEAD CONTAINS NO DATA, THE InsertBeginning FUNCTION IS CALLED TO CREATE A NEW NODE IN THE FIRST POSITION AND INSERT THE DATA
            }
            else //IF THE HEAD CONTAINS DATA...
            {
                Node current = head; //SETS THE HEAD NODE TO CURRENT (WE ARE NOW LOOKING AT THE HEAD NODE)
                while (current.Next != null) //CHECKS TO SEE WHETHER THE CURRENT NODE IS FOLLOWED BY A NODE CONTAINING DATA
                {
                    current = current.Next; //WHILE THE CURRENT NODE HAS A FOLLOWING NODE WHICH CONTAINS DATA, CONTINUE MOVING THROUGH EACH SUCCESSIVE NODE.
                }
                //WHILE LOOP ENDS WHEN END NODE DOES NOT HAVE A FOLLOWING NODE CONTAINING DATA
                Node newNode = new Node(); //CREATES A NEW NODE
                newNode.Data = data; //SETS DATA CONTAINED IN THE NEWLY CREATED NODE TO THAT OF THE FUNCTION PARAMETER
                newNode.Next = null; //THE NEWLY CREATED NODE'S POINTER DOES NOT REFERENCE ANOTHER NODE (AS IT IS THE END POSITION)
                current.Next = newNode; //ASSIGNS THE PREVIOUS NODE'S POINTER (PREVIOUSLY AT THE END POSITION) TO REFERENCE THE NEWLY CREATED NODE (NOW AT THE END POSITION)
            }
        }
        #endregion

        #region Remove Beginning
        /// THE FUNCTION WILL REMOVE THE FIRST NODE AND RETURN THE DATA CONTAINED WITHIN IT.
        /// Checks whether head contains data...
        /// If the head contained data, checks whether the following node contains data, if it does not, remove data from the head node.  
        ///                                                                            , if it does, set the node following the head node to become the head node.
        /// A count is subtracted from the list to represent the removal of data from the head node.
        /// ...if the removed head did contain data, the data value of the removed head is shown.

        public T RemoveBeginning()
        {
            T ret = default(T); //ASSIGNS RET TO DEFAULT TEMPLATE TYPE (DATA TYPE TO BE DEFINED).

            if (head != null)
            {
                ret = head.Data; //CREATES A VARIABLE TO STORE THE DATA CONTAINED WITHIN THE CURRENT HEAD NODE.
                if (head.Next == null)
                {
                    head = null; //IF THE NODE FOLLOWING THE HEAD DOES NOT CONTAIN ANY DATA, REMOVE DATA FROM THE HEAD (DELETING THE HEAD, AND THE LIST).
                }
                else
                {
                    head = head.Next; //IF THE NODE FOLLOWING THE HEAD DOES CONTAIN DATA, THIS NODE BECOMES THE HEAD.
                }
            }
            count--; //MINUS ONE COUNT (LENGTH OF LIST COUNT)
            return ret; //SHOWS THE DATA THAT WAS CONTAINED WITHIN THE HEAD
        }
        #endregion

        #region Remove After
        /// FUNCTION REMOVES NODE AFTER POSTION count (SPECIFIED WITHIN PARAMETER)
        /// Idenitifies the node at the start of the list, Checks whether the following node contains data
        ///     (while it does) checks whether the following node contains data 
        ///         (if it does) the node's pointer is set to reference the node following the next node (skipping over the next node, removing it from the list)
        /// A count is subtracted from the list length to represent the removed node.
        /// The data contained within the removed node is displayed.

        public T RemoveAfter(int count)
        {
            T ret = default(T); //ASSIGNS RET TO DEFAULT TEMPLATE TYPE.
            Node current = head; //SETS THE HEAD NODE TO CURRENT (WE ARE NOW LOOKING AT THE HEAD NODE)
            int counter = 0; //CREATES A COUNTER.

            while (current.Next != null) //CHECKS WHETHER THE CURRENT NODE IS FOLLOWED BY A NODE CONTAINING DATA - WHILE IT DOES, DO...
            {
                if (current.Next != null) //CHECKS WHETHER THE CURRENT NODE IS FOLLOWED BY A NODE CONTAINING DATA - IF IT DOES, DO...
                {
                    ret = current.Next.Data; //RET IS SET EQUAL TO THE DATA VALUE CONTAINED IN THE NEXT NODE
                    current.Next = current.Next.Next; //ASSIGNS THE CURRENT NODES POINTER TO REFERENCE NOT THE NEXT NODE, BUT THE NODE FOLLOWING THE NEXT NODE (EFFECTIVELY SKIPPING THE NEXT NODE)
                    counter--; //MINUS ONE COUNT
                }
                break; //STEPS OUT OF THE WHILE LOOP (TO PREVENT INFINITE LOOPING)
            }
            current = current.Next; //NEXT NODE BECOMES THE CURRENT NODE

            return ret; //SHOWS THE DATA OF THE REMOVED NODE
        }
        #endregion
    }
}