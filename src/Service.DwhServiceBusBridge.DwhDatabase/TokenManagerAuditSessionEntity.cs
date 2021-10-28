using MyJetWallet.Sdk.Authorization.ServiceBus;
using Newtonsoft.Json;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class TokenManagerAuditSessionEntity : SessionAuditEvent
    {
        
        public string SessionJson { get; set; }

        public static TokenManagerAuditSessionEntity Create(SessionAuditEvent session)
        {
            return new TokenManagerAuditSessionEntity()
            {
                Action = session.Action,
                SessionJson = JsonConvert.SerializeObject(session.Session),
                Timestamp = session.Timestamp
            };
        }
        
    }
}