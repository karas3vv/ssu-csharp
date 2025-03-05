using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    [Serializable]
    internal abstract class PhoneDirectoryItem : IComparable<PhoneDirectoryItem>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneDirectoryItem(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        abstract public string ToStr();

        public abstract void DisplayInfo();
        public abstract bool MatchesSearchCriterion(string criterion);

        public int CompareTo(PhoneDirectoryItem other)
        {
            if (other == null) 
                return 1;
            return string.Compare(this.PhoneNumber, other.PhoneNumber, StringComparison.Ordinal);
        }
    }
}
