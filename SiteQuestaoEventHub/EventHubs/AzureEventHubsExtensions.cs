using System;
using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace SiteQuestaoEventHub.EventHubs
{
    public static class AzureEventHubsExtensions
    {
        public static void AddEvent(this EventDataBatch eventBatch, string eventData)
        {
            if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(eventData))))
                throw new Exception($"O tamanho em dados do evento {eventData} "+
                    "é superior ao limite suportado e nao será enviado!");
        }
    }
}