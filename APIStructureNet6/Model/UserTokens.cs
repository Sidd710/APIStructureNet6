namespace ElectionCampaignBackEnd2.Model
{
    public class UserTokens
    {
        #nullable disable
        public string Token
            {
                get;
                set;
            }
            public string UserName
            {
                get;
                set;
            }
            public TimeSpan Validaty
            {
                get;
                set;
            }
            public string RefreshToken
            {
                get;
                set;
            }
            public Guid Id
            {
                get;
                set;
            }
            public string EmailId
            {
                get;
                set;
            }
            public Guid GuidId
            {
                get;
                set;
            }
            public DateTime ExpiredTime
            {
                get;
                set;
            }
        }
}
