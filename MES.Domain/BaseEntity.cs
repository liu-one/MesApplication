using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain
{
    public  abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive {  get; set; }
        public  DateTime CreatedAt { get; set; }
        public int CreatedBy {  get; set; }
        public DateTime UpdateAt { get; set; }
        public int UpdateBy {  get; set; }
    }
}
