using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProductCollection
{
    internal class CustomerProduct
    {
        private readonly  Dictionary<string, HashSet<string>> customerToCategories = new();
        private readonly  Dictionary<string , HashSet<string>> categoryToCustomers = new();

        // Додати покупця і категорію товару
        public void AddPurchase(string customer, string category)
        {
            if (!customerToCategories.ContainsKey(customer))
            {
                customerToCategories[customer] = new HashSet<string>();
            }
            customerToCategories[customer].Add(category);

            if (!categoryToCustomers.ContainsKey(category))
            {
                categoryToCustomers[category] = new HashSet<string>();
            }
            categoryToCustomers[category].Add(customer);
        }

        // Отримати всі категорії, придбані покупцем
        public IEnumerable<string> GetCategoriesByCustomer(string customer)
        {
            if (customerToCategories.TryGetValue(customer, out var categories))
            {
                return categories;
            }
            return Enumerable.Empty<string>();
        }

        // Отримати всіх покупців, які придбали товари в певній категорії
        public IEnumerable<string> GetCustomersByCategory(string category)
        {
            if (categoryToCustomers.TryGetValue(category, out var customers))
            {
                return customers;
            }
            return Enumerable.Empty<string>();
        }
    }

}
    