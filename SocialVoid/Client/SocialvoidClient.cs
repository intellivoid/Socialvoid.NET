using SocialVoid.Methods;

namespace SocialVoid.Client
{
    class SocialvoidClient
    {
        public string PUB_HASH, PVT_HASH, SOCIALVOID_PLATFORM, SOCIALVOID_VERSION;
        public SocialvoidClient(string public_hash, string private_hash, string platform, string version)
        {
            PUB_HASH = public_hash;
            PVT_HASH = private_hash;
            SOCIALVOID_PLATFORM = platform;
            SOCIALVOID_VERSION = version;


            bool createsession()
            {
                return Methods.CreateSession.Do(PUB_HASH, PVT_HASH, SOCIALVOID_PLATFORM, SOCIALVOID_VERSION);
            }
        }
    }
}
