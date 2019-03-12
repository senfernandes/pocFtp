using Renci.SshNet;
public static class SendFileToServer
{
    // Enter your host name or IP here
    private static string host = "localhost";

    // Enter your sftp username here
    private static string username = "senf";

    // Enter your sftp password here
    private static string password = "test123";
    public static int Send(string fileName)
    {    
        var connectionInfo = new ConnectionInfo(host, 2222, "senf", new PasswordAuthenticationMethod(username, password));
        // Upload File
        using (var sftp = new SftpClient(connectionInfo)){
            
            sftp.Connect();
            sftp.ChangeDirectory("/test");
            using (var uplfileStream = System.IO.File.OpenRead(fileName)){
                sftp.UploadFile(uplfileStream, fileName, true);
            }
            sftp.Disconnect();
        }
        return 0;
    }
}