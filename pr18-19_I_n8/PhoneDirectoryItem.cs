using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal abstract class PhoneDirectoryItem : IComparable<PhoneDirectoryItem>
    {
        protected string Name { get; set; }
        protected string Address { get; set; }
        protected string PhoneNumber { get; set; }

        public PhoneDirectoryItem(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public abstract void DisplayInfo();
        public abstract bool MatchesSearchCriterion(string criteria);

        public int CompareTo(PhoneDirectoryItem other)
        {
            if (other == null) return 1;
            return string.Compare(this.PhoneNumber, other.PhoneNumber, StringComparison.Ordinal);
        }
    }

}
