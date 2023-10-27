# Creating Form1

When you add the menustrip make sure to have a place under the first dropdown like in the image below

![SettingsMenuBarDropDown](https://github.com/blackmagic2023/HollowPoint/assets/149164084/d800adf0-2f6d-495d-8a25-f922dbbced46)


## Form Objects

The main form consists of 7 elements not counting the labels. Those elements include;

1. MenuStrip (MenuStrip1) - Settings > Scan Settings, HollowPoint > RapidFire
2. Listbox (ListBox1) - 'Candidate'
3. ListBox (ListBox2) - 'Target'
4. Button (Button1) - 'Generate Candidate'
5. Button (Button2) - 'Clear Candidate'
6. Button (Button3) - 'Propogate Targets'
7. Button (Button4) - 'Clear Targets'


# Code Requirements

1. Locate your directory "C:\User\yourusername\Documents\"
2. Create a folder in your Documents and name it 'hollowpoint'
3. Create 2 Text Documents; 1 named 'Online.txt', 2 named 'candidate.txt'
4. Create another folder and name it 'dll'


# Notes

You will have to install this imported dll 'Imports System.Data.SqlClient' 
Microsoft Visual Studio will give you the option to 'Show possible fixes' 
with the sub option 'Install Microsoft.sqlclient'

## If you do not see that option you can click 'Project' and find 'Manage NuGet Packages' 

![vspackageinstaller](https://github.com/blackmagic2023/HollowPoint/assets/149164084/6c9edf8e-2aa6-43f1-b6fa-8a828dda5d7d)

Click 'Browse' search for 'sqlclient' install 'Microsoft.Data.SqlClient'

![installpkg](https://github.com/blackmagic2023/HollowPoint/assets/149164084/0e42d614-4631-42b4-8ee0-8eed502e472c)
