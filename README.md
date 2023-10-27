# HollowPoint 2023 | blackmagic, Hack Theory Group

## All in one information gathering tool and exploitation framework...



![HollowPointIcon](https://github.com/blackmagic2023/HollowPoint/assets/149164084/b3be813c-f066-441b-8197-adc8aa95f281)

---------------------------------------------------------------------------------------------------------------------------

# Form1

![Form1](https://github.com/blackmagic2023/HollowPoint/assets/149164084/185d0434-2afc-4930-ad0b-85b824275927)


# ScanSettings

![ScanSettings](https://github.com/blackmagic2023/HollowPoint/assets/149164084/3dbe5aef-d3b6-4719-b919-0181ce0073a5)


# RapidFire

![RapidFire](https://github.com/blackmagic2023/HollowPoint/assets/149164084/0a0e6993-61d1-4031-892a-aee2eb4253f5)


# zenmap

![zenmap](https://github.com/blackmagic2023/HollowPoint/assets/149164084/f1685e24-f574-46d4-98ed-7c293de773fb)

-----------------------------------------------------------------------------------------------------------------------------

# Features

------------------------------------------------------------------------------------------------------------------------------

# Scanning;


● Advanced internet protocol address generation.

● Custom internet protocol address generation.

● Region defined internet protocol address generation

● Automation option, so you dont have to interact with the software

● Defined region's for generation; Canada, Mexico, USA, Russia, Germany, Australia, Spain, India, UK, China, Japan

● No limitation, go as fast as your computer and network will allow



# Information Gathering;


● Check if a target is using TOR network

● Check if target is using Proxy network

● Check target ping

● Target GEO location

● Get target's host address

● Get target's open ports

● Get target's hosted domains

● Detect target's operating system's

● Complete nmap options included

.

# Terminal;


Command  | Description
--------------------------------------------
● zenmap | complete nmap GUI



# More Coming Soon


# How to install HollowPoint beta

1. Download and install Microsoft Visual Studio IDE with .NET features including VB.NET, C#
2. Run Visual Studio and create a new Windows Form Application
3. Copy every element from the images to your new form (textbox's, buttons, listboxes etc.)
4. Locate the .vb file in this repo to corrospond with the form you are copying
5. Copy the code, go back to your project and double click somewhere on the form to display the code
6. Delete all the code from your project and paste the code from github
7. Fix all the corresponding name related errors by changing the 'Name' property in the form designer (If you don't see it click view in the top left menubar and select 'Properties Window')
8. Change all names to the corresponding elements from the code. Ex. you added a listbox for the target's and, you have a name error in the code saying "TargetListBox does not exist". Change the 'Name' property of the 'Listbox2' to 'TargetListBox' and so on for every element.
9. Execute the program

# Connecting SQL Server to Microsoft Visual Studio IDE

You will need a MySQL server including 1 database and one table. I reccomend using software for this like XAMPP,  Microsoft SQL Server Management Studio (I reccomend this one)
You will also need this for MSSMS SQL Server Installer for Express Editions (SQL2022-SSEI-Expr)
I will not be going into any explaination on the configuration of these applications (There are many resources online explaining how to create a database and table)

![Capture](https://github.com/blackmagic2023/HollowPoint/assets/149164084/78ad38d8-8d8c-421f-8ce6-583a12bd5273)


1. Create a database named HPtargets
2. Create a table and name it targetinfo

![DBandTableExample](https://github.com/blackmagic2023/HollowPoint/assets/149164084/a7b2a74d-154c-4eb5-9381-e3a9daadb6fb)

3. Add the following columns with the corresponding names and values as shown below

![TableConfiguration](https://github.com/blackmagic2023/HollowPoint/assets/149164084/94d4d40e-c988-4a5b-833a-8be6c4f87244)

4. **Make sure to set the 'id' column as the Primary Key. You can do this by right clicking on it and selecting 'Set Primary Key'
5. Right click on the DataBase Table you created on the left hand side. Select 'Edit top 200 rows' to view your new table
6. Now when you are using the connection string and commands you copy here on GitHub they should hopefully work without any issues
