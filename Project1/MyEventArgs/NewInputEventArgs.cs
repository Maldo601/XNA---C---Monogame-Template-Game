using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.MyEventArgs
{
    class NewInputEventArgs : EventArgs
    {
        public Input Input { get; set; }

        public NewInputEventArgs(Input input)
        {
            Input = input;
        }
    }
}
