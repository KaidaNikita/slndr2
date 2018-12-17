using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Slenderman
{
    class Player:Image
    {
        public int count_of_papers=0;
        List<Item> items=new List<Item>();
        public int speed = 1;
        public int key = 0;
        public Player()
        {
                
        }
    }
}
