using Microsoft.Azure.Mobile.Server;

namespace NoKnowService.DataObjects
{
    public class GemeindeEntity : EntityData
    {
        public string Bezeichnung { get; set; }

        public string KantonId { get; set; }

    }
}