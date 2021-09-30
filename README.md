# ProjectEaton
ProjectEaton is an interview challenge.

To run this project:

* First, you should have docker engine on your local machine. This is required for creating rabbitmq and mongodb service easily and clearly. There are different ways to install it for different OS that's why I route you to [Docker's Documentation](https://www.docker.com/products/docker-desktop)
* After installation of docker you can proof it by using this command: `docker version`
* If you got docker on your machine, please run that command to pull and run rabbitmq service as a container: `docker run -d --hostname rabbit-eaton -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management`
* Then please run that command to pull and run mongodb service as a container: `docker run --name mongoeaton -p 27017:27017 bitnami/mongodb:latest`
* Run following command to clone this repository `git clone https://github.com/ozantopal/ProjectEaton.git` Please be aware that you can do that only if you have git cli on your machine. Otherwise, please just download repository from Github's UI and extract it.
* Change directory to repo's folder `cd ProjectEaton`
* From this point, we're going to use dotnet cli to restore package, build solution and also run projects. That's why you should have dotnet 5 and also dotnet cli on your machine. If you dont have it please follow [Microsoft's Documentation](https://dotnet.microsoft.com/download/dotnet/5.0) 
* After installation of dotnet you can proof it by using this command: `dotnet --version`

* Run following command to restore packages for this solution `dotnet restore`
* Run following command to build solution `dotnet build`
* Run commands below for running projects  
`dotnet run --project .\src\OT.ProjectEaton.MeasurementUnit.Emulator\OT.ProjectEaton.MeasurementUnit.Emulator.csproj`  
`dotnet run --project .\src\OT.ProjectEaton.DataCollector\OT.ProjectEaton.DataCollector.csproj`  
`dotnet run --project .\src\OT.ProjectEaton.CentralResultUnit\OT.ProjectEaton.CentralResultUnit.csproj`
* After all run successfully, you can visit the following page to check and validate increasing message count by time: https://localhost:5001/
