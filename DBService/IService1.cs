using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
// Bring in entity folder
using DBService.Entity;

namespace DBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]

        User GetOneUser(int id);

        [OperationContract]
        List<User> GetAllUsers();

        [OperationContract]
        List<Appointment> GetAllApptAdmin();

        [OperationContract]

        List<Appointment> GetAllApptUser(int uid);
        [OperationContract]

        List<Appointment> GetAllApptUserUpcoming(int uid);

        [OperationContract]

        List<Appointment> GetAllApptUserPast(int uid);

        [OperationContract]

        List<Appointment> GetAllApptUserMissed(int uid);

        [OperationContract]
        int CreateAppointment(int patientID, string appointmentType, DateTime dateTime, string status);

        // Taken from practical 4, methods are listed in the abstract interface, method bodies are in service1.cs
        /*        [OperationContract]
                List<Employee> GetAllEmployee();
                [OperationContract]
                Employee GetEmployeeByNric(string nric);

                [OperationContract]
                int CreateEmployee(string nric, string name, DateTime dob, string dept, double wage);

                [OperationContract]

                Customer GetCustomerById(string id);*/
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DBService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
