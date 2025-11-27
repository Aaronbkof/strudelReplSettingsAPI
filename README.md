# API and Database Integration (MVC Component)

## Overview
This is an extension of the original assignment spec and demonstrates a full-stack integration through linking both the React Strudel REPL frontend to an ASP.NET Core Web API backend. The original assignment saved/loaded settings using local JSON files. This implementation builds upon that functionality to additionally house support for a database to which a use may save presets to the localDB or load presets from the DB via HTTP requests to a an custom API endpoint.

as of now the app supports both saving and loading via the original JSON file implementation but can not also save and load settings to an SQL Server instance through an API.

## Setting up the Local Database
1. launch SSMS and connect (keeping in mind your connection string)
2. right click on the `Databases` folder in the explorer and click the option `New Database`
3. enter the database name as `StrudelSettings` then click `add`

## Running the API
> please complete the Local Database setup first before proceeding!

The set up includes running the API which requires a clone and running of a seperate repo.
1. firstly switch to the correct branch: `aaron_dev_final_MVC`
2. clone the API repo: https://github.com/Aaronbkof/strudelReplSettingsAPI.git
3. make sure to switch to the dev branch: `aaron_dev` then launch the API project
4. view the `appsettings.json` and change the `strudelSettingsDbContext` connection string to have the correct data source.
5. run the API project.
> the API end point is defined as a constant (`apiEndpoint`) defined in the `jsonHandling` component make sure to change this in accoradance to what port number your API runs on.

## setting up the react project
1. clone repository: https://github.com/Aaronbkof/strudel_reactor.git
2. cd into project directory
3. switch to branch `aaron_dev_final_MVC`
4. run `npm install`
5. run `npm start`
6. navigate to `http://localhost:3000` or other port depending on your port configurations and availability.

## Running Both Projects
Keep **both** running simultaneously:
- **Terminal 1:** API (`dotnet run` or click run or `F5` on Visual Studio)
- **Terminal 2:** react project (`npm start`)

## Implementation of Components

### Models
`Settings.cs` is what defines the data structure for all the strudel controls, including the bassline, arpeggiator, drums, BPM, timestamp etc. 

### Controller
`strudelSettingsController.cs` is what provides a scaffolded CRUD endpoints as well as a custom GET request, `GetSavedPreset()` endpoint that retrieves the most recently saved DB entry using `OrderByDecending()`.

### Database
EF auto-gen the `Settings` table on first run, which just serves to provide a proper schema for the table based values determined in the model

## Endpoints
1. `GET: /api/strudelSettings/GetSettings` - retrieves all preset entries saved to DB
2. `GET: /api/strudelSettings/GetSavedPreset` - retrieves the most recent preset saved to DB
3. `POST: /api/strudelSettings/SavePreset` - saves a new preset onto the DB
4. `DELETE /api/strudelSettings/DeleteSettings/{id}` - deletes a preset