using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp13
{
    public class Recipe
    {
        public string FirstItem { get; set; }
        public string SecondItem { get; set; }
        public string Result { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} + {SecondItem} = {Result}";
        }
    }
}
