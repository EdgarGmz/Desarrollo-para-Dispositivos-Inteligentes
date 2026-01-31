# Ejercicios de Dispositivos Inteligentes

Este repositorio contiene ejercicios y actividades desarrollados para la materia de **Dispositivos Inteligentes** utilizando **.NET MAUI** (Multi-platform App UI).

## Proyectos

- **ActFinal**: Proyecto final de la materia con componentes Blazor Hybrid
- **Actividad4IDGS09A**: Actividad 4 del curso

## Requisitos Previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (17.8 o superior) con la carga de trabajo de .NET MAUI
- Para desarrollo Android: Android SDK
- Para desarrollo iOS/Mac: Xcode (solo en macOS)
- Para desarrollo Windows: Windows 10 SDK

## Instalación

1. Clona el repositorio:
```bash
git clone <url-del-repositorio>
cd repos
```

2. Restaura las dependencias de NuGet:
```bash
dotnet restore
```

## Cómo Ejecutar

### Opción 1: Visual Studio

1. Abre el archivo `.slnx` del proyecto que deseas ejecutar:
   - `ActFinal/ActFinal.slnx`
   - `Actividad4IDGS09A/Actividad4IDGS09A.slnx`

2. Selecciona la plataforma de destino en la barra de herramientas (Android, iOS, Windows, etc.)

3. Presiona `F5` o haz clic en el botón "Ejecutar"

### Opción 2: Línea de Comandos

Desde la carpeta del proyecto, ejecuta:

```bash
# Para Windows
dotnet build -f net10.0-windows10.0.19041.0
dotnet run -f net10.0-windows10.0.19041.0

# Para Android
dotnet build -f net10.0-android
dotnet run -f net10.0-android

# Para iOS (requiere macOS)
dotnet build -f net10.0-ios
dotnet run -f net10.0-ios

# Para Mac Catalyst (requiere macOS)
dotnet build -f net10.0-maccatalyst
dotnet run -f net10.0-maccatalyst
```

## Estructura del Proyecto

```
ActFinal/
├── Components/        # Componentes Blazor
│   ├── Layout/       # Layouts de la aplicación
│   └── Pages/        # Páginas Razor
├── Platforms/        # Código específico de cada plataforma
├── Resources/        # Recursos (imágenes, fuentes, etc.)
└── wwwroot/          # Archivos web estáticos

Actividad4IDGS09A/
├── Platforms/        # Código específico de cada plataforma
└── Resources/        # Recursos de la aplicación
```

## Notas

- Los archivos de compilación (`bin/` y `obj/`) están excluidos del control de versiones
- Asegúrate de tener todas las cargas de trabajo necesarias instaladas en Visual Studio
- Para desplegar en dispositivos físicos, se requieren certificados y configuración adicional

## Tecnologías Utilizadas

- .NET 10
- .NET MAUI
- Blazor Hybrid (ActFinal)
- C# 13
