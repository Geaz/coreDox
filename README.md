[![Build status](https://ci.appveyor.com/api/projects/status/qysx4krbhwhmwq9f?svg=true)](https://ci.appveyor.com/project/Geaz/coredox)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Geaz/coreArgs/master/LICENSE)

Create .NET code documentation with ease
------------------

**coreDox** is a documentation tool to create .NET code documentation. The tool creates a model of a given solution and passes it to the registered export plugins. The plugins transform the model to a defined output. **coreDox** comes with a html export plugin and several **ModelProviders** which demonstrate the possibilities of the tool.

**coreDox** is a complete rewrite of [**sharpDox**](https://github.com/geaz/sharpDox) for .NET Core.

Why rewrite?
---

**sharpDox** used *roslyn* to compile a given solution and to analyze the code. 
If **sharpDox** was integrated in a build process, the build server had to compile the solution twice.
Once for the build itself and a second time for **sharpDox**. This is useless overhead and **codeDox** tries to eliminate this by using **cecil** to analyze precompiled *.dlls, *.pdbs & *.xmls (for the code documentation).

It would be possible to accomplish this without a complete rewrite, but **sharpDox** was started as a learning project and has grown within the last few years in such a way that I don't like the code base anymore.

The aim of **coreDox** is to create a cleaner and more maintainable solution. I hope that this will also attract some more people to contribute to **coreDox**.

Project structure
---

**coreDox**

CLI to use coreDox.  
The commands are:

- **new --doc [doc-folder]** *creates a documentation project in the given path*
- **build --doc [doc-folder]** *builds the documentation located in the given path*
- **watch --doc [doc-folder]** *watches the documentation located in the given path, starts a web server to view it, and rebuilds the documentation on changes*

**coreDox.Core**

Contains the whole core model and all contracts of **coreDox**.
The project can be referenced to create custom **Targets** and **ModelProvider**s for coreDox.

This project also contains the core functionality of **coreDox**.
The functionality is structured into different objects:

The folder **Project** contains the classes to handle documentation projects.
- **DoxProject** *Represents the whole documentation project. Its the root for all following objects*
- **DoxConfig** *Represents the configuration of a documentation project*
- **DoxPage** *A single page of the documentation - parsed from the 'pages' folder of a documentation project*

The folder **CodeModel** contains the core model of assemblies, types and members.
- **DoxAssembly** *This is the root class in which an assembly, given through a page file, gets parsed.*
- **DoxNamespace** *DoxAssembly contains several parsed namespaces*
- **DoxType** *DoxNamespace contains several parsed types*
- **DoxEvent, DoxField, DoxMethod, DoxProperty** *DoxType contains several parsed members*

**coreDox.Core** just parses the main attributes of those entities:
- Name
- Fullname
- The Cecil Definition of the entity (**ModelProviders** are able to use this to amend the code model)

The aim was to get the core library as 'slim' as possible. Thats why the remaining code model information, like documentation comments, get parsed by **ModelProvider**s. I hope this ensures a good maintainablity of single features.

Modular Models, Templates and Targets
---
In **sharpDox** the whole documentation model was defined in one big model. **coreDox** goes another way in defining the model.
The core of **coreDox** will just provide a rough structure of the model. Containing the top most entities.
These entities are:

- Namespaces
- Types
- Members (Fields, Properties, Methods etc.)

The data which was parsed in **sharpDox**, like Names, Attributes, Diagrams, Usings etc., are parsed by **ModelProvider**s.

**ModelProvider**s are one of the *plugin* types of **coreDox**. They add more information to the rough core model.

A **Target**, the second *plugin* type, is responsible to transform the parsed model of **coreDox** to something consumable. Like a HTML site, CHM file or a PDF document.

Documentation Projects
---
A documentation folder is structured in the following way:

- layout *contains the themes for the built documentation - contains one folder for each exporter*
- pages *contains all additional pages integrated in the documentation - the folder structures defines also the TOC of the documentation*
- assets *all additional assets like images of icons - used in pages and layouts*
- config.json *the config for the build process of the documentation*