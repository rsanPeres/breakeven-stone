#To run a migration

Go to the directory of the infra project and run:

`dotnet ef migrations add <MigrationName> -o Migrations`

#To rollback a migration

Go to the directory of the infra project and run:

`dotnet ef migrations remove`

#To update the database with the migration
´dotnet ef database update´