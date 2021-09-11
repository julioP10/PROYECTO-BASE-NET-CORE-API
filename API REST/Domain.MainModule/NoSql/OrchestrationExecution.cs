using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Collections.Generic;

namespace Domain.MainModule.NoSql
{
    public class OrchestrationExecution: Executions
    {
        public OrchestrationExecution()
        {
            Reprocesses = new List<Executions>();
        }

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public EntityData Orchestration { get; set; }
        public EntityData Version { get; set; }     
        public Sla Sla { get; set; }

        public ICollection<Executions> Reprocesses { get; set; }
    }
}
