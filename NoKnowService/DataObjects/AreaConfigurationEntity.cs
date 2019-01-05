using Microsoft.Azure.Mobile.Server;

namespace NoKnowService.DataObjects
{
    public class AreaConfigurationEntity : EntityData
    {
        public string AccountId { get; set; }

        public string KantonId { get; set; }

        public string GemeindeId { get; set; }
    }
}