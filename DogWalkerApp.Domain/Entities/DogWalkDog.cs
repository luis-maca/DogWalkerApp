using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWalkerApp.Domain.Entities
{
    public class DogWalkDog: BaseEntity
    {
        public int DogId { get; set; }
        public Dog Dog { get; set; }

        public int DogWalkId { get; set; }
        public DogWalk DogWalk { get; set; }
    }

}
