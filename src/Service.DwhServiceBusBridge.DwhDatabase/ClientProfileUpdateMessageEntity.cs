using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Authorization.Domain.Models.ServiceBus;
using Service.ClientProfile.Domain.Models;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class ClientProfileUpdateMessageEntity //: ClientProfile.Domain.Models.ClientProfile
    {
        public long Id { get; set; }
        public string ClientId { get; set; }
        public string Blockers { get; set; }
        public string OldProfileJson { get; set; }
        public string BlockresJson { get; set; }
        public string Status2FEText { get; set; }
        public DateTime Timestamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool KYCPassed { get; set; }
        public bool PhoneConfirmed { get; set; }
        public Status2FA Status2FA { get; set; }

        public static ClientProfileUpdateMessageEntity Create(ClientProfileUpdateMessage message)
        {
            return new ClientProfileUpdateMessageEntity()
            {
                ClientId = message.NewProfile.ClientId,
                Blockers = null,
                BlockresJson = JsonConvert.SerializeObject(message.NewProfile.Blockers),
                EmailConfirmed = message.NewProfile.EmailConfirmed,
                Id = 0,
                KYCPassed = message.NewProfile.KYCPassed,
                OldProfileJson = JsonConvert.SerializeObject(message.OldProfile),
                PhoneConfirmed = message.NewProfile.PhoneConfirmed,
                Status2FA = message.NewProfile.Status2FA,
                Status2FEText = message.NewProfile.Status2FA.ToString(),
                Timestamp = message.Timestamp
            };
        }

    }
}