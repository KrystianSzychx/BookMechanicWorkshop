# Book Mechanic Workshop App Documentation

## Overview
The goal of the "Book Mechanic Workshop App" project is to create a web platform enabling users to search for mechanic workshops in a specific location, check service prices, and book appointments.

## Table of Contents
1. [Introduction](#introduction)
   * [Technologies Used](#technologies-used)
2. [MVC Architecture](#mvc-architecture)
   * [Model](#model)
   * [View](#view)
   * [Controller](#controller)
3. [Application Features](#application-features)
   * [Registration and Login](#registration-and-login)
   * [Searching for Mechanic Workshops](#searching-for-mechanic-workshops)
   * [Viewing Service Prices](#viewing-service-prices)
   * [Booking Appointments](#booking-appointments)
4. [Implementation](#implementation)
    * [Directory Structure](#directory-structure)
    * [Key Classes and Interfaces](#key-classes-and-interfaces)
    * [Database](#database)
  
   ## Introduction
   ### Technologies Used
        * C# .NET 7.0
        * ASP.NET MVC 5
        * Entity Framework 7.0
        * HTML5, CSS3, JavaScript
        * Microsoft SQL Server as the database

   ## MVC Architecture
   ### Model
   The model includes data structures, business logic, and data access. In this project, models represent object such as 
   User, Appointment, MechanicWorkshop, ServiceMechanicWorkshop
   ### View
   Views are responsible for presenting data to the user. Used HTML, CSS and JavaScript to create the user interface.
   ### Controller
   Controllers handle user requests, manage business logic, and communicate with the model and view. Controllers in the 
   project include registration, login, searching, viewing prices, and appointment booking.

   ## Application Features
   ### Registration and Login
   Users can create accounts and log in. Access to certain features, such as appointment booking, is available after 
   loggging in.

   ### Searching for Mechanic Workshops
   Users can browse available mechanic workshops, sort them by location.

   ### Viewing Service Prices
   Users have access to information about service prices offered by workshops.

   ### Booking Appointments
   Logged-in users can book appointments with selected workshops.

   ## Implementation
   ### Directory Structure
   The project is organized into directories such as `Controllers`, `Models`, `Views`, `Services`, for maintaining order and 
   modularity.

   ### Key Classes and Interfaces
   The project includes key classes such as `Users`, `Appointment`, `MechanicWorkshop`, `ServiceMechanicWorkshop`,
   which implement relationships between entities. . The business logic is encapsulated within service classes, such as 
   `AppointmentRepository`,`MechanicWorkshopRepository`, `ServiceMechanicWorkshopRepository`. Interfaces, such as 
   `IAppointmentRepository`,`IMechanicWorkshopRepository` and `IServiceMechanicWorkshopRepository`, define methods for data 
   access.

   ### Database
   SQL Server as the database to store application data, utilizing Entity Framework.
