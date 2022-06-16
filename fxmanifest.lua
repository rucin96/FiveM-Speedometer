version '1.0.0'
author 'Rucin96'
description 'Speedometer for FiveM server. Works on client side.'
fx_version 'bodacious'
game 'gta5'

files {
    "settings.ini",
    "Newtonsoft.Json.dll",
    "html/*.*",
    "html/img/*.*",
}

client_scripts {
	"Speedometer.net.dll"
}

ui_page {
    "html/index.html"
}