using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr17_18_I_n8
{
    [Serializable]
    internal class PhoneDirectory
    {
        public List<PhoneDirectoryItem> items;

        public PhoneDirectory()
        {
            items = new List<PhoneDirectoryItem>();
        }

        public void LoadDataFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length >= 3)
                    {
                        switch (data[0])
                        {
                            case "Person":
                                items.Add(new Person(data[1], data[2], data[3]));
                                break;
                            case "Organization":
                                if (data.Length >= 6)
                                    items.Add(new Organization(data[1], data[2], data[3], data[4], data[5]));
                                break;
                            case "Friend":
                                if (data.Length >= 5)
                                    items.Add(new Friend(data[1], data[2], data[3], data[4]));
                                break;
                            default:
                                throw new ArgumentException("Неизвестный тип");
                        }
                    }
                }
            }
        }

        public void DisplayAllItems()
        {
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
        }

        public List<PhoneDirectoryItem> SearchByName(string name)
        {
            List<PhoneDirectoryItem> results = new List<PhoneDirectoryItem>();
            foreach (var item in items)
            {
                if (item.MatchesSearchCriterion(name))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        public void SortByPhoneNumber()
        {
            items.Sort();
        }
    }
}
