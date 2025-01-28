using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductManager
{

    internal class CustomerProductManagerCollection
    {
        private readonly Dictionary<string, List<string>> customerToCategories = new();
        private readonly Dictionary<string, List<string>> categoryToCustomers = new();

        public void AddPurchase(string customer, string category)
        {
            if (!customerToCategories.ContainsKey(customer))
            {
                customerToCategories[customer] = new List<string>();
            }
            if (!customerToCategories[customer].Contains(category))
            {
                customerToCategories[customer].Add(category);
            }


            if (!categoryToCustomers.ContainsKey(category))
            {
                categoryToCustomers[category] = new List<string>();
            }
            if (!categoryToCustomers[category].Contains(customer))
            {
                categoryToCustomers[category].Add(customer);
            }
        }
        public List<string> GetCategoriesByCustomer(string customer)
        {
            if (customerToCategories.TryGetValue(customer, out var customers))
            {
                return customers;
            }
            return new List<string>();
        }
        public List<string> GetCustomersByCategory(string category)
        {
            if (categoryToCustomers.TryGetValue(category, out var customers))
            {
                return customers;
            }
            return new List<string>(); // Повернути пустий список, якщо категорії немає
        }
    }
}
