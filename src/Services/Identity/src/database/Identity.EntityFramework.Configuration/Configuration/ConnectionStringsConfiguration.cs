namespace Identity.EntityFramework.Configuration.Configuration;

public class ConnectionStringsConfiguration
{
    public string ConfigurationDbConnection { get; set; }

    public string PersistedGrantDbConnection { get; set; }

    public string LogDbConnection { get; set; }

    public string DataProtectionDbConnection { get; set; }

    public void SetConnections(string commonConnectionString)
    {
        LogDbConnection = commonConnectionString;
        ConfigurationDbConnection = commonConnectionString;
        DataProtectionDbConnection = commonConnectionString;
        PersistedGrantDbConnection = commonConnectionString;
    }
}