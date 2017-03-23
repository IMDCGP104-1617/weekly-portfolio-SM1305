using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQ
{
    class Stack<T>
    {
        private List<T> stack;
        private int count; //CREATES INT TO REPRESENT THE NUMBER OF NODES IN THE STACK.

        #region Count
        //SHOWS THE NUMBER OF NODES IN THE STACK
        public int Count
        {
            get
            {
                return count; //RETURNS NUMBER OF NODES IN THE STACK.
            } 
        }
        #endregion

        #region Is Empty
        //CHECKS WHETHER THE LIST CONTAINS ANY NODES CONTAINING DATA
        public bool IsEmpty ()
        {
            return count == 0; //BOOL RETURNS AS TRUE IF COUNT IS EQUAL TO 0. BOOL RETURNS AS FALSE IF ANY VALUE OTHER THAN 0.
        }
        #endregion

        #region Stack
        //CONSTRUCTOR
        public Stack ()
        {
            stack = new List<T>(); //STACK CLASS CONSTRUCTOR
        }
        #endregion

        #region ~Stack
        //DECONSTRUCTOR, REMOVES NODES FROM STACK UNTIL COMPLETELY EMPTY
        ~Stack ()
        {
            while (!IsEmpty()) //WHILE NOT EMPTY, DO...
            {
                T output; //OUTPUTS THE VALUE OF T
                Pop(out output); //PASS VALUE IN
            }
        }
        #endregion

        #region Push
        //ADDS DATA TO TOP OF STACK
        public void Push (T data)
        {
            count++; //ADDS ONE TO COUNT TO REPRESENT THE ADDITION OF A NODE.
            stack.InsertBeginning(data); //INSERTS DATA AT THE BEGINNING (TOP) OF THE STACK.
        }
        #endregion

        #region Pop
        //REMOVES THE HEAD (TOP-MOST NODE) FROM THE STACK
        public bool Pop (out T output)
        {
            output = default(T);
            if (IsEmpty())
            {
                return false; //RETURNS FALSE IF IsEmpty (IF THE LIST CONTAINS NO NODES CONTAINING DATA)
            }
            output = stack.RemoveBeginning(); //REMOVES THE NODE AT THE TOP OF THE STACK

            count--; //MINUS ONE FROM COUNT TO REPRESENT THE REMOVAL OF ONE NODE FROM THE STACK

            return true;
        }
        #endregion

        #region Peek
        //VIEWS DATA CONTAINED WITHIN THE TOP NODE IN THE STACK (WITHOUT EFFECTING THE NODE OR ITS DATA).
        public T Peek ()
        {
            return stack.Head; //RETURNS THE DATA CONTAINED WITHIN THE HEAD NODE (TOP-MOST).
        }
        #endregion
    }
}
