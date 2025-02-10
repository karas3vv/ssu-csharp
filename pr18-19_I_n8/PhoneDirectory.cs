using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    internal abstract class PhoneDirectory : IComparable<PhoneDirectory>
    {
        public abstract string PhoneNumber { get; set; }

        public abstract void PrintInfo();

        public abstract bool MatchesCriterion(string criterion);

        public int CompareTo(PhoneDirectory other)
        {
            return string.Compare(this.PhoneNumber, other.PhoneNumber, StringComparison.Ordinal);
        }
    }
}
