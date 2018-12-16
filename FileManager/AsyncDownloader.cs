using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FileManager
{
    class AsyncDownloader
    {
        WebResponse response;
        Stream remoteStream;
        Stream localStream;

        CancellationTokenSource cts = new CancellationTokenSource();

        public async Task<bool> DownloadFile(Uri uri, string filePath, IProgress<int> progress)
        {
            var token = cts.Token;
            try
            {             
                WebRequest request = WebRequest.Create(uri);
                response = request.GetResponse();
                long filesize = 1;
                long.TryParse(response.Headers.Get("Content-Length"), out filesize);

                remoteStream = response.GetResponseStream();
                localStream = File.Create(filePath);

                byte[] buffer = new byte[4096];
                int bytesRead = 0;

                long totalBytesRead = 0;
                await Task.Run(() =>
                {
                    do
                    {
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                        localStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;
                        progress.Report((int)(totalBytesRead * 100 / filesize));
                    } while (bytesRead > 0 && !token.IsCancellationRequested);
                }, token
                );                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                // Close the response and streams objects here 
                // to make sure they're closed even if an exception
                // is thrown at some point
                if (response != null) response.Close();
                if (remoteStream != null) remoteStream.Close();
                if (localStream != null) localStream.Close();
            }
            return !token.IsCancellationRequested;
        }

        public void Cancel()
        {
            cts.Cancel();
        }
    }
}
