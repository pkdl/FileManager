using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace FileManager
{
    public class ParallelActions
    {
        public delegate void FileAction(FileInfo file);

        private String startPath;
        private FileAction action;
        private int numberOfWorkers;

        public int queuedFilesCount { get => taskQueue.Count; }
        public int aliveWorkers { get; private set; }
        private ConcurrentQueue<FileInfo> taskQueue;
        public ConcurrentBag<String> results { get; private set; }

        private List<string> regexList = new List<string>
            { @"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",   //phone number
              @"(\d{4}\s\d{6})",                                       //passport
              @"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",                     //e-mail
              @"(https?://([a-z1-9]+.)?[a-z1-9\-]+(\.[a-z]+){1,}/?)"   //links
            };
        private bool crawlFinished = false;

        public bool workFinished { get; private set; }

        private List<Thread> workers;
        private bool stopSignal = false;

        public enum Actions { search, archive}

        public ParallelActions(String path)
        {
            taskQueue = new ConcurrentQueue<FileInfo>();
            results = new ConcurrentBag<string>();
            workers = new List<Thread>();
            workFinished = false;
            this.startPath = path;
            this.action = Search;
            numberOfWorkers = Math.Max(1, Environment.ProcessorCount - 1);
        }

        public void Start()
        {
            var crawler = new Thread(StartCrawl)
            {
                IsBackground = true
            };
            crawler.Start();

            for (int i = 0; i < numberOfWorkers; i++)
            {
                var worker = new Thread(DoWork)
                {
                    IsBackground = true
                };
                workers.Add(worker);
                worker.Start();
            }

            var waiter = new Thread(WaitForResult)
            {
                IsBackground = true
            };
            waiter.Start();
            
        }

        public void StopAllThreads()
        {
            stopSignal = true;
        }

        private void WaitForResult()
        {
            bool somethingIsAlive = true;
            while (somethingIsAlive && !stopSignal)
            {
                somethingIsAlive = false;
                aliveWorkers = 0;
                foreach (var thread in workers)
                {
                    somethingIsAlive |= thread.IsAlive;
                    aliveWorkers++;
                }
                Thread.Sleep(100);
            }
            //var form = new SearchResultForm(results.ToArray());
            //form.ShowDialog();
            workFinished = true;
            
        }

        private void StartCrawl()
        {
            crawlFinished = false;
            Crawl(startPath);
            crawlFinished = true;
        }

        private void Crawl(String path)
        {
            if (stopSignal) return;
            var browser = new DirectoryBrowser();
            browser.GetDirectoryInfo(path);
            
            foreach (var file in browser.fileList)
            {
                taskQueue.Enqueue(file);
            }

            foreach (var dir in browser.dirList)
            {
                Crawl(dir.FullName);
            }
        }

        private void DoWork()
        {
            while ( !(taskQueue.IsEmpty && crawlFinished) && !stopSignal)
            {
                if (taskQueue.TryDequeue(out FileInfo file))
                {
                    Search(file);
                }
            }
        }

        private void Search(FileInfo file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        foreach (var regex in regexList)
                        {
                            if (Regex.Match(line, regex).Success)
                                results.Add(file.FullName + " " + Regex.Match(line, regex));
                        }
                    }
                }
            }
            catch
            {

            }
            
        }

    }
}
