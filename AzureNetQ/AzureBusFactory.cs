﻿namespace AzureNetQ
{
    using Microsoft.WindowsAzure;

    public static class AzureBusFactory
    {   

        public static IBus CreateBus()
        {
            return CreateBus(new AzureNetQSettings());
        }

        public static IBus CreateBus(string connectionString)
        {
            return CreateBus(connectionString, new AzureNetQSettings());
        } 
        
        public static IBus CreateBus(AzureNetQSettings settings)
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            return CreateBus(connectionString, new AzureNetQSettings());
        }

        public static IBus CreateBus(string connectionString, AzureNetQSettings settings)
        {
            var configuration = settings.ConnectionConfiguration();
            configuration.ConnectionString = connectionString;

            return new AzureBus(
                settings.Logger(),
                settings.Conventions(),
                settings.Rpc(),
                settings.SendAndReceive(),
                settings.AzureAdvancedBus.Value, 
                configuration);
        }
    }
}
