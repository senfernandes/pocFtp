using System;
using Renci.SshNet;
public static class SendFileToServer
{
    // Enter your host name or IP here
    private static string host = "localhost";

    // Enter your sftp username here
    private static string username = "senf";

    // Enter your sftp password here
    private static string password = "test123";

    public static int Send (string fileName)
    {
        var connectionInfo = new ConnectionInfo (host, 22, "senf", new PasswordAuthenticationMethod (username, password));
        // Upload File
        using (var sftp = new SftpClient (connectionInfo))
        {

            sftp.Connect ();
            sftp.ChangeDirectory ("/test");
            using (var uplfileStream = System.IO.File.OpenRead (fileName))
            {
                sftp.UploadFile (uplfileStream, fileName, true);
            }
            sftp.Disconnect ();
        }
        return 0;
    }

    public static void ListFiles ()
    {
        using (SftpClient sftp = new SftpClient (host, username, password))
        {
            try
            {
                sftp.Connect ();

                var files = sftp.ListDirectory ("test");

                foreach (var file in files)
                {
                    Console.WriteLine (file.Name);
                }

                sftp.Disconnect ();
            }
            catch (Exception e)
            {
                Console.WriteLine ("An exception has been caught " + e.ToString ());
            }
        }
    }
}