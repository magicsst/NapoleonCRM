using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NapoleonCRM.Shared.Models;

[DataContract]
public class ProductCategory
{
    [Key]
    [DataMember]
    public long? Id { get; set; }

    [DataMember]
    public string? Name { get; set; }

    [DataMember]
    public string? Description { get; set; }

    [DataMember]
    public string? Icon { get; set; }

    [DataMember]
    public string? TaxRate { get; set; }

    [DataMember]
    public string? Notes { get; set; }

    [DataMember]
    public DateTime? CreatedDate { get; set; }

    [DataMember]
    public DateTime ModifiedDate { get; set; }

}
