using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }



    }
}
