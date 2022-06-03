namespace SUDO.Services;
public static  class EmailHtml{
    public static string giveEmailString(string message){
        string firstHtml = File.ReadAllText("EmailHelper/FirstPart.html");
        string lastHtml = File.ReadAllText("EmailHelper/LastPart.html");
        string fullMessage = firstHtml + message + lastHtml;
        return fullMessage;
    }
}
