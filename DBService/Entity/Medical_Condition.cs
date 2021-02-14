using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Entity
{
    public class Medical_Condition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Med_Condition { get; set; }
        public string Date_Diagnosis { get; set; }
        public string Doctor { get; set; }
        public string Clinic { get; set; }
        public string Treatment { get; set; }
        public string Condition_Desc { get; set; }
        public string Patient_Codition { get; set; }
        public string Comments { get; set; }

        public Medical_Condition()
        {

        }

        public Medical_Condition(string id, string name, string med_condition, string date_diagnosis, string doctor, string clinic, string treatment, string condition_desc, string patient_codition, string comments)
        {
            Id = id;
            Name = name;
            Med_Condition = med_condition;
            Date_Diagnosis = date_diagnosis;
            Doctor = doctor;
            Clinic = clinic;
            Treatment = treatment;
            Condition_Desc = condition_desc;
            Patient_Codition = patient_codition;
            Comments = comments;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Medical_Condition (Name, Med_Condition, Date_Diagnosis, Doctor, Clinic, Treatment, Condition_Desc, Patient_Codition, Comments) " +
                "VALUES (@paraName, @paraMed_Condition, @paraDate_Diagnosis,@paraDoctor,@paraClinic,@paraTreatment,@paraCondition_Desc,@paraPatient_Codition,@paraComments)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraMed_Condition", Med_Condition);
            sqlCmd.Parameters.AddWithValue("@paraDate_Diagnosis", Date_Diagnosis);
            sqlCmd.Parameters.AddWithValue("@paraDoctor", Doctor);
            sqlCmd.Parameters.AddWithValue("@paraClinic", Clinic);
            sqlCmd.Parameters.AddWithValue("@paraTreatment", Treatment);
            sqlCmd.Parameters.AddWithValue("@paraCondition_Desc", Condition_Desc);
            sqlCmd.Parameters.AddWithValue("@paraPatient_Codition", Patient_Codition);
            sqlCmd.Parameters.AddWithValue("@paraComments", Comments);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Medical_Condition SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Medical_Condition where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Medical_Condition emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string name = row["Name"].ToString();
                string med_condition = row["Med_Condition"].ToString();
                string date_diagnosis = row["Date_Diagnosis"].ToString();
                string doctor = row["Doctor"].ToString();
                string clinic = row["Clinic"].ToString();
                string treatment = row["Treatment"].ToString();
                string condition_desc = row["Condition_Desc"].ToString();
                string patient_codition = row["Patient_Codition"].ToString();
                string comments = row["Comments"].ToString();
                emp = new Medical_Condition(Id,name, med_condition, date_diagnosis, doctor, clinic, treatment,condition_desc,patient_codition,comments);
            }
            return emp;
        }
        public List<Medical_Condition> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Medical_Condition";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Medical_Condition> empList = new List<Medical_Condition>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string name = row["Name"].ToString();
                string med_condition = row["Med_Condition"].ToString();
                string date_diagnosis = row["Date_Diagnosis"].ToString();
                string doctor = row["Doctor"].ToString();
                string clinic = row["Clinic"].ToString();
                string treatment = row["Treatment"].ToString();
                string condition_desc = row["Condition_Desc"].ToString();
                string patient_codition = row["Patient_Codition"].ToString();
                string comments = row["Comments"].ToString();
                Medical_Condition obj = new Medical_Condition(Id, name, med_condition, date_diagnosis, doctor, clinic, treatment, condition_desc, patient_codition, comments);
                empList.Add(obj);
            }
            return empList;
        }
        public int UpdateMedicalConditionById(string id, string patient_condition, string comments)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Medical_Condition SET Patient_Codition = @paraPatient_Condition, Comments = @paraComments where Id = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraPatient_Condition", patient_condition);
            sqlCmd.Parameters.AddWithValue("@paraComments", comments);
            sqlCmd.Parameters.AddWithValue("@paraId", id);


            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}
