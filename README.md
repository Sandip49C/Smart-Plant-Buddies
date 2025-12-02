Smart Plant Buddy

Your IoT Plant Care Companion




Team Members

Sandip Thapa
Roeisha Lwagun
Raymon KC




Project Overview

Smart Plant Buddy is a simple mobile application that helps people keep their houseplants alive by reminding them to water on time. Many busy plant owners forget to check soil moisture regularly, leading to wilted plants and frustration. Our app solves this by connecting a small soil moisture sensor to your phone, showing real-time moisture levels and sending alerts when watering is needed.




What the App Does (In Scope)

Real-time display of soil moisture percentage

Push notifications when moisture drops too low

Simple dashboard showing current status

Basic history of past readings and watering events

Manual log for watering and notes

Button to trigger a water pump remotely (future hardware)




What We Are NOT Doing Yet (Out of Scope)

Support for multiple plants or sensors

Advanced weather integration or plant photo analysis

Web version (mobile only for now)




Current Status – Check-In 1 Complete

Login screen (simple stub)

Dashboard with live moisture and temperature display

Working local SQLite database that saves all readings

Repository pattern with DatabaseHelper and DatabaseRepository

Add fake sensor readings button for testing

Data persists after closing and reopening the app

Clean .NET MAUI project that runs on Windows desktop (x64)

Full source code with proper folder structure




Database Tables (ERD Implemented)

Users – stores user info

Sensors – one sensor per user

SensorReadings – moisture, temperature, timestamp

Alerts – low moisture notifications

WateringLogs – manual and future auto watering events




How to Run the App

Clone this repository

Open SmartPlantBuddy.sln in Visual Studio 2022

Set platform to x64
Select Windows Machine as target
Press F5 to build and run
