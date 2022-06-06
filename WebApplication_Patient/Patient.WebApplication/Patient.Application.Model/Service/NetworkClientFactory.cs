namespace Patient.Application.Model
{
    public static class NetworkClientFactory
    {
        public static INetwork GetNetworkClient()
        {

#if DEBUG
            return new FakeNetworkClient();
#else
            const string serviceHost = "localhost";
            const int servicePort = 8080;

            return new NetworkClient(serviceHost, servicePort);
#endif

        }
    }
}
