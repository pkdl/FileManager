using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace FileManager
{
    class FileSearcher
    {
        ConcurrentQueue<FileInfo> matchedFiles;
        CancellationTokenSource cts = new CancellationTokenSource();

        public void StartSearchByName(string wildcard, Panel panel)
        {
            if (!wildcard.Any())
            {
                CancelSearchByName();
                panel.ShowDirectory();                
                return;
            }

            var view = panel.view;
            string path = panel.data.CurrentPath;

            cts = new CancellationTokenSource();
            var token = cts.Token;

            view.Clear();
            view.Columns.Add("Name");
            view.Columns[0].Width = 200;
            view.Columns.Add("Type");

            matchedFiles = new ConcurrentQueue<FileInfo>();

            Task.Run(() => SearchByName(wildcard, path, token), token);

            Task.Run(() => {
                //Task.Delay(100);
                while (!token.IsCancellationRequested)
                {
                    int count = 100;
                    var buffer = new List<FileInfo>();
                    while (count > 0 && !matchedFiles.IsEmpty && !token.IsCancellationRequested)
                    {
                        count--;
                        if (matchedFiles.TryDequeue(out FileInfo file))
                        {
                            buffer.Add(file);                            
                        }
                    }
                    view.Invoke(new Action(() => { view.Add(buffer); }));
                    //Task.Delay(2000);
                }                    
            }, token);
        }

        public void CancelSearchByName()
        {
            cts.Cancel();
        }

        private void SearchByName(string wildcard, string path, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;

            var browser = new DirectoryBrowser();
            browser.GetDirectoryInfo(path);

            var matched = Array.FindAll(browser.fileList, item => MatchName(wildcard, item.Name));
            foreach (var file in matched)
            {
                matchedFiles.Enqueue(file);
            }

            Parallel.ForEach(browser.dirList, new ParallelOptions { MaxDegreeOfParallelism = 3 }, dir =>
            {
                SearchByName(wildcard, dir.FullName, token);
            });
        }

        private bool MatchName(string wildcard, string name)
        {
            var pattern = new System.Management.Automation.WildcardPattern(wildcard);
            bool res = pattern.IsMatch(name);
            return res;
        }
    }
}
