using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Example
    {
    class Customer
        {
        int _ClothingItems;
        static DressingRooms _dressingRoom;
        static int totalCustomers = 1;
        static int value = 1;
        Random rnd;
        
        public Customer (int ClothingItems,int numberOfRooms)
            {
            totalCustomers++;
            
            value = 1;
            rnd = new Random();
           
            if ( ClothingItems == 0 || ClothingItems > 20 )
                {
                _ClothingItems = rnd.Next(1, 20); 
                }
            
            else if ( (ClothingItems > 0) && (ClothingItems <= 20) )
                {
                _ClothingItems = ClothingItems;
                }
            
            if(null== _dressingRoom )
            _dressingRoom = DressingRooms.DressingRoom(numberOfRooms);
            }

        public void TryOnClothes ()
            {
            
            _dressingRoom.RequestRoom(Thread.CurrentThread.Name);
            
            if ( value <= totalCustomers )
                {
                Console.WriteLine("***Customer " + value + " ***");
                value++;
                }
            
           DateTime T1 = DateTime.Now;
            Console.WriteLine(Thread.CurrentThread.Name + " Trying on {0} items of clothing.", _ClothingItems);
            Thread.Sleep(300);

            for ( int i = 0; i < _ClothingItems; i++ )
                {
               
                int TimeToTryOnClothes = rnd.Next(1, 3); 
                Console.WriteLine(Thread.CurrentThread.Name + " Trying on item {0} : {1}", i, DateTime.Now.ToString());
               
                Console.WriteLine(" Time to wait for an item : {0}", TimeToTryOnClothes +" minute");
                Thread.Sleep(100000*TimeToTryOnClothes);

                }
            Console.WriteLine(Thread.CurrentThread.Name + " Done trying on {0} items of clothing.", _ClothingItems);
            
             DateTime T2 = DateTime.Now;
            
             TimeSpan diff = T2 - T1;
            Console.WriteLine(Thread.CurrentThread.Name + " Total time (minutes) spent trying on clothing : "+ diff.Minutes.ToString());
            
            Program.ScenarioSummaryTime.Add("Customer " + value + " " + diff.Minutes.ToString());
            
            _dressingRoom.ExitRoom(Thread.CurrentThread.Name);
            }
        }
    }
