﻿using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace FlashCards.Api.Configurations
{
    public static class SerilogExtension
    {
        public static void AddSerilogApi(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()
                .Enrich.WithExceptionDetails()
                .Enrich.WithProperty("ApplicationName", "FlashCards")
                //.Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                //.Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
                .WriteTo.Async(wt => wt.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"))
                .CreateLogger();
        }
    }
}
