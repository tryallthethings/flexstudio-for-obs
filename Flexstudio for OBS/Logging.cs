using NLog;
using NLog.Config;
using NLog.Targets;

namespace Flexstudio_for_OBS
{
    public static class Logging
    {
        public static Logger Log { get; } = LogManager.GetCurrentClassLogger();

        public static void ConfigureNLog()
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget("logfile")
            {
                FileName = "logs/log-${shortdate}.log",
                ArchiveFileName = "logs/log.${shortdate}.{#}.log",
                ArchiveNumbering = ArchiveNumberingMode.DateAndSequence,
                ArchiveEvery = FileArchivePeriod.Day,
                ArchiveDateFormat = "yyyy-MM-dd",
                MaxArchiveFiles = 20,
                Layout = "${longdate} ${uppercase:${level}} ${message} ${exception:format=toString,StackTrace}",
                ConcurrentWrites = true,
                KeepFileOpen = false,
            };
            config.AddTarget(fileTarget);

            config.AddRuleForAllLevels(fileTarget);

            LogManager.Configuration = config;
            LogManager.AutoShutdown = true;
        }
    }
}