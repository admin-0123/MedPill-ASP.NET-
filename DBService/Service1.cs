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

        public User GetOneUser(int id)
        {
            User user = new User();
            return user.SelectByID(id);
        }
        public List<User> GetAllUsers()
        {
            User user = new User();
            return user.SelectAll();
        }

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
