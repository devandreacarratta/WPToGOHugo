# WPToGOHugo

Export your WordPress Posts to Hugo!

## How WPToGOHugo works

- Open the Solution **WPToGOHugo.Console.sln**
- In the project **WPToGOHugo.TestConsole** use the class DownloadPHPPage and call the method Run()
- Get the PHP Page and copy in your wordpress web site as **post2json.php** (base root folder - the same of wp-config.php file)
- Try in your browser https://YourSite.EXT/post2json.php (*)
- Back to WPToGOHugo.TestConsole 
- Set the URL (*) as first argument
- Run the tool
- Open the Build folder and inside "Output" you can see your wordpress's post in the new format!

