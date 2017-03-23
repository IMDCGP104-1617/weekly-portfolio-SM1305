using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQ
{
    class Queue<T>
    {
        private List<T> queue;
        private int count; //CREATES COUNT TO SHOW THE NUMBER OF NODES 

        #region Count
        //SHOWS THE NUMBER OF NODES IN THE QUEUE
        public int Count
        {
            get
            {
                return count; //RETURNS THE NUMBER OF NODES IN THE QUEUE
            } 
        }
        #endregion

        #region Is Empty
        //CHECKS WHETHER THE QUEUE CONTAINS ANY NODES CONTAINING DATA
        public bool IsEmpty ()
        {
            return count == 0; //BOOL RETURNS AS TRUE IF COUNT IS EQUAL TO 0. BOOL RETURNS AS FALSE IF ANY VALUE OTHER THAN 0.
        }
        #endregion

        #region Queue
        //CONSTRUCTOR
        public Queue()
        {
            queue = new List<T>(); //QUEUE CLASS CONSTRUCTOR
        }
        #endregion

        #region ~Queue
        //DECONSTRUCTOR, REMOVES NODES FROM STACK UNTIL COMPLETELY EMPTY
        ~Queue ()
        {
            while (!IsEmpty())
            {
                T output; //OUTPUTS THE VALUE OF T
                Dequeue(out output); //PASS VALUE
            }
        }
        #endregion

        #region Enqueue
        //ADDS DATA AT THE END OF THE QUEUE
        public void Enqueue (T data)
        {
            count++; //ADDS 1 TO COUNT TO REPRESENT THE ADDITION OF A NODE
            queue.InsertEnd(data); //DATA IS ADDED AFTER THE LAST EXISTING NODE IN THE QUEUE
        }
        #endregion

        #region Dequeue
        //REMOVES THE HEAD FROM THE QUEUE (THE START OF THE QUEUE - THE LONGEST OCCUPIED NODE)
        public bool Dequeue (out T output)
        {
            output = default(T);

            if (IsEmpty())
            {
                return false; //RETURNS FALSE IF IsEmpty (IF THE QUEUE CONTAINS NO NODES CONTAINING DATA)
            }

            output = queue.RemoveBeginning (); //REMOVES THE NODE AT THE START OF THE QUEUE
            count--; //TAKE 1 FROM COUNT VALUE TO REPRESENT THE REMOVAL OF A NODE
            return true;  //IF TRUE IS RETURNED, THEN THE FIRST NODE HAS BEEN REMOVED
        }
        #endregion

        #region Peek
        public T Peek ()
        //VIEWS DATA CONTAINED WITHIN THE FIRST NODE IN THE QUEUE (WITHOUT EFFECTING THE NODE OR ITS DATA).
        {
            return queue.Head; //RETURNS THE DATA CONTAINED WITHIN THE HEAD NODE (FIRST POSITION).
        }
        #endregion
    }
}
