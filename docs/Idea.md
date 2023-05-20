# Skidly

## Application to support learning.

The application is about choosing the areas in which we want to develop, setting
goals to learn, tracking our progress and (possibly in the future) competing
with other users.

## General
General requirements and objectives of the project.

### Buzzwords
- Clean Architecture
- Domain-Driven Design
- Test-Driven Development
- CQRS
- ASP.NET CORE
- Entity Framework
- SQL Server
- Clean Code (at least I'm trying)

### Functionalities
- Users with Roles
- Studying Areas
- Study Goals (short term, long term)
- Pomodoros
- Habit tracking

## Domain
My initial view how to structure the project.

### User
- Username
- Email
- Password
- TotalStudyHours
- StudyAreas

### Roles
- User
- Admin

### Study Area
- Name
- Description
- Goals
- TotalHoursSpentStudying

### Study Goal
- Name
- Description
- Category [short-term, long-term, supplementary]
- Priority
- HoursSpentStudying
- ExpectedTimeToComplete
- Pomodoros
- IsAchieved

### Pomodoro
- Topic
- ExpectedDuration
- ActualDuration
- StartTime
- EndTime
- IsComplete

### Calendar Event
- Name
- Description
- StartTime
- EndTime

