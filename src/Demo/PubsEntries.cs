using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jusfr.Persistent;

namespace Demo {
    public class Job 
    {
        public virtual Int32                      Id                        { get; set; }  //pk, Identity, int not null
        public virtual String                     Title                     { get; set; }  //varchar(50) not null
        public virtual Decimal                    Salary                    { get; set; }  //decimal(12,2) not null
    }

    public class Employee 
    {
        public virtual Int32                      Id                        { get; set; }  //pk, Identity, int not null
        public virtual String                     Name                      { get; set; }  //varchar(10) not null
        public virtual DateTime                   Birth                     { get; set; }  //datetime not null
        public virtual String                     Address                   { get; set; }  //varchar(255)
        public virtual Job                        Job                       { get; set; }  //int not null
    }

}
