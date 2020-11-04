using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackApp.Models
{
    class Card
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public Bitmap Image { get; set; }
    }
}
