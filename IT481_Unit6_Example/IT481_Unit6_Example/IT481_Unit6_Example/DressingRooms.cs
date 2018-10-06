using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Example
    {
    class DressingRooms
        {
        int _availableRooms;
        static Semaphore sem;
        static DressingRooms dressingRooms = null;

        
        private DressingRooms (int numberRooms = 3)
            {         
            _availableRooms = numberRooms;
            sem = new Semaphore(1, _availableRooms);
            }
        
        public static DressingRooms DressingRoom (int numberRooms)
            {
            if ( null == dressingRooms )
                dressingRooms = new DressingRooms();
            return dressingRooms;
            }
 
        //request room by customer
        public void RequestRoom (string roomnumber)
            {
            
            sem.WaitOne();
            Console.WriteLine("Entering room # {0}", roomnumber.Substring(roomnumber.LastIndexOf('_')+1));
            }
        
        public void ExitRoom (string roomnumber)
            {
            //semaphore object gets updated
            int room = sem.Release();
            Console.WriteLine("Exit room # {0}", roomnumber.Substring(roomnumber.LastIndexOf('_') + 1));
            Console.WriteLine();
            }

        }
    }
