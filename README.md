# MultiUser_AddressBook

 -> Multi User AddressBook is simply the AddressBook in which the user can stored the Contact Details.
    Like Name, Country, State, City, BloodGroup, ContactCategory, LinkedIn ID, Facebook ID, etc....
    Every user register the account and then after login they can able to add,delete and update the below different field according to their own choice. and also stored the         Contact details of their own Contacts. Similar like the Single User AddressBook.
   
  # Design of Multi User Address Book
  
 -> For Complete this purpose, I designed this AddressBook. Now, we can see how I designed this website:
 
 -> There are six different table are available in database:
 
    - Country  :- In which user can able to add,Update,delete and also see the CountryName and Country Code in the Grid View Formate.For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure.
    - State    :- In which user can select the CountryName from the dropdown list of the Country Which are added by the User ahead in the Country Table.And then add State name. User can also click on the delete and edit button to delete and edit the data which are available in the State Table which is represent on the main Grid view. For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure. 
    - City     :- In which user can select the StateName from the dropdown list of the State Which are added by the User ahead in the State Table. And then add City name. User can also click on the delete and edit button to delete and edit the data which are available in the City Table which is represent on the main Grid view. For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure. 
    - BloodGroup :- In which user can able to add,Update,delete and also see the BloodGroup Name in the Grid View Formate. For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure.  
    - Contact Categeory :- In which user can able to add,Update,delete and also see the ContactCategory like Student,Software Developer,etc.. in the Grid View Formate. For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure.
    - Contact  :- All the details of the Contact like, Contact Name, Select Country,State,City fro the dropdown menu which are fill by the dependecy column like first  user need to select the CountryName,then According to the CountryName ahead added by user in the Country Table all are display in the dropdown menu.Then after according to choose the country Name Statename dropdown menu will be filled, similaryly for State to City. then Select the BloodGroup and Contact Category Select from the dropdown list. Then after add the  LinkedIn ID, Facebook ID, etc... In which user can able to add,Update,delete and also see the all the above details in the Grid View Formate. For the Insert, Update and Delete operations are Performe by using the SQL Queries which are written using the Stored Procedure. 
  
  # Advantage of MultiUser Address Book
  
  -> Disadvange of the Single User AddressBook is the Privacy and Security of the Contact deatils. Because all the users which have the account see the all details of other          users add contact details as well. So, any user can see the all deatils of the their own added data as well as other users's Contact details.
  
  -> For Solution of this Problem I designed the Multi User Address Book in which every User can see the data of thier own added. Not able to see the data of other users's            added. So, this solution is maintain the Privacy and Security of all users's added data.
