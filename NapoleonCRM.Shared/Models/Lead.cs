using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NapoleonCRM.Shared.Models;

[DataContract]
public class Lead
{
    [Key]
    [DataMember]
    public long? Id { get; set; }

    [DataMember]
    public long? ContactId { get; set; }

    [DataMember]
    public string? Source { get; set; }

    [DataMember]
    public string? Status { get; set; }

    [DataMember]
    public decimal? PotentialValue { get; set; }

    [DataMember]
    public long? OpportunityId { get; set; }

    [DataMember]
    public long? AddressId { get; set; }

    [DataMember]
    public string? Photo { get; set; }

    [DataMember]
    public string? Notes { get; set; }

    [DataMember]
    public Address? Address { get; set; }

    [DataMember]
    public Opportunity? Opportunity { get; set; }

    [DataMember]
    public Contact? Contact { get; set; }

    [DataMember]
    public DateTime? CreatedDate { get; set; }

    [DataMember]
    public DateTime ModifiedDate { get; set; }
    
}
