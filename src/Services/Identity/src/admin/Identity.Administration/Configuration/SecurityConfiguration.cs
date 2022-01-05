namespace Identity.Administration.Configuration;

public class SecurityConfiguration
{
    public List<string> CspTrustedDomains { get; set; } = new List<string>();
 
    public bool UseDeveloperExceptionPage { get; set; } = false;

  
    public bool UseHsts { get; set; } = true;
   
    public Action<HstsOptions> HstsConfigureAction { get; set; }

    public Action<AuthenticationBuilder> AuthenticationBuilderAction { get; set; }
    
    public Action<AuthorizationOptions> AuthorizationConfigureAction { get; set; }
}