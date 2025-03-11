# CleanArchitectureTemplate Setup

## Part 1: Create the Project

```bash
# Create the main solution directory
mkdir CleanArchitectureTemplate
cd CleanArchitectureTemplate



# Create src and test subdirectories
mkdir src
mkdir test

# Navigate to the src folder and create individual project directories
cd src


mkdir CleanArchitectureTemplate.Api
mkdir CleanArchitectureTemplate.Application
mkdir CleanArchitectureTemplate.Shared
mkdir CleanArchitectureTemplate.Contracts
mkdir CleanArchitectureTemplate.Domain
mkdir CleanArchitectureTemplate.Infrastructure

# Create class libraries for each layer, except for Api (WebAPI)
dotnet new classlib -n CleanArchitectureTemplate.Application -o CleanArchitectureTemplate.Application
dotnet new classlib -n CleanArchitectureTemplate.Shared -o CleanArchitectureTemplate.Shared
dotnet new classlib -n CleanArchitectureTemplate.Contracts -o CleanArchitectureTemplate.Contracts
dotnet new classlib -n CleanArchitectureTemplate.Domain -o CleanArchitectureTemplate.Domain
dotnet new classlib -n CleanArchitectureTemplate.Infrastructure -o CleanArchitectureTemplate.Infrastructure

# Create WebAPI for CleanArchitectureTemplate.Api
dotnet new webapi -n CleanArchitectureTemplate.Api -o CleanArchitectureTemplate.Api

# Navigate back to the main directory
cd ..

# Create test projects for Domain and Application layers
cd test

mkdir CleanArchitectureTemplate.Domain.Tests
mkdir CleanArchitectureTemplate.Application.Tests

# Create classlib for test projects
dotnet new xunit -n CleanArchitectureTemplate.Domain.Tests -o CleanArchitectureTemplate.Domain.Tests
dotnet new xunit -n CleanArchitectureTemplate.Application.Tests -o CleanArchitectureTemplate.Application.Tests

# Navigate back to the root directory to add all projects to the solution
cd ..

# Create the solution file
dotnet new sln -n CleanArchitectureTemplate

# Add projects to the solution
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Api/CleanArchitectureTemplate.Api.csproj
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Shared/CleanArchitectureTemplate.Shared.csproj
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Contracts/CleanArchitectureTemplate.Contracts.csproj
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Domain/CleanArchitectureTemplate.Domain.csproj
dotnet sln CleanArchitectureTemplate.sln add src/CleanArchitectureTemplate.Infrastructure/CleanArchitectureTemplate.Infrastructure.csproj
dotnet sln CleanArchitectureTemplate.sln add test/CleanArchitectureTemplate.Domain.Tests/CleanArchitectureTemplate.Domain.Tests.csproj
dotnet sln CleanArchitectureTemplate.sln add test/CleanArchitectureTemplate.Application.Tests/CleanArchitectureTemplate.Application.Tests.csproj

# End script
echo "Solution structure created successfully."
```

## Part 2: Add References

```bash
# Add project references for CleanArchitectureTemplate.Api
dotnet add src/CleanArchitectureTemplate.Api/CleanArchitectureTemplate.Api.csproj reference src/CleanArchitectureTemplate.Contracts/CleanArchitectureTemplate.Contracts.csproj
dotnet add src/CleanArchitectureTemplate.Api/CleanArchitectureTemplate.Api.csproj reference src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj

# Add project references for CleanArchitectureTemplate.Domain
dotnet add src/CleanArchitectureTemplate.Domain/CleanArchitectureTemplate.Domain.csproj reference src/CleanArchitectureTemplate.Shared/CleanArchitectureTemplate.Shared.csproj

# Add project references for CleanArchitectureTemplate.Application
dotnet add src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj reference src/CleanArchitectureTemplate.Domain/CleanArchitectureTemplate.Domain.csproj

# Add project references for CleanArchitectureTemplate.Infrastructure
dotnet add src/CleanArchitectureTemplate.Infrastructure/CleanArchitectureTemplate.Infrastructure.csproj reference src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj

# Add project references for test projects
# CleanArchitectureTemplate.Domain.Tests references CleanArchitectureTemplate.Domain
dotnet add test/CleanArchitectureTemplate.Domain.Tests/CleanArchitectureTemplate.Domain.Tests.csproj reference src/CleanArchitectureTemplate.Domain/CleanArchitectureTemplate.Domain.csproj

# CleanArchitectureTemplate.Application.Tests references CleanArchitectureTemplate.Application
dotnet add test/CleanArchitectureTemplate.Application.Tests/CleanArchitectureTemplate.Application.Tests.csproj reference src/CleanArchitectureTemplate.Application/CleanArchitectureTemplate.Application.csproj
echo "Solution Refrence structure created successfully."
```


## Part 3: Restore and Build API

```bash
cd src/CleanArchitectureTemplate.Api/
# Restore dependencies
dotnet restore

# Build the solution
dotnet build
echo "Solution build structure  successfully."
```

# End of Setup
