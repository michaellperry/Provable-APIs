using System;
using System.Collections.Generic;

namespace ProvableCode.Patterns
{
    public static class Example6
    {
        class File
        {
            private bool _isOpen = true;
            private bool _atEnd = false;

            public static bool Exists(string path)
            {
                return true;
            }

            public static File Open(string path)
            {
                return new File();
            }

            public void Close()
            {
                _isOpen = false;
            }

            public bool AtEnd { get { return _atEnd; } }

            public string ReadLine()
            {
                if (!_isOpen)
                    throw new InvalidOperationException();

                return "line";
            }
        }

        public static void Right()
        {
            List<Record> records = new List<Record>();
            if (File.Exists("filename.csv"))
            {
                var file = File.Open("filename.csv");
                try
                {
                    while (!file.AtEnd)
                    {
                        string line = file.ReadLine();
                        var record = Record.Parse(line);
                        records.Add(record);
                    }
                    ProcessRecords(records);
                }
                catch (Exception x)
                {
                    ReportError(x.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }

        public static void Wrong1()
        {
            List<Record> records = new List<Record>();
            var file = File.Open("filename.csv");
            try
            {
                while (!file.AtEnd)
                {
                    string line = file.ReadLine();
                    var record = Record.Parse(line);
                    records.Add(record);
                }
            }
            catch (Exception x)
            {
                ReportError(x.Message);
            }
            finally
            {
                file.Close();
            }
        }

        public static void Wrong2()
        {
            List<Record> records = new List<Record>();
            if (File.Exists("filename.csv"))
            {
                var file = File.Open("filename.csv");
                while (!file.AtEnd)
                {
                    string line = file.ReadLine();
                    var record = Record.Parse(line);
                    records.Add(record);
                }
                file.Close();
            }
        }

        public static void Wrong3()
        {
            List<Record> records = new List<Record>();
            if (File.Exists("filename.csv"))
            {
                var file = File.Open("filename.csv");
                try
                {
                    while (true)
                    {
                        string line = file.ReadLine();
                        if (line == null)
                            break;
                        var record = Record.Parse(line);
                        records.Add(record);
                    }
                }
                catch (Exception x)
                {
                    ReportError(x.Message);
                }
                finally
                {
                    file.Close();
                }
            }
        }

        class Record
        {
            public static Record Parse(string line)
            {
                return new Record();
            }
        }

        private static void ProcessRecords(List<Record> records)
        {
        }

        private static void ReportError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
