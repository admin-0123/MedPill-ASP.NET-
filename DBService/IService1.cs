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
        int UpdateOneUser(string id, string name, string email, string mobile, string password);
        [OperationContract]
        int DeleteOneUser(string id);
        [OperationContract]
        int AddCaretaker(string id);
        [OperationContract]
        int RemoveCaretaker(string id);
        [OperationContract]
        int CheckOneUser(string email);
        [OperationContract]
        int CheckPhoneNo(string phoneno);
        [OperationContract]
        int VerifyOneUser(string email);
        [OperationContract]
        int ChangePassword(string password, string email);
        [OperationContract]
        User GetOneUserByEmail(string email);
        [OperationContract]
        User GetOneUserByPhoneNo(string phonoNo);
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
        displayPatient DisplayOnePatient(string email);
        [OperationContract]
        List<displayPatient> DisplayAllPatients();
        [OperationContract]
        List<displayPatient> DisplayCaretakers();
        [OperationContract]
        List<displayPatient> DisplayPatientsOnly();
        [OperationContract]
        List<displayPatient> DisplayAllSearchedPatients(string name);
        [OperationContract]
        string GetEmailbyCode(string code);
        [OperationContract]
        int CheckCodeExist(string code);
        [OperationContract]
        string CheckCodeByEmail(string email);
        [OperationContract]
        int AddCode(string email, string code);

        //CardInfo Entity Class
        [OperationContract]
        int CreateCardInfo(string userID, string cardName, string cardNumber,
            DateTime cardExpiry, string cvvNumber, byte[] iv, byte[] key, bool stillValid, string uniqueIdentifier);

        [OperationContract]
        CardInfo GetCardByCardNumber(string userID, string uniqueIdentifier);

        [OperationContract]
        List<CardInfo> GetAllCards(string userID);

        [OperationContract]
        int DeleteByCardNumber(string uniqueIdentifier);
        [OperationContract]
        bool CheckCardByCardNumber(string uniqueIdentifier);

        //[OperationContract]
        //int UpdateByCardNumber(string previousCardNumber, string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber);

        [OperationContract]
        int CreateReceipt(string userID, DateTime dateSale, double totalSum, bool isPaid, string receiptLink, string uniqueIdentifier);

        [OperationContract]
        List<Receipt> SelectAllReceipts(string userID);

        [OperationContract]
        Receipt SelectByReceiptID(string userID, string uniqueIdentifier);

        [OperationContract]
        List<Receipt> SelectAllReceiptsAdmin();

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

        List<Appointment> GetAllApptAdminUpcoming();

        [OperationContract]

        List<Appointment> GetAllApptAdminPast();

        [OperationContract]

        List<Appointment> GetAllApptAdminMissed();

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
        int CheckPhotoExist(string id);
        [OperationContract]
        int AddOnePhoto(string id, string img);
        [OperationContract]
        int UpdateOnePhoto(string id, string img);

        [OperationContract]
        Caregiver GetOneCG(string id);

        [OperationContract]

        List<User> GetAllDoctors();


        [OperationContract]

        User GetOneDoctor(string doctor_name);

        [OperationContract]

        int UpdateDoctor(int uid, DateTime old_time, int doctor_id);

        [OperationContract]

        User GetPatientByName(string patient_name);

        [OperationContract]

        int ApproveCaregiver(string cg_id, string patient_id);


        //

        [OperationContract]
        int CreateReport(string id, string dname, string pname, string clinic, string date_of_report, string details);
        [OperationContract]
        Report GetReportById(string id);
        [OperationContract]
        List<Report> GetAllReport();
        [OperationContract]
        int UpdateReportById(string id, string dname, string pname, string clinic, string date_of_report, string details);

        [OperationContract]
        int CreateDetails(string name, string nric, string date_of_birth, string gender, string phone, string email, string address, string postal);
        [OperationContract]
        Details GetDetailsById(string id);
        [OperationContract]
        List<Details> GetAllDetails();
        [OperationContract]
        int UpdateDetailsById(string id, string name, string nric, string date_of_birth, string gender, string phone, string email, string address, string postal);

        [OperationContract]
        int CreateMedicalCondition(string id, string name, string med_condition, string date_diagnosis, string doctor, string clinic, string treatment, string condition_desc, string patient_codition, string comments);
        [OperationContract]
        Medical_Condition GetMedicalConditionById(string id);
        [OperationContract]
        List<Medical_Condition> GetAllMedicalCondition();
        [OperationContract]
        int UpdateMedicalConditionById(string id, string Patient_Condition, string Comments);

        [OperationContract]
        int CreatePatient_MC(string reg_no, string name, string nric, string duration, string type_of_leave, string clinic, string signature, string date);
        [OperationContract]
        Patient_MC GetPatient_MCById(string id);
        [OperationContract]
        List<Patient_MC> GetAllPatient_MC();

        [OperationContract]
        int CreatePayment_Report(string date_of_appointment, string purpose_visit, string fees);
        [OperationContract]
        Payment_Report GetPayment_ReportById(string id);
        [OperationContract]
        List<Payment_Report> GetAllPayment_Report();

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
