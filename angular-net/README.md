# Angular-Net

This project is built based on the web stack I am most familure with.

## Angular frontend

NX angular standalone app.

Build and run as a SPA served on its own address as a static web app(could be CDN on deploy)

I normally am using angular as part of a mono repo with multiple apps all hosted through a .Net Framework website.

## .NET backend

.NET api backend using .NET 8 and minimal apis. SQL express data storage using EF Core.

## Task List

- [x] Setup
  - [x] Front end placeholder
  - [x] Back end placeholder
  - [x] FE connect to BE and have E2E work
  - [x] Add bootstrap for styling
- [x] Workflow building
  - [x] Add efcore with database
  - [x] Named workflow
  - [x] Add description to workflow
  - [x] Add steps to workflow with name
- [ ] Prepare for Github actions
  - [x] Pass nx lint
  - [x] Pass nx test
  - [x] Pass dotnet test
  - [ ] Build sample e2e test that runs front and back
- [ ] Move parts through workflows
  - [x] Create parts
  - [x] Parts are on a step and can be advanced/completed
  - [x] Prevent editing Workflows with parts that are not completed
  - [ ] Change to only prevent removing steps that are currently active for a part
  - [ ] Split out query functionality for Parts so we can prevent updates prior to attempt
- [ ] Resources
- [ ] Act as a resource (complete steps)
- [ ] More complex business rules around editing workflows
- [ ] Part planning - give steps duration and then attempt to maximize part volumn with various strategies
