using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.MongoDB.Settings
{
    public sealed class DatabaseSettings : IDatabaseSettings
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
