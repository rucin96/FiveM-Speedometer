# FiveM-Speedometer
FiveM speedometer written in C#.

# Screenshots
https://raw.githubusercontent.com/rucin96/FiveM-Speedometer/main/screenshots/s1.png

https://raw.githubusercontent.com/rucin96/FiveM-Speedometer/main/screenshots/s2.png

https://raw.githubusercontent.com/rucin96/FiveM-Speedometer/main/screenshots/s3.png

# How to use?
Copy the `bin / release` folder and paste it into your resource folder. The folder name should be called "Speedometer".
Switch between mph and kph in `settings.ini`.

# How to change the template?
Go to the `html / templates` folder and copy all files from the selected template to the` html` folder.

# How to create your own template?
- write your template in html / css
- add event listeners for type `message`
- the data is stored in the `event.data` property

## Possible data type events
- `enableui` - if sent, enable or disable the user interface
- `speed` - if sent, update the speedometer value in the template (get it from` data.multiplierValue` and` data.multiplierType`