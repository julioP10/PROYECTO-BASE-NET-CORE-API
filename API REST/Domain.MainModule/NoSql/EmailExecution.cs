using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.MainModule.NoSql
{
    public class EmailExecution
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public int AutomaticEmailId { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
        public string EmailAddresses { get; set; }
    }
}
