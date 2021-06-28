using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTemplate02.Data.DataModels.InternalModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostId { get; set; }

        public DateTime TimeSend { get; set; }
        public string SenderId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; } // temp structue { drivers , activities , FirstClass,Duration,Cost,Description }

    }

    public class PostViewModel : Post {
        public int  Duration { get; set; }
        public int  Cost { get; set; }

        public bool Drivers { get; set; }
        public bool FirstClass { get; set; }
        public bool Activities { get; set; }

        public void ToPostView(Post model) {

            this.TimeSend = model.TimeSend;
            this.SenderId = model.SenderId;
            this.PostId = model.PostId;
            this.Description = model.Description;
            this.Message = model.Message;
            this.Id = model.Id;

            this.Populate();
            
        }


        public void Populate() {

            if (Description.Contains('%'))
            {


            Drivers = (Description[0] == '1') ? true : false ;
            Activities = (Description[2] == '1') ? true : false;
            FirstClass = (Description[4] == '1') ? true : false;
            Duration = Description[6] + Description[7];
                Description = Description.Remove(0,9);

            bool flag = true;
            int counter = 0;
            string stringcost = "";
            while (flag)
            {
                if (Description[counter] == '%')
                {
                    flag = false;
                    continue;
                }
                stringcost += Description[counter];
               Description =  Description.Remove(0,1);
            }
            Cost = Convert.ToInt32(stringcost);
            }
  

        }

    }
}
