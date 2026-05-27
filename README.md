# StackGestaoDeHospital

## Criar Migration
```bash
dotnet ef migrations add <NomeMigration> --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View --output-dir Migrations
```

## Aplicar Migration
```bash
dotnet ef database update --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

## Remover a última migration ainda não aplicada
```bash
dotnet ef migrations remove --project StackGestaoDeHospital.DataBase --startup-project StackGestaoDeHospital.View
```

## Voltar até a migration
```bash
dotnet ef database update <NomeMigration> --project StackGestaoDeHospital.DataBase  --startup-project StackGestaoDeHospital.View
```