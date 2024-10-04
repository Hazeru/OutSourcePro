using OutSourcePro.Core.Enums;
using Microsoft.Extensions.Logging;
using OutSourcePro.Core.Entities;

namespace OutSourcePro.Core.Entities
{
    public class Job : BaseEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }

        // Relations
        public long CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}
