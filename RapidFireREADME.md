# Creating the RapidFire Form

![RapidFire](https://github.com/blackmagic2023/HollowPoint/assets/149164084/93682e8c-b6fe-4147-8b24-fee157faa381)


## Form Objects

The main form consists of 18 elements not counting the labels. Those elements include;

1. ListView (ListView1) [Columns='Propegated Targets'] - This will be where the targets get displayed pre scan propegation
2. TextBox (AddIPBox) [Text='IP Address'] - This is the input feild to add a single IP address to the target list
3. Button (AddIPBtn) [Text='Add IP'] - This will add the IP from the input feild to the target listbox
4. GroupBox (GroupBox1) - This object will house the checkboxes for the scan options
5. CheckBox (CheckBox1) [Text='IP2Host'] [Checked=False]
6. CheckBox (CheckBox2) [Text='TORCheck'] [Checked=False]
7. CheckBox (CheckBox3) [Text='PortScanning'] [Checked=False]
8. CheckBox (CheckBox4) [Text='IP2Domain'] [Checked=False]
9. CheckBox (CheckBox5) [Text='GEOIP'] [Checked=False]
10. CheckBox (CheckBox6) [Text='ProxyDetection'] [Checked=False]
11. CheckBox (CheckBox7) [Text='Ping'] [Checked=False]
12. Button (Button1) [text='Begin Scanning'] - Starts the scan methods with selected scan options and configuration
13. ListView (ListView2) - This is where all of your targets scan data will be visible in the application (and in the database)
14. Button (Button2) [Text='Refresh'] - This will refresh all of the data in the ListView to the current data that got dumped to the database
15. Button (Button3) [Text='Filter Settings'] - This will display the FilterSettings form
16. RichTextBox (Console) [Text='Console'] - This will give you a live view of the return data from the API
17. TextBox (CommandBox) [Text='-$'] - This is where the user will type pre-defined commands for external and internal functions (Like starting zenmap)



# Code Requirements

For this application's scan functionality you will need to use API's for each scan option. I am using an API from the provider C99.API {https://api.c99.nl}. You may use other api's but will have to make modifications to the code and add things for parsing the data.

1. Create an account on https://api.c99.nl and purchase an API key ($5 per month $25 per year)
2.  Copy your API key and paste it in the RapidFire.vb code where it says "Your_API_Key"

That's all that is needed!

# Notes

That's all she wrote... For the first 3 Forms






