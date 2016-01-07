using System;
using System.Collections.Generic;
using System.IO;

namespace ProvableCode.Patterns
{
    public static class Example6
    {
        public class FileMonad<T>
        {
            private readonly bool _exists;
            private readonly string _error;
            private readonly List<T> _records;

            private FileMonad(bool exists, string error, List<T> records)
            {
                _exists = exists;
                _error = error;
                _records = records;
            }

            public static FileMonad<T> NotExists()
            {
                return new FileMonad<T>(false, null, new List<T>());
            }

            public static FileMonad<T> Error(string error)
            {
                return new FileMonad<T>(true, error, new List<T>());
            }

            public static FileMonad<T> Records(List<T> records)
            {
                return new FileMonad<T>(true, null, records);
            }

            public FileMonad<U> Parse<U>(Func<T, FileMonad<U>> parser)
            {
                if (!_exists)
                    return FileMonad<U>.NotExists();
                if (_error != null)
                    return FileMonad<U>.Error(_error);

                List<U> newRecords = new List<U>();
                foreach (var oldRecord in _records)
                {
                    FileMonad<U> result = parser(oldRecord);
                    if (!result._exists)
                        return FileMonad<U>.NotExists();
                    if (result._error != null)
                        return FileMonad<U>.Error(result._error);
                    newRecords.AddRange(result._records);
                }
                return FileMonad< U >.Records(newRecords);
            }

            public FileMonad<T> OnError(Action<string> reportError)
            {
                if (_error != null)
                    reportError(_error);
                return this;
            }

            public FileMonad<T> OnSuccess(Action<List<T>> processRecords)
            {
                if (_error == null && _exists)
                    processRecords(_records);
                return this;
            }
        }
        public static class FileProcessor
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
                    if (!Exists(path))
                        throw new FileNotFoundException();

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
            public static FileMonad<string> Open(string path)
            {
                List<string> records = new List<string>();
                if (!File.Exists(path))
                    return FileMonad<string>.NotExists();
                var file = File.Open(path);
                while (!file.AtEnd)
                {
                    string line = file.ReadLine();
                    records.Add(line);
                }
                file.Close();
                return FileMonad<string>.Records(records);
            }
        }

        public static void Right()
        {
            FileProcessor.Open("filename.csv")
                .Parse(ParseRecord)
                .OnError(ReportError)
                .OnSuccess(ProcessRecords);
        }

        private static FileMonad<Record> ParseRecord(string line)
        {
            try
            {
                var record = Record.Parse(line);
                return FileMonad<Record>.Records(new List<Record> { record });
            }
            catch (Exception x)
            {
                return FileMonad<Record>.Error(x.Message);
            }
        }

        //public static void Wrong1()
        //{
        //    List<Record> records = new List<Record>();
        //    var file = File.Open("filename.csv");
        //    try
        //    {
        //        while (!file.AtEnd)
        //        {
        //            string line = file.ReadLine();
        //            var record = Record.Parse(line);
        //            records.Add(record);
        //        }
        //        ProcessRecords(records);
        //    }
        //    catch (Exception x)
        //    {
        //        ReportError(x.Message);
        //    }
        //    finally
        //    {
        //        file.Close();
        //    }
        //}

        //public static void Wrong2()
        //{
        //    List<Record> records = new List<Record>();
        //    if (File.Exists("filename.csv"))
        //    {
        //        var file = File.Open("filename.csv");
        //        while (!file.AtEnd)
        //        {
        //            string line = file.ReadLine();
        //            var record = Record.Parse(line);
        //            records.Add(record);
        //        }
        //        file.Close();
        //        ProcessRecords(records);
        //    }
        //}

        //public static void Wrong3()
        //{
        //    List<Record> records = new List<Record>();
        //    if (File.Exists("filename.csv"))
        //    {
        //        var file = File.Open("filename.csv");
        //        try
        //        {
        //            while (true)
        //            {
        //                string line = file.ReadLine();
        //                if (line == null)
        //                    break;
        //                var record = Record.Parse(line);
        //                records.Add(record);
        //            }
        //            ProcessRecords(records);
        //        }
        //        catch (Exception x)
        //        {
        //            ReportError(x.Message);
        //        }
        //        finally
        //        {
        //            file.Close();
        //        }
        //    }
        //}

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
