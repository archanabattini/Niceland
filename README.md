# Niceland
Inventory Management for Niceland Convenient Store

It is solution created by Archana Battini for a problem given for interview.

## Solution Approach
Created solution using .NET Web API accessing input list of string and return output as list of strings.

I have architected the solution by following the below approach
- Identify the model [Item]
- Identified different layers in my solution, i.e. controller, services, repositories
- Analysed to identify the base formula for calculating sell value and quality value of an item.
- Identified and applied the design patterns [Composite, Decorator & Factory Method] to satify all the rules. This will make application maintainable as per SOLID design principles.
- Followed TDD & Created unit tests using NUnit & Mock to ensure that every method is independently tested.

External libraries used:
- NUnit & MoQ for unit testing & TDD
- Unity container for dependency injection

Assumptions:
- No front end required to develop as part of solution.
- Depending on the sample input and output provided, it is assumed that the solution is only for the predefined 5 items.
- For this temporary solution, I have not used any database, but just hardcoded the items in repository. [This approach is chosen to easily run at your end and also it was not indicated in problem to use any specific database.]

## Sourcecode
Source code is available in public git repository - https://github.com/archanabattini/Niceland.git

## Build
- Download & Install Vistual Studio 2019
- File -> Clone Repository
Provide repository URL https://github.com/archanabattini/Niceland.git
- Build -> Build Solution

## Run
- Start application in visual studio 2019
- Download & Install Postman
- File -> Import -> Link
Use this link - https://www.getpostman.com/collections/cc86b388c48884f0e2a7
OR
- File -> Import -> Upload File
select **Niceland API.postman_collection** from the project. It is in base folder.
- You should see two API calls imported. Please change port 56211 in URLs if different port used.
- You can use Postman to run these API.

## API
Please visit postman documentation URL for description of API.

https://documenter.getpostman.com/view/15628071/TzRLnWWP



