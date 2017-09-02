using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AddToList
{
    class Program
    {
        static void Main(string[] args)
        {
            //building an array with a specific capacity of "12"
            var presidents = new List<string>(12)
            {
                "Jimmy Carter",
                "Ronald Reagan",
                "George HW Bush",
                "Bill Clinton",
                "George W Bush",
                "Barack Obama"
            };

            // "\r\n" = create one new free line
            Console.WriteLine("Before:");
            Console.WriteLine("Count = " + presidents.Count);
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");

            presidents.Add("Donald Trump");
            presidents.Add("Bill Gates ?");
            presidents.Add("Steven Spielberg ?");

            //move all the following elements up on place
            //again could be a performance hit if many elements have to be moved up
            presidents.RemoveAt(7);
            //always takes longer since frst elements has to be found and its index
            //by scanning each element of the list + applies RemoveAt()
            presidents.Remove("Steven Spielberg ?");

            Console.WriteLine("After:");
            Console.WriteLine("Count = " + presidents.Count);
            //when capacity is overreached a new array with 
            //double capacity is created automatically
            //there might be a small performance hit when copying very big arrays
            Console.WriteLine("Capacity = " + presidents.Capacity + "\r\n");

            ////generates error - no elements exists at this index
            //string who = presidents[10];

            ////only safe against well behaved code
            ////underlying list can still be modified by:
            //// using System.Reflection;
            //var copy = presidents.AsReadOnly();
            // or:
            var copy = new ReadOnlyCollection<string>(presidents);
            BadCode(copy);
            Console.WriteLine(copy);

            //works on IList<T> because it implements IEnumerable<T>
            foreach (string president in presidents)
                Console.WriteLine(president);
        }

        static void BadCode(IList<string> lst)
        {
            lst.RemoveAt(2);
        }
    }
}
