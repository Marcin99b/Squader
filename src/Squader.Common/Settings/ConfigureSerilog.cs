using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace Squader.Common
{
    public static class ConfigureSerilog
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile("Logs/log-{Date}.txt", retainedFileCountLimit: 90)
                .CreateLogger();
        }
    }
}
