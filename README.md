[![Build Status](https://travis-ci.org/geaz/coreDox.svg?branch=dev)](https://travis-ci.org/geaz/coreDox)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/Geaz/coreArgs/master/LICENSE)

Create .NET code documentation with ease
------------------

**coreDox** is a documentation tool to create .NET code documentation. The tool creates a model of a given solution and passes it to the registered export plugins. The plugins transform the model to a defined output. **coreDox** comes with a html export plugin which demonstrate the possibilities of the tool.

**coreDox** is a complete rewrite of [**sharpDox**](https://github.com/geaz/sharpDox) for .NET Core.

Why rewrite?
---

**sharpDox** used *roslyn* to compile a given solution and to analyze the code. 
If **sharpDox** was integrated in a build process, the build server had to compile the solution twice.
Once for the build itself and a second time for **sharpDox**. This is useless overhead and **codeDox** tries to 
eliminate this by using **cecil** to analyze precompiled *.dlls, *.pdbs & *.xmls (for the code documentation).

It would be possible to accomplish this without a complete rewrite, but **sharpDox** was started as a learning project and has grown within the last few years in such a way that I don't like the code base anymore.

The aim of **coreDox** is to create a cleaner and more maintainable solution. I hope that this will also attract some more people to contribute to **coreDox**.

Project structure
---

**coreDox**

CLI to use coreDox.  
The commands are:

- **new --doc [doc-folder]** *creates a new documentation project in the given path*
- **build --doc [doc-folder]** *builds the documentation located in the given path*
- **watch --doc [doc-folder]** *watches the documentation located in the given path, starts a web server to view it, and rebuilds the documentation on changes*

**coreDox.Core**

Contains the whole model and all contracts of **coreDox**.
The project can be referenced to create custom exporters for coreDox.

This project also contains the core functionality of **coreDox**.
The functionality is structured into different services:

- **ConfigService** *Service to manage documentation configs*
- **ContentService** *Service to load additional pages in the **pages** folder of a documentation project and for parsing the toc file*
- **ExporterService** *Service to manage registered exporters*
- **ParserService** *Service to parse the XML documentation and IL Code of a compiled .NET Project*
- **PluginDiscoveryService** *This service is responsible for the discovery of all **coreDox** plugins*
- **ServiceLocator** *Used to get an instance of a service*

**coreDox.Exporter.Html**

The default exporter for coreDox. Exports the parsed project to a html page.

Modular Models, Templates and Exporters (IDEA!?)
---
In **sharpDox** the whole documentation model was defined in one big model. **coreDox** goes another way in defining the model.
The core of **coreDox** will just provide a rough structure of the model. Containing the top most entities (including an ID) in a code project.
These entities are:

- Namespaces
- Types
- Members

The data which was parsed in **sharpDox** like Names, Attributes, Diagrams, Usings etc. are parsed by **ModelProviders**.

**ModelProviders** are one of the *plugin* types of **coreDox**. They add more information to the rough core model.
These information can be used by **TagProviders**, the second *plugin* type of **coreDox**.

**TagProviders** are able to use the whole model of **coreDox** (core model + **ModelProviders**) by defining template tags.
Template tags can be used by templates in an **Exporter** - the last *plugin* type of **coreDox**.

**Exporters** are responsible to make the parsed model of **coreDox** to something consumable. Like a HTML site or a PDF document.

Documentation Projects
---
The **new** command creates a new documentation project into the given folder.
A documentation folder is structured in the following way:

- layout *contains the themes for the built documentation - contains one folder for each exporter*
- pages *contains all additional pages integrated in the documentation - referenced in the toc.md*
- assets *all additional assets like images of icons - used in pages and layouts*
- toc.md *the table of contents for the documentation*
- config.yaml *the config for the build process of the documentation*