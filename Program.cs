using HeartbeatService;
using Topshelf;

var exitCode = HostFactory.Run(x =>
{
    x.Service<Heartbeat>(s =>
    {
        s.ConstructUsing(heartbeat => new Heartbeat());
        s.WhenStarted(heartbeat => heartbeat.Start());
        s.WhenStopped(heartbeat => heartbeat.Stop());
    });

    x.RunAsLocalSystem();

    x.SetServiceName("HeartbeatService");
    x.SetDisplayName("Heartbeat Service");
    x.SetDescription("This is my first windows service using Youtube tutorial");
});

int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
Environment.ExitCode = exitCodeValue;