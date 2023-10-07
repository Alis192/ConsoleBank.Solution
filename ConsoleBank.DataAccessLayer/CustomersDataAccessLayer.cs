using ConsoleBank.DataAccessLayer.DALContracts;
using ConsoleBank.Entities;
using ConsoleBank.Exceptions;

namespace ConsoleBank.DataAccessLayer
{

    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Fields
        private static List<Customer> _customers;
        #endregion


        #region Constructors
        static CustomersDataAccessLayer()
        {
            //Seed Data 
            _customers = new List<Customer>()
            {
                 new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerCode = 1001,
                    CustomerName = "John Doe",
                    Address = "123 Main St",
                    Landmark = "Near Central Park",
                    City = "New York",
                    Country = "USA",
                    Mobile = "1234567890"
                },
                new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerCode = 1002,
                    CustomerName = "Jane Smith",
                    Address = "456 Maple Ave",
                    Landmark = "Next to the Library",
                    City = "Chicago",
                    Country = "USA",
                    Mobile = "0987654321"
                },
                new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerCode = 1003,
                    CustomerName = "Bob Johnson",
                    Address = "789 Oak Dr",
                    Landmark = "Opposite the School",
                    City = "Los Angeles",
                    Country = "USA",
                    Mobile = "1122334455"
                },
                new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerCode = 1004,
                    CustomerName = "Alice Williams",
                    Address = "321 Pine Ln",
                    Landmark = "Behind the Mall",
                    City = "San Francisco",
                    Country = "USA",
                    Mobile = "5566778899"
                },
                new Customer()
                {
                    CustomerID = Guid.NewGuid(),
                    CustomerCode = 1005,
                    CustomerName = "Charlie Brown",
                    Address = "654 Elm Pl",
                    Landmark = "Near the Stadium",
                    City = "Houston",
                    Country = "USA",
                    Mobile = "9988776655"
                }
            };
        }
        #endregion


        #region Properties
        /// <summary>
        /// Represents source customers collection
        /// </summary>
        private static List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //create a new customers list
                List<Customer> customersList = new List<Customer>();

                //copy all customers from the soruce collection into the newCustomers list
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //create a new customers list
                List<Customer> customersList = new List<Customer>();

                //filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                //copy all customers from the soruce collection into the newCustomers list
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Adds a new customer to the existing list
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new Guid
                customer.CustomerID = Guid.NewGuid();

                //add customer
                Customers.Add(customer);

                return customer.CustomerID;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Updates an existing customer's details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Determines whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find existing customer by CustomerID
                Customer? existingCustomer = Customers.Find(item => item.CustomerCode == customer.CustomerCode);

                //update all details of customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;


                    return true; //indicates the customer is updated
                }
                else
                {
                    return false; //indicates no object is updated
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes an existing customer based on CustomerID
        /// </summary>
        /// <param name="customerID">CustomerID to delete</param>
        /// <returns>Indicates whether the customer is deleted or not</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                //delete customer by CustomerID
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true;  //indicates one or more customers are deleted
                }
                else
                {
                    return false; //indicates no customer is deleted
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CustomerAddAcount(long customerCode, Account account)
        {
            try
            {
                Customer? customer = Customers.Find(cust => cust.CustomerCode == customerCode);
                if (customer == null)
                {
                    throw new CustomerException("No Customer found with given Customer Code");
                }

                customer.Accounts.Add(account);
            }
            catch (CustomerException)
            {
                throw;
            }
            catch(AccountException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }


        #endregion
    }
}
