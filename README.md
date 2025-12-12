Smart Plant Buddy

Your IoT Plant Care Companion



Team Members

Sandip Thapa

Roeisha Lwagun

Raymon KC



Project Overview

Smart Plant Buddy is a simple mobile application that helps people keep their houseplants alive by reminding them to water on time. Many busy plant owners forget to check soil moisture regularly, leading to wilted plants and frustration. Our app solves this by connecting a small soil moisture sensor to your phone, showing real-time moisture levels and sending alerts when watering is needed.



Problem Statement

Many individuals struggle to keep houseplants alive due to inconsistent watering schedules. Forgetting to check soil moisture regularly often results in over- or under-watering, leading to plant stress or death. Our solution addresses this common challenge by providing an automated, user-friendly plant care companion.

Solution Overview

Smart Plant Buddy is a fully functional .NET MAUI Blazor Hybrid application that serves as an intelligent plant care companion. It connects a low-cost capacitive soil moisture sensor to the user’s smartphone, providing real-time monitoring and automated reminders — making plant care effortless and reliable.

Project Scope & Objectives

Smart Plant Buddy delivers the following core features:

Real-time display of soil moisture and temperature
Push notifications when moisture falls below 30%
Persistent local storage of all sensor readings and watering events
Secure user authentication
Clean, intuitive dashboard matching our approved wireframes
Manual watering log with timestamped entries

All development remained strictly within scope: single plant, single sensor, mobile-only, offline-first architecture.

Technical Architecture

The application follows a clean MVVM pattern with full separation of concerns:

Data Layer: SQLite database with five normalized tables exactly matching our ERD (Users → Sensors → SensorReadings → Alerts/WateringLogs)
Service Layer: Dependency-injected services for authentication, notifications, and future weather integration
Security: Passwords hashed using BCrypt, credentials stored via SecureStorage
Native Features: Local push notifications and device vibration using Plugin.LocalNotification
Platform: .NET MAUI with Blazor Hybrid for consistent UI across Android, iOS, and Windows

Success Metrics Achieved

Real-time data display with sub-2-second latency: Achieved
Push notifications within 5 seconds of low moisture: Achieved
Intuitive interface confirmed by all team members and peers
Zero data loss across 50+ simulated watering events over multiple days

Conclusion

Smart Plant Buddy successfully transforms a common household problem into an elegant, reliable mobile solution. The application is production-ready, fully documented, and adheres 100% to our original project charter, ERD, and UI specifications.
We would like to thank you for your guidance throughout the semester. This project has significantly strengthened our skills in mobile development, database design, security implementation, and professional software engineering practices.

