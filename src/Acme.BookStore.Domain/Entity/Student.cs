using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Entity
{
    public class Student : FullAuditedEntity<Guid>
    {
        public string StudentName { get; set; }
    }
}
