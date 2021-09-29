using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT.ProjectEaton.CentralResultUnit.Options
{
    public class MongoConfigs
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
        public string CollectionName { get; set; }
    }
}
