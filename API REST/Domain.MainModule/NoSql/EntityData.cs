using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.NoSql
{
    public class EntityData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
