using MyJetWallet.ServiceBus.SessionAudit.Models;
using Newtonsoft.Json;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
	public class TokenManagerAuditSessionEntity : SessionAuditEvent.SessionItem
	{
		public string Action { get; set; }
		public string Comment { get; set; }
		public string SessionJson { get; set; }
		public long Id { get; set; }

		public static TokenManagerAuditSessionEntity Create(SessionAuditEvent session)
		{
			return new TokenManagerAuditSessionEntity
			{
				Comment = session.Comment,
				Action = session.Action.ToString(),
				SessionJson = JsonConvert.SerializeObject(session.Session),
				Id = 0,
				Application = session.Session.Application,
				BrandId = session.Session.BrandId,
				CreateTime = session.Session.CreateTime,
				Description = session.Session.Description,
				DeviceUid = session.Session.DeviceUid,
				EmailVerified = session.Session.EmailVerified,
				IP = session.Session.IP,
				PlatformType = session.Session.PlatformType,
				TraderId = session.Session.TraderId,
				UserAgent = session.Session.UserAgent,
				Passed2FA = session.Session.Passed2FA,
				PublicKeyBase64 = session.Session.PublicKeyBase64,
				RootSessionId = session.Session.RootSessionId
			};
		}
	}
}