var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Domain>("domain");

builder.Build().Run();
