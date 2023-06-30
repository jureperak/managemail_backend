using System;

namespace Managemail.Model.Implementations
{
    public class BaseLookupModel : BaseModel
    {
        public String Name { get; set; }
        public String Abrv { get; set; }
        public Int32 Sort { get; set; }
    }
}
