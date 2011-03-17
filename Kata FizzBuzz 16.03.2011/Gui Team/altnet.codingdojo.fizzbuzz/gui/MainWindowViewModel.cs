using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace altnet.codingdojo.fizzbuzz.gui
{
    class MainWindowViewModel
    {
        public string MaxValue { get; set; }
        public IEnumerable<string> Results { get; private set; }
        public ICommand Send { get; private set; }
    }
}
