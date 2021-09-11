﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Settings
{
    public class MongoDbSettings: IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }   

    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
