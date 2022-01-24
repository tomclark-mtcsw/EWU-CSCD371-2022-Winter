namespace Logger
{
    public class LogFactory
    {
        private string FilePath = "";

        public BaseLogger? CreateLogger(string className)
        {
            FileLogger fileLogger = new FileLogger()
            {
                ClassName = className
            };

            if (!string.IsNullOrEmpty(FilePath))
            {
                fileLogger.LogFilePath = FilePath;
                return fileLogger;
            }

            return null;
        }

        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
    }
}
