# Creating the ScanSettings Form

## Form Objects

The main form consists of 31 elements not counting the labels. Those elements include;

1. TextBox (ScanCycleBox) [Placeholder=1500] - 'number of candidates to generate each time'
2. Button (ApplyScanCycleBtn) [Text='Set'] - save the number in the scancycle textbox
3. TextBox (DataDirectoryBox) - directory where the 'candidate.txt' file is to be located 
4. Button (SetDataDirectoryBtn) [Text='Set'] - Saves the directory entered in the datadirectory textbox
5. CheckBox (CheckBox1) [Text='Automation Enabled'] [Checked=False] - If checked the program will self propegate and scan after 'generate' is clicked
6. CheckBox (RegionScanTextBox) - If enabled candidate generation will be restricted to the quaderant bounds or region bounds located in this Form
7. RadioButton (SpecifyRegionRadio) - If selected the candidate generation will be limited to the user manule input
8. RadioButton (SelectRegionRadio) - If selected the candidate generation will be limited to the region selected
9. GroupBox (SpecifyRegionGB) - This holds the input for manual quad ranges
10. GroupBox (SelectRegionGB) - This holds the radio buttons for the regions
11. TextBox (Q1min) [Placeholder=1]
12. Textbox (Q1max) [Placeholder=255]
13. TextBox (Q2min) [Placeholder=1]
14. Textbox (Q2max) [Placeholder=255]
15. TextBox (Q3min) [Placeholder=1]
16. Textbox (Q3max) [Placeholder=255]
17. TextBox (Q4min) [Placeholder=1]
18. Textbox (Q4max) [Placeholder=255]
19. Button (RegionSpecificationBtn) - This saves the above user defined ranges
20. RadioButton (RegionUSARadio)
21. RadioButton (RadioButton1)
22. RadioButton (RadioButton2)
23. RadioButton (RadioButton3)
24. RadioButton (RadioButton4)
25. RadioButton (RadioButton5)
26. RadioButton (RadioButton6)
27. RadioButton (RadioButton7)
28. RadioButton (RadioButton8)
29. RadioButton (RadioButton9)
30. RadioButton (RadioButton10) 



# Code Requirements

1. Locate your 'Properties' dropdown at the top menu of Visual Studio
2. Click it and select 'HollowPoint Properties'

![vspackageinstaller](https://github.com/blackmagic2023/HollowPoint/assets/149164084/6c9edf8e-2aa6-43f1-b6fa-8a828dda5d7d)

3. A menu should appear. Select on the bottom left of the menu 'Settings'
4. Now in the center there should be a link saying 'create or open settings' click this to create a settings file for the project

![create settings](https://github.com/blackmagic2023/HollowPoint/assets/149164084/a634b937-e27f-4442-be4f-b0ccd9d6d360)

5. Now you should see something similar to an excel spreadsheet. Fill all the data from the image below into this settings document until the 2 are identical.

![settings](https://github.com/blackmagic2023/HollowPoint/assets/149164084/0b612433-8afa-4bdd-9f76-ed8ff9f8752c)




# Notes

That's all she wrote... For the first 2 Forms


