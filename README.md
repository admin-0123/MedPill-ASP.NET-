# Entreprise Development Project
This is done by a group of four students on a Healthcare themed clinic, developed with ASP.NET webform on VS 2019

# Application Name: MedPill Web App 

## Project Team Organisation

1. Wilfred (Group Leader) (Appointment system)
2. Bryan (Login and admin system)
3. Owen (Patient reports, medical condition, medical certificate and changing of personal information)
4. Hasan (Online Payment and stored card info system)

## Executive summary
Our Web Application aims to digitise the work at MedPill Endocrinology Clinic. Our features include view, creating, modifying and deleting appointments slots, a variety of payment methods for users to pay for their treatment as well as saving card information for quick easy payment later on and creating and viewing reports. 

To access these features, users are able to login via their phone number as an alternative to traditional login methods with an email and password.

Our main innovative feature is that all of our users, from doctors to patients, are able to complete all of their tasks solely on our web application since our web application has all the necessary features.

In addition, users are now given more freedom to reschedule or cancel their appointments as they now have the power to do it themselves as compared to the older way of having to contact the receptionist or the staff of a clinic to do it for them.

Our application aims to provide a better user experience for both customers and staff alike.


## Features

User (Bryan)

- All Patients will be able to create and access an account which will allow them to use the other features in the page after verifying the account with their email. They will also be allowed to add a profile picture as well as change information relating to their account by re-entering their password on the change information page. There is also a forget password feature which will send them a link they can use to change their password.
- All employees will have their account created by an admin on the employee overview page, which after creation of an employee account they will be sent an email to set their password. The employees will be able to access their respective pages, for nurse and doctor they will be able to use the patient overview page where they can view and search users by their name or filter the view by whether or not they are a caretaker. The receptionist will be able to access their own receptionist page which allows them to use features only available to the user.
- Admin users will be able to create employee accounts on the employee overview page as well as change the employee’s name, mobile number as needed. They are also able to delete the employee accounts and use a simple search bar on the page to find the employee via their name.
All users can also log in to their account via phone number provided their account is verified beforehand.

Appointment (Wilfred)

- On the customer side,
All patients are able to create appointments, view upcoming, past or missed appointments, cancel appointments and also reschedule appointments for themselves.
In addition, they can sign up to be a caregiver, by choosing another registered patient. Then an email will be sent to that patient notifying him of the request. 
The patient can approve the request by clicking on the link sent within the email or ignore the request.
If the patient is an approved caregiver, he can also create, view, cancel and reschedule appointments for his care receiver.

- On the staff side,
The receptionist can search for a user with their mobile phone number, then create an appointment for them. 
View all appointments in the application, assign doctors to unassigned appointments and help users reschedule or cancel appointments.

Report (Owen)

- Doctors and Nurse are able to generate reports to view all patient’s data. They are able to view the patient’s name, date of the report, clinic of where the report was generated, doctor who wrote the report and the details of the report. All the data is shorten in to a gridview to allow the doctors to view the data easily.
- Along with the access to view all reports, doctors are able to add reports to the patient’s database. They can add a new report with a select amount of doctor names from a dropdown list, along with a select amount of clinics also from a dropdown list, date of the report added, details of the reports.
- Doctors can update the reports in case they made a mistake in the report, or if the patient has a new condition that needs to be recorded in the same details. The reason for not deleting the records is so that the doctors can view past symptoms that the patients have in order to keep track of the growth process of the illness.
- Doctors and nurses can view the medical condition for all patients in a gridview along with viewing all the medical conditions of all patients in a detailed page view. This would allow the current doctors and nurses to understand the medical condition of the patient and not prescribe any wrong or dangerous medicine for the patient.
- Along with the permission to view the different medical conditions, the doctors can add new medical conditions for the patient. This is to allow the doctors to keep track of the patient’s different conditions. The doctor can add the patient's name, medical condition’s name, date of diagnosis, treatment methods, description of the medical condition, patient’s condition, doctors comments, doctor’s name based on a list of dropdown options and clinic of diagnosis based on a list of dropdown options.
- Doctors can also update their patient’s current medical condition based on how the patient is responding to the various treatment methods used on the patient.
- Patients who login into the system can view their personal details in the profile page. This allows them to not only see their own details but also allow them to update their particulars such as changing of address, phone number or email.
- Doctors and nurses can send a digital copy of the written medical certificate to the patient’s email address.

Payment (Hasan)
- All users are able to pay their appointments with debit/credit cards online.
- Users also have the option to save their card information on our website for easy and fast payments in the future.
- PayPal payment is supported for users who prefer alternative payment methods.
- A chatbot that deals with payment related questions which includes questions related to receipts and payment issues.
- Viewing payment receipts on our website.
- A 6-digit OTP is sent whenever the user wants to change any card information via our website.
- SMS Notification whenever there is a change to stored card information and a notification whenever the user makes an online payment.
- Email Notification is used to send a receipt to a user's email whenever they complete an online payment. 


