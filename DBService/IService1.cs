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

        User GetOneUser(string id);
        [OperationContract]
        int AddOneUser(string name, string password, string salt, string email, string phoneNo, string role, string verified);
        [OperationContract]
        int EditOneUser(string id, string name, string email, string mobile);
        [OperationContract]

        int DeleteOneUser(string id);
        [OperationContract]
        int AddCaretaker(string id);
        [OperationContract]
        int RemoveCaretaker(string id);
        [OperationContract]
        int CheckOneUser(string email);
        [OperationContract]
        int VerifyOneUser(string email);
        [OperationContract]
        int ChangePassword(string password, string email);
        [OperationContract]
        User GetOneUserByEmail(string email);
        [OperationContract]
        List<User> GetAllUsers();
        [OperationContract]
        List<User> GetAllPatients();
        [OperationContract]
        List<User> GetAllEmployees();
        [OperationContract]
        displayUser ShowOneUser(string id);

        [OperationContract]
        List<displayUser> ShowAllUsers();
        [OperationContract]
        List<displayUser> ShowAllPatients();
        [OperationContract]
        List<displayUser> ShowAllEmployees();
        [OperationContract]
        List<displayUser> ShowSearchedEmployees(string name);
        [OperationContract]
        List<displayUser> ShowSearchedPatients(string name);
        [OperationContract]
        string GetEmailbyCode(string code);
        [OperationContract]
        int CheckCodeExist(string code);
        [OperationContract]
        string CheckCodeByEmail(string email);
        [OperationContract]
        int AddCode(string email, string code);
        //CardInfo Entity Class
        //[OperationContract]
        //int CreateCardInfo(byte[] cardName, byte[] cardNumber,
        //  byte[] cardExpiry, byte[] cvvNumber, byte[] iv, byte[] key);
        [OperationContract]
        int CreateCardInfo(string cardName, string cardNumber,
            DateTime cardExpiry, string cvvNumber, byte[] iv, byte[] key, bool stillValid, string uniqueIdentifier);

        [OperationContract]
        CardInfo GetCardByCardNumber(string uniqueIdentifier);

        [OperationContract]
        List<CardInfo> GetAllCards();

        [OperationContract]
        int DeleteByCardNumber(string uniqueIdentifier);
        [OperationContract]
        bool CheckCardByCardNumber(string uniqueIdentifier);

        [OperationContract]
        int UpdateByCardNumber(string previousCardNumber, string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber);

        [OperationContract]
        int CreateReceipt(DateTime dateSale, double totalSum, bool isPaid);

        // Appointments IService Methods
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

        [OperationContract]
        Appointment GetOneAppt(int patientID, DateTime dateTime);

        [OperationContract]
        int UpdateOneAppt(int patientID, string appointmentType, DateTime oldTime, DateTime newTime);

        [OperationContract]
        int DeleteOneAppt(int uid, DateTime dateTime);

        [OperationContract]

        Photo GetOnePhoto(string id);

        [OperationContract]

        Caregiver GetOneCG(string id);




        // End of Appointments IService Methods

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
