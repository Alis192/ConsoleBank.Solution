using ConsoleBank.BusinessLogicLayer;
using ConsoleBank.BusinessLogicLayer.BALContracts;
using ConsoleBank.Entities;
using ConsoleBank.Entities.Contracts;
using ConsoleBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.Presentation
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //create an object of Customer
                Customer customer = new Customer();

                //read all details from the user
                Console.WriteLine("\n********ADD CUSTOMER*************");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                {
                    Console.WriteLine("Customer Not added");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }


        internal static void ViewCustomers()
        {
            try
            {
                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n**********ALL CUSTOMERS*************");
                //read all customers
                foreach (var item in allCustomers)
                {
                    Console.WriteLine("Customer Code: " + item.CustomerCode);
                    Console.WriteLine("Customer Name: " + item.CustomerName);
                    Console.WriteLine("Address: " + item.Address);
                    Console.WriteLine("Landmark: " + item.Landmark);
                    Console.WriteLine("City: " + item.City);
                    Console.WriteLine("Country: " + item.Country);
                    Console.WriteLine("Mobile: " + item.Mobile);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void EditCustomer()
        {
            try
            {
                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                //Create a new Customer object
                Customer customer = new Customer();

                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();
                Console.WriteLine("\n**********ALL CUSTOMERS*************");
                //read all customers
                foreach (var item in allCustomers)
                {
                    Console.WriteLine("Customer Code: " + item.CustomerCode);
                    Console.WriteLine("Customer Name: " + item.CustomerName);
                    Console.WriteLine("Address: " + item.Address);
                    Console.WriteLine("Landmark: " + item.Landmark);
                    Console.WriteLine("City: " + item.City);
                    Console.WriteLine("Country: " + item.Country);
                    Console.WriteLine("Mobile: " + item.Mobile);
                    Console.WriteLine();
                }

                Console.WriteLine("\nEnter the Customer Code of a customer you want to edit: ");
                string userInput = Console.ReadLine();

                //Validating user input
                bool result = long.TryParse(userInput, out long customerCode);
                if (result == false)
                    throw new FormatException("The input is not in correct format\n");

                //Validating customer number
                Customer? cust = customersBusinessLogicLayer.GetCustomersByCondition(ct => ct.CustomerCode == customerCode).FirstOrDefault();
                if (cust == null)
                    throw new CustomerException($"The customer with Customer Code: {customerCode} was not found!\n");

                //Receiving User inputs
                Console.WriteLine("Please enter new Customer information\n");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();
                customer.CustomerCode= customerCode;

                //Updating with new values
                bool isUpdated = customersBusinessLogicLayer.UpdateCustomer(customer);

                //Displaying appropriate success message
                if (isUpdated == true)
                    Console.WriteLine("\nThe customer is successfully updated!");
                else
                    Console.WriteLine("\nThe customer couldn't be updated");
           


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DeleteCustomer()
        {
            ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

            CustomersPresentation.ViewCustomers();

            Console.WriteLine("\nPlease enter Customer code of a customer to want to delete: ");
            string userInput = Console.ReadLine();

            //Validating user input
            bool result = long.TryParse(userInput, out long customerCode);
            if (result == false)
                throw new FormatException("The input is not in correct format\n");

            //Validating customer number
            Customer? cust = customersBusinessLogicLayer.GetCustomersByCondition(ct => ct.CustomerCode == customerCode).FirstOrDefault();
            if (cust == null)
                throw new CustomerException($"The customer with Customer Code: {customerCode} was not found!\n");

            bool success = customersBusinessLogicLayer.DeleteCustomer(cust.CustomerID);

            if (success)
                Console.WriteLine($"Customer No {customerCode} was deleted.");

        }


    }

}


