namespace SelfBackEnd.Setting;

public class JwtConfig
{
    public string Key { get; set; }

    public string Issuer { get; set; }

    public int ValidDays { get; set; }
}
