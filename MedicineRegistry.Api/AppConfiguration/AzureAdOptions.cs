namespace MedicineRegistry.Api.AppConfiguration
{
  public class AzureAdOptions
  {
    public string Instance { get; set; }
    public string Domain { get; set; }
    public string TenantId { get; set; }
    public string ClientId { get; set; }
    public string[] Scopes { get; set; }
  }
}
