# Vehicle Management System

Sustav za upravljanje vozilima koji omogućuje praćenje vozila, modela, vlasnika i registracija.

## Funkcionalnosti

- CRUD operacije za marke vozila (VehicleMake)
- CRUD operacije za modele vozila (VehicleModel)
- CRUD operacije za vlasnike vozila (VehicleOwner)
- CRUD operacije za registracije vozila (VehicleRegistration)
- Pregledavanje tipova motora (VehicleEngineType)

## Arhitektura

Projekt koristi višeslojnu arhitekturu:
- Data Access Layer (DAL)
- Repository pattern
- Service layer
- WebAPI
- React frontend s MobX za upravljanje stanjem