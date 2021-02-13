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

        //User Methods 
        public User GetOneUser(string id)
        {
            User user = new User();
            return user.SelectByID(id);
        }
        public int AddOneUser(string name, string password, string salt, string email, string phoneNo, string role, string verified)
        {
            User user = new User();
            return user.AddUser(name, password,salt,email,phoneNo,role,verified);
        }
        public int EditOneUser(string id, string name, string email, string mobile)
        {
            User user = new User();
            return user.UpdateUser(id, name, email, mobile);
        }
        public int UpdateOneUser(string id, string name, string email, string mobile, string password)
        {
            User user = new User();
            return user.UpdateUserInfo(id, name, email, mobile, password);
        }
        public int DeleteOneUser(string id)
        {
            User user = new User();
            return user.DeleteUser(id);
        }
        public int AddCaretaker(string id)
        {
            User user = new User();
            return user.AddCaretaker(id);
        }
        public int RemoveCaretaker(string id)
        {
            User user = new User();
            return user.RemoveCaretaker(id);
        }
        public int CheckOneUser(string email)
        {
            User user = new User();
            return user.CheckUser(email);
        }
        public int CheckPhoneNo(string phoneno)
        {
            User user = new User();
            return user.CheckPhoneNo(phoneno);
        }
        public int VerifyOneUser(string email)
        {
            User user = new User();
            return user.VerifyUser(email);
        }
        public int ChangePassword(string password, string email)
        {
            User user = new User();
            return user.ChangePassword(password, email);
        }
        public User GetOneUserByEmail(string email)
        {
            User user = new User();
            return user.SelectByEmail(email);
        }
        public User GetOneUserByPhoneNo(string phonoNo)
        {
            User user = new User();
            return user.SelectByPhone(phonoNo);
        }
        public List<User> GetAllUsers()
        {
            User user = new User();
            return user.SelectAll();
        }
        public List<User> GetAllPatients()
        {
            User user = new User();
            return user.SelectAllPatients();
        }
        public List<User> GetAllEmployees()
        {
            User user = new User();
            return user.SelectAllEmployees();
        }
        public displayUser ShowOneUser(string id)
        {
            displayUser user = new displayUser();
            return user.DisplayByID(id);
        }
        public List<displayUser> ShowAllUsers()
        {
            displayUser user = new displayUser();
            return user.DisplayAll();
        }
        public List<displayUser> ShowAllPatients()// dont use this
        {
            displayUser user = new displayUser();
            return user.DisplayAllPatients();
        }
        public List<displayUser> ShowAllEmployees()
        {
            displayUser user = new displayUser();
            return user.DisplayAllEmployees();
        }
        public List<displayUser> ShowSearchedEmployees(string name)
        {
            displayUser user = new displayUser();
            return user.DisplaySearchedEmployees(name);
        }
        public List<displayUser> ShowSearchedPatients(string name)// dont use this
        {
            displayUser user = new displayUser();
            return user.DisplaySearchedPatients(name);
        }
        public displayPatient DisplayOnePatient(string email)
        {
            displayPatient user = new displayPatient();
            return user.PatientDisplayByEmail(email);
        }
        public List<displayPatient> DisplayAllPatients()
        {
            displayPatient user = new displayPatient();
            return user.DisplayAllPatients();
        }
        public List<displayPatient> DisplayCaretakers()
        {
            displayPatient user = new displayPatient();
            return user.DisplayAllCaretakers();
        }
        public List<displayPatient> DisplayPatientsOnly()
        {
            displayPatient user = new displayPatient();
            return user.DisplayAllPatientsOnly();
        }
        public List<displayPatient> DisplayAllSearchedPatients(string name)
        {
            displayPatient user = new displayPatient();
            return user.DisplayAllSearchPatients(name);
        }

        public string GetEmailbyCode(string code)
        {
            EmailCode user = new EmailCode();
            return user.SelectByCode(code);
        }
        public int CheckCodeExist(string code)
        {
            EmailCode user = new EmailCode();
            return user.CheckCode(code);
        }
        public string CheckCodeByEmail (string email)
        {
            EmailCode user = new EmailCode();
            return user.CheckCodeByEmail(email);
        }
        public int AddCode(string email, string code)
        {
            EmailCode user = new EmailCode();
            return user.Insert(email, code);
        }

        //CardInfo Methods - Hasan
        public int CreateCardInfo(string userID, string cardName, string cardNumber,
            DateTime cardExpiry, string cvvNumber, byte[] iv, byte[] key, bool stillValid, string uniqueIdentifier)
        {
            CardInfo cif = new CardInfo(userID, cardName, cardNumber, cardExpiry, cvvNumber, iv, key, stillValid, uniqueIdentifier);
            return cif.Insert();
        }
        public CardInfo GetCardByCardNumber(string userID, string uniqueIdentifier)
        {
            CardInfo cif = new CardInfo();
            return cif.GetCardByCardNumber(userID, uniqueIdentifier);
        }
        public List<CardInfo> GetAllCards(string userID)
        {
            CardInfo cif = new CardInfo();
            return cif.SelectAllCards(userID);
        }
        public bool CheckCardByCardNumber(string uniqueIdentifier)
        {
            CardInfo cif = new CardInfo();
            return cif.CheckCardByCardNumber(uniqueIdentifier);
        }
        public int DeleteByCardNumber(string uniqueIdentifier)
        {
            CardInfo cif = new CardInfo();
            return cif.DeleteByCardNumber(uniqueIdentifier);
        }

        //Receipt Entity Methods - Hasan
        public int CreateReceipt(string userID, DateTime dateSale, double totalSum, bool isPaid, string receiptLink, string uniqueIdentifier)
        {
            Receipt rep = new Receipt(userID, dateSale, totalSum, isPaid, receiptLink, uniqueIdentifier);
            return rep.Insert();

        }

        public List<Receipt> SelectAllReceipts(string userID)
        {
            Receipt rep = new Receipt();
            return rep.SelectAllReceipts(userID);
        }

        public Receipt SelectByReceiptID(string userID, string uniqueIdentifier)
        {
            Receipt rep = new Receipt();
            return rep.SelectByReceiptID(userID, uniqueIdentifier);
        }

        public List<Receipt> SelectAllReceiptsAdmin()
        {
            Receipt rep = new Receipt();
            return rep.SelectAllReceiptsAdmin();
        }

        /* Appointment Methods - Wilfred */

        public List<Appointment> GetAllApptAdmin()
        {
            Appointment appt = new Appointment();
            return appt.SelectAllForAdmin();
        }

        public List<Appointment> GetAllApptUser(int uid)
        {
            Appointment appt = new Appointment();
            return appt.SelectAllForOneUser(uid);
        }

        public List<Appointment> GetAllApptUserUpcoming(int uid)
        {
            Appointment appt = new Appointment();
            return appt.SelectAllForOneUserUpcoming(uid);
        }

        public List<Appointment> GetAllApptUserPast(int uid)
        {
            Appointment appt = new Appointment();
            return appt.SelectAllForOneUserPast(uid);
        }

        public List<Appointment> GetAllApptUserMissed(int uid)
        {
            Appointment appt = new Appointment();
            return appt.SelectAllForOneUserMissed(uid);
        }

        public int CreateAppointment(int patientID, string appointmentType, DateTime dateTime, string status)
        {
            Appointment appt = new Appointment();
            appt.patientID = patientID;
            appt.appointmentType = appointmentType;
            appt.dateTime = dateTime;
            appt.status = status;
            return appt.Insert();
        }

        public Appointment GetOneAppt(int patientID, DateTime dateTime)
        {
            Appointment appt = new Appointment();
            return appt.SelectOne(patientID, dateTime);
        }

        public int UpdateOneAppt(int patientID, string appointmentType, DateTime oldTime, DateTime newTime)
        {
            Appointment appt = new Appointment();
            return appt.UpdateOne(patientID, appointmentType, oldTime, newTime);
        }

        public int DeleteOneAppt(int uid, DateTime dateTime)
        {
            Appointment appt = new Appointment();
            return appt.DeleteOne(uid, dateTime);
        }

        public Photo GetOnePhoto(string id)
        {
            Photo photo = new Photo();
            return photo.SelectById(id);
        }

        public Caregiver GetOneCG(string id)
        {
            Caregiver cg = new Caregiver();
            return cg.SelectById(id);
        }

        /* Appointments End - */


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
