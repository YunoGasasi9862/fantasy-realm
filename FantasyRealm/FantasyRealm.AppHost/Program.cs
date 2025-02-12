var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.API_FantasyRealm>("api-fantasyrealm");

builder.Build().Run();
