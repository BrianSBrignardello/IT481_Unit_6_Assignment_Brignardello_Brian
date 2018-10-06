using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Example
    {
    class Program
        {
        public static List<string> ScenarioSummaryTime = null;
        static Thread[] threads = null;
        static IList<Customer> customer = null;
        static Random rnd;
        static void Main (string[] args)
            {
            ScenarioSummaryTime = new List<string>();
            
            scenario00(6,10);
            scenario01(3,20);
            scenario02(10,30);
            
            foreach ( var time in ScenarioSummaryTime )
                {
                Console.WriteLine(time);
                }
            Console.ReadLine();
            }




       

        static void scenario00 (int numberOfRooms,int numberOfCustomer)
            {
            Console.WriteLine("Scenario00");
            rnd = new Random();
            
            customer = new List<Customer>();
            for ( int i = 0; i < numberOfCustomer; i++ )
                {
                int clothingItems = rnd.Next(1, 6);
                customer.Add(new Customer(clothingItems, numberOfRooms));
                }
            
            threads = new Thread[numberOfRooms];
            Program.ScenarioSummaryTime.Add("Scenario00: Summary");
            for ( int j = 0; j < customer.Count; )
                {
                
                for ( int i = 0; i < numberOfRooms; i++, j++)
                    {
                    
                    if ( j < customer.Count )
                        {
                        
                        threads[i] = new Thread(customer[j].TryOnClothes);
                        threads[i].Name = "thread_" + i;
                        threads[i].Start();
                        
                        threads[i].Join();
                        }
                    }
                }


            }


        static void scenario01 (int numberOfRooms, int numberOfCustomer)
            {
            Console.WriteLine("Scenario01");
            rnd = new Random();
            
            customer = new List<Customer>();
            for ( int i = 0; i < numberOfCustomer; i++ )
                {
                int clothingItems = rnd.Next(1, 6);
                customer.Add(new Customer(clothingItems, numberOfRooms));
                }
            
            threads = new Thread[numberOfRooms];
            Program.ScenarioSummaryTime.Add("Scenario01: Summary");
            for ( int j = 0; j < customer.Count; )
                {
                
                for ( int i = 0; i < numberOfRooms; i++, j++ )
                    {
                    
                    if ( j < customer.Count )
                        {

                        threads[i] = new Thread(customer[j].TryOnClothes);
                        threads[i].Name = "thread_" + i;
                        threads[i].Start();
                        
                        threads[i].Join();
                        }
                    }
                }
          
            }
        static void scenario02 (int numberOfRooms, int numberOfCustomer)
            {
            Console.WriteLine("Scenario02");
            rnd = new Random();
            
            customer = new List<Customer>();
            for ( int i = 0; i < numberOfCustomer; i++ )
                {
                int clothingItems = rnd.Next(1, 6);
                customer.Add(new Customer(clothingItems, numberOfRooms));
                }
            
            threads = new Thread[numberOfRooms];
            Program.ScenarioSummaryTime.Add("Scenario02: Summary");
            for ( int j = 0; j < customer.Count; )
                {
                
                for ( int i = 0; i < numberOfRooms; i++, j++ )
                    {
                    
                    if ( j < customer.Count )
                        {

                        threads[i] = new Thread(customer[j].TryOnClothes);
                        threads[i].Name = "thread_" + i;
                        threads[i].Start();
                        
                        threads[i].Join();
                        }
                    }
                }
         
            }

        }
    }
