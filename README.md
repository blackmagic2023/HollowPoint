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



# Connecting your MySQL Server to Visual Studio

1. Now for this all to work we need to connect our new MySQL server to your visual studio project. You can acomplish this by selecting 'Tools' > 'Connect to DataBase' as shown below

![connecttodb](https://github.com/blackmagic2023/HollowPoint/assets/149164084/44b51b51-c489-47ae-9fd5-f6f084901d4b)

2. You should see a window appear asking for a 'Server Name'
3. Open your Microsoft Server Management Studio and right click on your Server where we created your database and select 'Connect'

![connect](https://github.com/blackmagic2023/HollowPoint/assets/149164084/997158f0-21b5-4434-aec8-f136ce50d32c)

4. You should see a window appear with your server name

![sername](https://github.com/blackmagic2023/HollowPoint/assets/149164084/975661f2-f6b8-4351-a786-5e44523cc81f)

5. Copy your servername and paste it Microsoft Visual studio and click 'Refresh'
6. you should now be able to select your DataBase 'HPtargets'

![selectdb](https://github.com/blackmagic2023/HollowPoint/assets/149164084/c7394d3c-5b24-4198-b04e-8f99adb49a84)

7. Select the DataBase and click 'Okay'

You have now added everything you need for the project to work in beta



Copyright © 2024 blackmagic

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.















