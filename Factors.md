# Explaination of implemented factors
> Source for definitions: https://12factor.net

## I. Codebase
### Definition: 
One codebase tracked in revision control, many deploys

### My implementation:
Usage of one github repository with a master-branch (protected after initial commit) and a development-branch!

## II. Dependencies
### Definition
Explicitly declare and isolate dependencies

### My implementation:
There was no usage of maven or other dependency/package managers. I have all dependencies stored in the twelvefactors_anwar.csproj - during the build the dependencies are downloaded via nuget and added to the build files. There is only netcoreapp3.1 needed, as this is the configured TargetFramework of my *ASP.NET Core Web API*

## III. Config
### Definition
Store config in the environment

### My implementation:
Configuration for mongodb is taken from Environment Variables
#### MongoDB
* MONGO_INITDB_ROOT_USERNAME
* MONGO_INITDB_ROOT_PASSWORD

#### Mongo Express
* ME_CONFIG_MONGODB_ADMINUSERNAME
* ME_CONFIG_MONGODB_ADMINPASSWORD
* ME_CONFIG_MONGODB_URL

## IV. Backing services
### Definition
Treat backing services as attached resources

### My implementation:
This should work with my code by doing the following steps:
1. Start new database container
2. Stop service and switch bindings
3. Start service

## V. Build, release, run
### Definition
Strictly separate build and run stages

### My implementation:
Didn't do this. But it means, that GitHub builds a docker a image (after a commit or whatever trigger is configured) and publishes it @DockerHub, where it can be downloaded and run.
Tutorial: https://docs.docker.com/docker-hub/builds/

## VI. Processes
### Definition
Execute the app as one or more stateless processes

### My implementation:
The app is stateless, the persistence layer uses a mongoDB and all instances have access onto it.

## VII. Port binding
### Definition
Export services via port binding

### My implementation:
* MongoDB is bound to port 27017
* MongoExpress is bound to port 8081
* The catalog API is bound to port 28513

## VIII. Concurrency
### Definition
Scale out via the process model

### My implementation:
Not implemented, but ...

## IX. Disposability
### Definition
Maximize robustness with fast startup and graceful shutdown

### My implementation:
Not implemented ... but usage of a so-called SIGTERM could be implemented to gracefully de-register and shutdown the application (keyboard-shortcut as a trigger for example)

## X. Dev/prod parity
### Definition
Keep development, staging, and production as similar as possible

### My implementation:
As mentioned in *I. Codebase*, I have one github repo with a master-branch and a dev-branch, where I use pull-requests to maintain comprehensible commit history and have the possibility to give feedback based on the handed-in change request. Therefore, the code base is regularly brought onto the same level.

## XI. Logs
### Definition
Treat logs as event streams

### My implementation:
Not fully implemented ... errors are logged in the CatalogController, but nothing is done with the information, could be printed out or saved in a file or even sent to an ELK-stack to make the most of the data.

## XII. Admin processes
### Definition
Run admin/management tasks as one-off processes

### My implementation:
Usage of create-docker.sh to get the docker-compose running and the persistence layer up and working.

## Ideas for additional factors
* Health Dashboard to check status
* Some kind of security layer to use authentication, authorization, data protection and many more ...
