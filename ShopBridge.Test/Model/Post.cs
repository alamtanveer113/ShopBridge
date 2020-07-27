using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Test.Model
{
    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }

        public int UserId { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public Nullable<double> Price { get; set; }



        public virtual User User { get; set; }
    }
}
