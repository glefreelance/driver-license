using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities.Default
{
    public class DefaultEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid TenantId { get; set; }
        public string ApiVersion { get; set; }
        public DateTime VersionDate { get; set; }
        public string About { get; set; }
    }
}
