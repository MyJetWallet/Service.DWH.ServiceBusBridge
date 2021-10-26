using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.DwhServiceBusBridge.Settings
{
    public class SettingsModel
    {
        [YamlProperty("DwhServiceBusBridge.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("DwhServiceBusBridge.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("DwhServiceBusBridge.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("DwhServiceBusBridge.DwhConnectionString")]
        public string DwhConnectionString { get; set; }

        [YamlProperty("DwhServiceBusBridge.MyServiceBusHostPort")]
        public string MyServiceBusHostPort { get; set; }
    }
}
