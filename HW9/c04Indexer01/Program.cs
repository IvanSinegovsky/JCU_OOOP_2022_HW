using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c04Indexer01
{
    /* Create custom Class working as a smart array
     * Properties: Count, item[]
     * Methods: Add, Insert, Remove, RemoveAt, IndexOf, Contains, Clear
     */

    class Program
    {
        static void Main(string[] args)
        {
            MyArray<object> myArray = new MyArray<object>();
            myArray.Add(10);
            myArray.Add(20);
            myArray.Add(30);
            myArray.Add(40);
            myArray[1] = 200;
            Console.WriteLine(myArray);
            Console.WriteLine("Index of 200 is {0}", myArray.IndexOf(200));
            Console.WriteLine("Index of 30 is {0}", myArray.IndexOf(30));
            Console.WriteLine("The Value 40 is in my list: {0}", 
                myArray.Contains(40));
            Console.WriteLine("The Value 500 is in my list: {0}",
                myArray.Contains(500));
        }
    }

    public interface IMyArray<T> where T : class
    {        
        #region Properties
        // number of all elements
        int Count { get; }
        // indexer for direct access to any element (read, write)
        T this[int index] { get; set; }

        #endregion

        #region Methods
        // The object to add to the array
        int Add(T value);
        // Inserts an item to the array at the specified index.
        void Insert(int index, T value);
        // Removes the first occurrence of a specific object from the array.
        void Remove(T value);
        // Removes the array item at the specified index.
        void RemoveAt(int index);
        // Removes all items from the array.
        void Clear();
        // Determines the index of a specific item in the array.
        int IndexOf(T value);
        // Determines whether the array contains a specific value.
        bool Contains(T value);
        #endregion

    }

    public class MyArray<T> : Object, IMyArray<T> where T : class
    {
        int INITIAL_CAPACITY = 10;
        
        private T[] myList;
        private int length; // maximum number of elements (space for)
        private int count; // current number of elements (used)

        public MyArray()
        {
            length = INITIAL_CAPACITY;
            myList = new T[length];
            count = 0; // no elements yet
        }

        public T this[int index] 
        { 
            get => myList[index]; 
            set => myList[index] = value; 
        }

        public int Count => count;

        public int Add(T value)
        { // TODO: check count > INITIAL_CAPACITY
            myList[count++] = value;
            return count - 1;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) > -1;
        }

        // return the index of value in myArray
        public int IndexOf(T value)
        {
            int index = 0; // the first element
            bool found = false;
            while (!found && index < count)
            {
                if (value.Equals(myList[index++]))
                {
                    found = true;
                }                
            }
            int retValue = -1;
            if (found)
            {
                retValue = index - 1;
            }
            return retValue;
        }

        public void Insert(int index, T value)
        {
            int i = count - 1;
            while (i >= 0 && i >= index)
            {
                myList[i + 1] = myList[i];
                i--;
            }
            i++;
            myList[i] = value;
        }

        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index > -1)
            {
                RemoveAt(index); 
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                myList[i] = myList[i + 1];
            }
            count--;
        }
    }
}
