Database setting.

Open SqlExpress and import the database backup located in the DataBase folder.


Application Setting

Open IIS 7
Copy the api folder in the root folder. Open IIS an convert the folder to an application. 
Use any apppool with Framework 4.5

Copy the UIBuildCrud folder into the root folder. Open IIS an convert the folder to an application. 
Use any apppool with Framework 4.5


Go to BuildCRUD\UIBuildCrud\app\services\common.services.js, edit the file and change the serverPath variable,
set the api url value you hosted in the IIS server.

