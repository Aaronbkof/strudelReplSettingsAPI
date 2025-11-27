# studelReplSettingsAPI

## Overview
This is an extension of the original assignment spec and demonstrates a full-stack integration through linking both the React Strudel REPL frontend to an ASP.NET Core Web API backend. The original assignment saved/loaded settings using local JSON files. This implementation builds upon that functionality to additionally house support for a database to which a use may save presets to the localDB or load presets from the DB via HTTP requests to a an custom API endpoint.

this readme will focus more on the aspects of what was added and what the components functions are, the detailed instructions for setup are included in the updated readme on the original strudel REPL react project here: https://github.com/Aaronbkof/strudel_reactor/blob/aaron_dev_final_MVC/README_Aaron.md

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