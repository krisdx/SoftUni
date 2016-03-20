namespace LoggerLibrary.Models.Appenders
{
    using System;
    using System.IO;

    using Interfaces;

    /// <summary>
    /// A class for writing reports in a file. It will generate .txt files in a separate folder, called "Ouput-File-Loggs".
    /// </summary>
    public class FileAppender : IAppender
    {
        private const string DefaultFileName = "Output-Log-File.txt";
        private const string DefaultFileExtentionType = ".txt";

        private string fileName;
        private ILayout layout;

        public FileAppender(ILayout layout, string fileName = DefaultFileName)
        {
            this.layout = layout;
            this.FimeName = fileName;
        }

        /// <summary>
        /// The property holds the file's name. Every time when the name of the file is changed, the reports will be logged in a different file. 
        /// </summary>
        public string FimeName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                if (!value.Contains("."))
                {
                    value += DefaultFileExtentionType;
                }

                this.fileName = value;
            }
        }

        public void Append(string message, string reportType, DateTime timeOfReport)
        {
            string binFolder = Directory.GetParent(Environment.CurrentDirectory).FullName;
            string projectFolder = Directory.GetParent(binFolder).FullName;

            string outputFolder = projectFolder + "\\Ouput-File-Loggs";
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string filePath =
                outputFolder + string.Format("\\{0}", this.FimeName);

            string formatedMessage =
                this.layout.FormatMessage(message, reportType, timeOfReport);

            File.AppendAllText(filePath, formatedMessage + Environment.NewLine);
        }
    }
}