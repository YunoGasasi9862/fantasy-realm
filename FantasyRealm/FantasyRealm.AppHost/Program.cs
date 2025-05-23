var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.API_FantasyRealm>("api-fantasyrealm");

builder.AddProject<Projects.API_FantasyUser>("api-fantasyuser");

builder.AddProject<Projects.API_Gateway>("api-gateway");

builder.Build().Run();
