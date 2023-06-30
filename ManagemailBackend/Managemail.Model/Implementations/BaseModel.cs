using System;

namespace Managemail.Model.Implementations
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
