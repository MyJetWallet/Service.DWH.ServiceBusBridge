using System;
using Newtonsoft.Json;
using Service.BalanceHistory.ServiceBus;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class WalletTradeMassageEntity : WalletTradeMessage
    {
        
        
        public string TradeJson { get; set; }
        
        public string TraderUId { get; set; }
        
        public DateTime DateTime { get; set; }

        public static WalletTradeMassageEntity Create(WalletTradeMessage message)
        {
            return new WalletTradeMassageEntity()
            {
                BrokerId = message.BrokerId,
                ClientId = message.ClientId,
                DateTime = message.Trade.DateTime,
                Trade = null,
                TradeJson = JsonConvert.SerializeObject(message.Trade),
                WalletId = message.WalletId,
                TraderUId = message.Trade.TradeUId
            };
        }
        
    }
}