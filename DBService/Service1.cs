﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Bring in entity folder
using DBService.Entity;

namespace DBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public User GetOneUser(string id)
        {
            User user = new User();
            return user.SelectByID(id);
        }
        public List<User> GetAllUsers()
        {
            User user = new User();
            return user.SelectAll();
        }

        //CardInfo Methods
        public int CreateCardInfo(string cardName, string cardNumber, 
            DateTime cardExpiry, string cvvNumber, byte[] iv, byte[] key)
        {
            CardInfo cif = new CardInfo(cardName, cardNumber, cardExpiry, cvvNumber, iv, key);
            return cif.Insert();
        }
        public CardInfo GetCardByCardNumber(string cardNumber)
        {
            CardInfo cif = new CardInfo();
            return cif.GetCardByCardNumber(cardNumber);
        }
        public List<CardInfo> GetAllCards()
        {
            CardInfo cif = new CardInfo();
            return cif.SelectAllCards();
        }
        public int DeleteByCardNumber(string cardNumber)
        {
            CardInfo cif = new CardInfo();
            return cif.DeleteByCardNumber(cardNumber);
        }
        public int UpdateByCardNumber(string previousCardNumber, string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber)
        {
            CardInfo cif = new CardInfo();
            return cif.UpdateByCardNumber(previousCardNumber, cardName, cardNumber, cardExpiry, cvvNumber);
        }
        /* 
         Note by Hasan 4/1/2021

        Will put in more methods here for other classes
         
         
         
         */

        // Taken from practical 4, here all the method bodies for the methods listed in IService1.CS
        /*        public List<Employee> GetAllEmployee()
                {
                    Employee emp = new Employee();
                    return emp.SelectAll();
                }

                public Employee GetEmployeeByNric(string nric)
                {
                    Employee emp = new Employee();
                    return emp.SelectByNric(nric);
                }

                public int CreateEmployee(string nric, string name, DateTime dob, string dept, double wage)
                {
                    Employee emp = new Employee(nric, name, dob, dept, wage);
                    return emp.Insert();
                }

                public Customer GetCustomerById(string id)
                {
                    Customer obj = new Customer();
                    return obj.SelectById(id);
                }*/
    }
}
