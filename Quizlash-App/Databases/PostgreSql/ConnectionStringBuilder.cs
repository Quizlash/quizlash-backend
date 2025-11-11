namespace Quizlash_App.Databases.PostgreSql;

public class ConnectionStringBuilder
{
    private string _host;
    private int? _port;
    private string _database;
    private string _username;
    private string _password;
    private string _sslMode;
    private bool _trustServerCertificate;
    public ConnectionStringBuilder SetHost(string host)
    {
        _host = host;
        return this;
    }
    public ConnectionStringBuilder SetPort(int port)
    {
        _port = port;
        return this;
    }
    public ConnectionStringBuilder SetDatabase(string database)
    {
        _database = database;
        return this;
    }
    public ConnectionStringBuilder SetUsername(string username)
    {
        _username = username;
        return this;
    }
    public ConnectionStringBuilder SetPassword(string password)
    {
        _password = password;
        return this;
    }
    public ConnectionStringBuilder SetSSLMode(string sslMode)
    {
        _sslMode = sslMode;
        return this;
    }
    public ConnectionStringBuilder SetTrustServerCertificate(bool trustServerCertificate)
    {
        _trustServerCertificate = trustServerCertificate;
        return this;
    }
    public string Build()
    {
        var parts = new List<string>();
        if (!string.IsNullOrEmpty(_host))
            parts.Add($"Host={_host}");
        if (_port.HasValue)
            parts.Add($"Port={_port.Value}");
        if (!string.IsNullOrEmpty(_database))
            parts.Add($"Database={_database}");
        if (!string.IsNullOrEmpty(_username))
            parts.Add($"Username={_username}");
        if (!string.IsNullOrEmpty(_password))
            parts.Add($"Password={_password}");
        if (!string.IsNullOrEmpty(_sslMode))
            parts.Add($"SSL Mode={_sslMode}");
        parts.Add($"Trust Server Certificate={_trustServerCertificate}");
        return string.Join(";", parts);
    }
}
