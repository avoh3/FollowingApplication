using System;

namespace Following
{
    public class NewsProp
    {   
        public string Title { get; set; }
        public string Date { get; set; }
        //public int Views { get; set; }
        public string Link { get; set; }
        public override string ToString()
        {
            return $"{Title}{Environment.NewLine}</br>Date:{Date}{Environment.NewLine}</br><a href=\"{Link}\">LinkTo</a>{Environment.NewLine}</br>";
        }
    }
}
