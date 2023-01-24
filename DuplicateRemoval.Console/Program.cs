using DuplicateRemoval.Core.Infrastructure;
using DuplicateRemoval.Core.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


if (args.Length != 1)
{
    throw new ArgumentException("Invalid args");
}


using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services
            .AddScoped<IFileManager, FileManager>())
    .Build();

var serviceProvider = new ServiceCollection()
    .AddScoped<IFileManager, FileManager>()
    .BuildServiceProvider();

var fileManager = serviceProvider.GetRequiredService<IFileManager>();
var fileName = args[0];
if (!fileManager.FileExists(fileName))
{
    throw new ArgumentException("The filename provided is invalid");
}

var fileData = fileManager.GetFileData(fileName);
DuplicateRemover duplicateRemover;

switch (fileName)
{
    case "Sheet1.csv":
        duplicateRemover = new DuplicateRemover(new PurgeAlgorithm1());
        break;
    case "Sheet2.csv":
        duplicateRemover = new DuplicateRemover(new PurgeAlgorithm2());
        break;
    case "Sheet3.csv":
        duplicateRemover = new DuplicateRemover(new PurgeAlgorithm3());
        break;
    case "Sheet4.csv":
        duplicateRemover = new DuplicateRemover(new PurgeAlgorithm4());
        break;
    default:
        throw new ArgumentException("The filename provided is invalid");
}

duplicateRemover.AddFileData(fileData);

var result = duplicateRemover.Purge();

foreach (var row in result)
{
    Console.WriteLine(row);
}
